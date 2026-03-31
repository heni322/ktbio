using KTBioAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleStockController : ControllerBase
    {
        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public ArticleStockController(KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        // ─────────────────────────────────────────────────────────────────────
        // POST api/ArticleStock/filter
        // Body: {
        //   familles: ["CARD01",...],
        //   depots:   [1, 2, ...],
        //   search:   "ketamine",
        //   page:     1,          ← 1-based
        //   pageSize: 20
        // }
        // ─────────────────────────────────────────────────────────────────────
        [HttpPost("filter")]
        public async Task<ActionResult<ArticleStockPagedResponse>> GetFiltered(
            [FromBody] ArticleStockFilterRequest request)
        {
            if (_useMockData)
                return Ok(new ArticleStockPagedResponse
                {
                    Articles   = new List<ArticleStockRow>(),
                    Depots     = new List<DepotInfo>(),
                    TotalCount = 0,
                    Page       = 1,
                    PageSize   = request.PageSize > 0 ? request.PageSize : 20
                });

            try
            {
                int page     = Math.Max(1, request.Page);
                int pageSize = request.PageSize is > 0 and <= 500 ? request.PageSize : 20;
                var today    = DateTime.Now;

                // ── 1. Load depots (cheap, cached in practice) ──────────────
                var allDepots = await _context.FDepots.ToListAsync();
                List<DepotInfo> depotList;
                if (request.Depots != null && request.Depots.Any())
                    depotList = allDepots
                        .Where(d => request.Depots.Contains(d.DeNo ?? 0))
                        .Select(d => new DepotInfo { DeNo = d.DeNo ?? 0, DeIntitule = d.DeIntitule ?? "" })
                        .OrderBy(d => d.DeNo).ToList();
                else
                    depotList = allDepots
                        .Select(d => new DepotInfo { DeNo = d.DeNo ?? 0, DeIntitule = d.DeIntitule ?? "" })
                        .OrderBy(d => d.DeNo).ToList();

                // ── 2. Build WHERE clauses (shared by count + data queries) ─
                var whereClauses = new List<string> { "ls.LS_QteRestant > 0" };

                if (request.Familles != null && request.Familles.Any())
                {
                    var values = string.Join("','",
                        request.Familles.Select(f => f.Trim().Replace("'", "''")));
                    whereClauses.Add($"RTRIM(a.FA_CodeFamille) IN ('{values}')");
                }

                if (request.Depots != null && request.Depots.Any())
                    whereClauses.Add($"s.DE_No IN ({string.Join(",", request.Depots)})");

                if (!string.IsNullOrWhiteSpace(request.Search))
                {
                    // Sanitise: allow only safe characters to avoid injection
                    var safe = new string(request.Search
                        .Where(c => char.IsLetterOrDigit(c) || c == ' ' || c == '-' || c == '_' || c == '.')
                        .ToArray()).Trim();

                    if (!string.IsNullOrEmpty(safe))
                        whereClauses.Add(
                            $"(RTRIM(a.AR_Design) LIKE '%{safe}%' OR RTRIM(a.AR_Ref) LIKE '%{safe}%')");
                }

                var whereStr = "WHERE " + string.Join(" AND ", whereClauses);

                // ── 3. Count DISTINCT articles that match ───────────────────
                string countSql = $@"
                    SELECT COUNT(DISTINCT a.AR_Ref)
                    FROM dbo.F_ARTICLE a
                    INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                    INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                    {whereStr}";

                int totalCount = 0;

                // ── 4. Get the AR_Refs for this page (keyset/OFFSET) ────────
                //   We ORDER articles by AR_Design then page with OFFSET / FETCH.
                string pageRefsSql = $@"
                    SELECT DISTINCT a.AR_Ref, RTRIM(a.AR_Design) AS AR_Design
                    FROM dbo.F_ARTICLE a
                    INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                    INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                    {whereStr}
                    ORDER BY AR_Design, a.AR_Ref
                    OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                var pageRefs = new List<(string ArRef, string ArDesign)>();

                // ── 5. Fetch lot details only for those refs ─────────────────
                //   (avoids loading the entire table)
                var flat = new List<ArticleLotFlat>();

                await using var conn = _context.Database.GetDbConnection();
                if (conn.State != System.Data.ConnectionState.Open)
                    await conn.OpenAsync();

                // Count
                await using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = countSql;
                    var scalar = await cmd.ExecuteScalarAsync();
                    totalCount = scalar == null || scalar == DBNull.Value ? 0 : Convert.ToInt32(scalar);
                }

                // Page refs
                await using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = pageRefsSql;
                    await using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                        pageRefs.Add((rdr["AR_Ref"]?.ToString()?.Trim() ?? "",
                                      rdr["AR_Design"]?.ToString()?.Trim() ?? ""));
                }

                if (pageRefs.Count > 0)
                {
                    // Lot details for the page refs only
                    var refList = string.Join("','",
                        pageRefs.Select(r => r.ArRef.Replace("'", "''")));

                    // Extra depot/famille filters still apply here for consistency
                    var lotWhere = new List<string>
                    {
                        $"a.AR_Ref IN ('{refList}')",
                        "ls.LS_QteRestant > 0"
                    };
                    if (request.Depots != null && request.Depots.Any())
                        lotWhere.Add($"s.DE_No IN ({string.Join(",", request.Depots)})");

                    string detailSql = $@"
                        SELECT
                            a.AR_Ref,
                            RTRIM(a.AR_Design)      AS AR_Design,
                            RTRIM(a.FA_CodeFamille)  AS FA_CodeFamille,
                            s.DE_No,
                            ls.LS_QteRestant,
                            ls.LS_NoSerie,
                            ls.LS_Peremption,
                            ls.cbMarq               AS LsId
                        FROM dbo.F_ARTICLE a
                        INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                        INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                        WHERE {string.Join(" AND ", lotWhere)}
                        ORDER BY a.AR_Design, ls.LS_Peremption";

                    await using var cmd = conn.CreateCommand();
                    cmd.CommandText = detailSql;
                    await using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                    {
                        flat.Add(new ArticleLotFlat
                        {
                            LsId          = rdr["LsId"]          == DBNull.Value ? 0  : Convert.ToInt32(rdr["LsId"]),
                            ArRef         = rdr["AR_Ref"]?.ToString()?.Trim()         ?? "",
                            ArDesign      = rdr["AR_Design"]?.ToString()?.Trim()      ?? "",
                            FaCodeFamille = rdr["FA_CodeFamille"]?.ToString()?.Trim() ?? "",
                            DeNo          = rdr["DE_No"]          == DBNull.Value ? 0  : Convert.ToInt32(rdr["DE_No"]),
                            LsNoSerie     = rdr["LS_NoSerie"]?.ToString()?.Trim()     ?? "",
                            LsPeremption  = rdr["LS_Peremption"]  == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["LS_Peremption"]),
                            LsQteRestant  = rdr["LS_QteRestant"]  == DBNull.Value ? 0m : Convert.ToDecimal(rdr["LS_QteRestant"])
                        });
                    }
                }

                // ── 6. Group into ArticleStockRow objects ────────────────────
                //   Preserve the ORDER we got from pageRefs.
                var flatByRef = flat.GroupBy(x => x.ArRef).ToDictionary(g => g.Key);

                var articles = pageRefs
                    .Select(pr =>
                    {
                        var items = flatByRef.TryGetValue(pr.ArRef, out var g) ? g.ToList() : new List<ArticleLotFlat>();
                        var famCode = items.FirstOrDefault()?.FaCodeFamille ?? "";

                        return new ArticleStockRow
                        {
                            ArRef         = pr.ArRef,
                            ArDesign      = pr.ArDesign,
                            FaCodeFamille = famCode,
                            Total         = (int)items.Sum(x => x.LsQteRestant),
                            Depots        = depotList.Select(dep =>
                            {
                                var di = items.Where(x => x.DeNo == dep.DeNo).ToList();
                                return new ArticleDepotDetail
                                {
                                    DepotId   = dep.DeNo,
                                    DepotName = dep.DeIntitule,
                                    TotalQte  = (int)di.Sum(x => x.LsQteRestant),
                                    Lots      = di.Select(i => new ArticleLotDetail
                                    {
                                        Id                  = i.LsId,
                                        Lot                 = i.LsNoSerie,
                                        Quantite            = (int)i.LsQteRestant,
                                        DateExpiration      = i.LsPeremption,
                                        CriticalPeriodMonths = i.LsPeremption.HasValue
                                            ? (int)((i.LsPeremption.Value - today).TotalDays / 30)
                                            : 99
                                    }).OrderBy(l => l.DateExpiration).ToList()
                                };
                            }).ToList()
                        };
                    })
                    .ToList();

                return Ok(new ArticleStockPagedResponse
                {
                    Articles   = articles,
                    Depots     = depotList,
                    TotalCount = totalCount,
                    Page       = page,
                    PageSize   = pageSize
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ArticleStockController] ERROR: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // PUT api/ArticleStock/{id}/adjust/{delta}
        // ─────────────────────────────────────────────────────────────────────
        [HttpPut("{id}/adjust/{delta}")]
        public async Task<IActionResult> AdjustQuantity(int id, int delta)
        {
            if (_useMockData) return Ok(new { success = true });

            try
            {
                string sql = @"
                    UPDATE F_LOTSERIE
                    SET LS_QteRestant  = LS_QteRestant + @delta,
                        cbModification = GETDATE()
                    WHERE cbMarq = @id AND LS_QteRestant + @delta >= 0";

                int rows = await _context.Database.ExecuteSqlRawAsync(sql,
                    new Microsoft.Data.SqlClient.SqlParameter("@delta", (decimal)delta),
                    new Microsoft.Data.SqlClient.SqlParameter("@id", id));

                if (rows == 0) return NotFound();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    // ── DTOs ──────────────────────────────────────────────────────────────────

    public class ArticleStockFilterRequest
    {
        public List<string>? Familles { get; set; }
        public List<int>?    Depots   { get; set; }
        public string?       Search   { get; set; }   // ← NEW: server-side search
        public int           Page     { get; set; } = 1;
        public int           PageSize { get; set; } = 20;
    }

    public class DepotInfo
    {
        public int    DeNo       { get; set; }
        public string DeIntitule { get; set; } = "";
    }

    public class ArticleLotDetail
    {
        public int       Id                   { get; set; }
        public string    Lot                  { get; set; } = "";
        public int       Quantite             { get; set; }
        public DateTime? DateExpiration       { get; set; }
        public int       CriticalPeriodMonths { get; set; }
    }

    public class ArticleDepotDetail
    {
        public int                  DepotId   { get; set; }
        public string               DepotName { get; set; } = "";
        public int                  TotalQte  { get; set; }
        public List<ArticleLotDetail> Lots    { get; set; } = new();
    }

    public class ArticleStockRow
    {
        public string                   ArRef         { get; set; } = "";
        public string                   ArDesign      { get; set; } = "";
        public string                   FaCodeFamille { get; set; } = "";
        public int                      Total         { get; set; }
        public List<ArticleDepotDetail> Depots        { get; set; } = new();
    }

    // Old response kept for backward compat (unused by updated frontend)
    public class ArticleStockResponse
    {
        public List<ArticleStockRow> Articles { get; set; } = new();
        public List<DepotInfo>       Depots   { get; set; } = new();
    }

    // New paged response
    public class ArticleStockPagedResponse
    {
        public List<ArticleStockRow> Articles   { get; set; } = new();
        public List<DepotInfo>       Depots     { get; set; } = new();
        public int                   TotalCount { get; set; }
        public int                   Page       { get; set; }
        public int                   PageSize   { get; set; }
    }

    public class ArticleLotFlat
    {
        public int       LsId          { get; set; }
        public string    ArRef         { get; set; } = "";
        public string    ArDesign      { get; set; } = "";
        public string    FaCodeFamille { get; set; } = "";
        public int       DeNo          { get; set; }
        public string    LsNoSerie     { get; set; } = "";
        public DateTime? LsPeremption  { get; set; }
        public decimal   LsQteRestant  { get; set; }
    }
}
