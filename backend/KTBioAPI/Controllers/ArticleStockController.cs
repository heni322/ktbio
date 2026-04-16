using KTBioAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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

                // ── 1. Depots ────────────────────────────────────────────────
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

                // ── 2. WHERE clauses ─────────────────────────────────────────
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
                    var safe = new string(request.Search
                        .Where(c => char.IsLetterOrDigit(c) || c == ' ' || c == '-' || c == '_' || c == '.')
                        .ToArray()).Trim();
                    if (!string.IsNullOrEmpty(safe))
                        whereClauses.Add(
                            $"(RTRIM(a.AR_Design) LIKE '%{safe}%' OR RTRIM(a.AR_Ref) LIKE '%{safe}%')");
                }

                var whereStr = "WHERE " + string.Join(" AND ", whereClauses);

                // ── 3. Count distinct articles ───────────────────────────────
                string countSql = $@"
                    SELECT COUNT(DISTINCT a.AR_Ref)
                    FROM dbo.F_ARTICLE a
                    INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                    INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                    {whereStr}";

                // ── 4. Page refs (OFFSET/FETCH) ──────────────────────────────
                // We expose LONGUEUR and DIAMETRE here so the page-ref ORDER is consistent
                // with how the table will be rendered (sorted by longueur, diametre, ref)
                string pageRefsSql = $@"
                    SELECT DISTINCT
                        a.AR_Ref,
                        RTRIM(a.AR_Design) AS AR_Design,
                        RTRIM(a.FA_CodeFamille) AS FA_CodeFamille,
                        -- AR_Ref suffix (normalised to 4 chars)
                        CASE
                            WHEN LEN(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 3
                             AND ISNUMERIC(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 1
                            THEN '0' + SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))
                            ELSE SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))
                        END AS AR_Ref_Suffixe,
                        -- LONGUEUR
                        CASE
                            WHEN LEN(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 4
                             AND ISNUMERIC(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 1
                            THEN CAST(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, 2) AS INT)
                            WHEN LEN(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 3
                             AND ISNUMERIC(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 1
                            THEN CAST(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, 1) AS INT)
                            ELSE NULL
                        END AS LONGUEUR,
                        -- DIAMETRE
                        CASE
                            WHEN LEN(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 4
                             AND ISNUMERIC(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 1
                            THEN CAST(
                                    SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 3, 1) + '.' +
                                    SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 4, 1)
                                 AS DECIMAL(5,1))
                            WHEN LEN(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 3
                             AND ISNUMERIC(SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 1, LEN(a.AR_Ref))) = 1
                            THEN CAST(
                                    SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 2, 1) + '.' +
                                    SUBSTRING(a.AR_Ref, CHARINDEX('-', a.AR_Ref) + 3, 1)
                                 AS DECIMAL(5,1))
                            ELSE NULL
                        END AS DIAMETRE
                    FROM dbo.F_ARTICLE a
                    INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                    INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                    {whereStr}
                    ORDER BY LONGUEUR, DIAMETRE, a.AR_Ref
                    OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                var pageRefs = new List<ArticleRefRow>();
                var flat     = new List<ArticleLotFlat>();
                int totalCount = 0;

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

                // Page refs + dimensions
                await using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = pageRefsSql;
                    await using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                    {
                        pageRefs.Add(new ArticleRefRow
                        {
                            ArRef         = rdr["AR_Ref"]?.ToString()?.Trim()         ?? "",
                            ArDesign      = rdr["AR_Design"]?.ToString()?.Trim()       ?? "",
                            FaCodeFamille = rdr["FA_CodeFamille"]?.ToString()?.Trim()  ?? "",
                            Longueur      = rdr["LONGUEUR"]      == DBNull.Value ? (int?)null    : Convert.ToInt32(rdr["LONGUEUR"]),
                            Diametre      = rdr["DIAMETRE"]      == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["DIAMETRE"]),
                            ArRefSuffixe  = rdr["AR_Ref_Suffixe"]?.ToString()?.Trim()  ?? "",
                        });
                    }
                }

                // Lot details for this page only
                if (pageRefs.Count > 0)
                {
                    var refList = string.Join("','",
                        pageRefs.Select(r => r.ArRef.Replace("'", "''")));

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
                            s.DE_No,
                            ls.LS_QteRestant,
                            ls.LS_NoSerie,
                            ls.LS_Peremption,
                            ls.cbMarq AS LsId
                        FROM dbo.F_ARTICLE a
                        INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                        INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                        WHERE {string.Join(" AND ", lotWhere)}
                        ORDER BY a.AR_Ref, ls.LS_Peremption";

                    await using var cmd = conn.CreateCommand();
                    cmd.CommandText = detailSql;
                    await using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                    {
                        flat.Add(new ArticleLotFlat
                        {
                            LsId         = rdr["LsId"]         == DBNull.Value ? 0  : Convert.ToInt32(rdr["LsId"]),
                            ArRef        = rdr["AR_Ref"]?.ToString()?.Trim()        ?? "",
                            DeNo         = rdr["DE_No"]         == DBNull.Value ? 0  : Convert.ToInt32(rdr["DE_No"]),
                            LsNoSerie    = rdr["LS_NoSerie"]?.ToString()?.Trim()    ?? "",
                            LsPeremption = rdr["LS_Peremption"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["LS_Peremption"]),
                            LsQteRestant = rdr["LS_QteRestant"] == DBNull.Value ? 0m : Convert.ToDecimal(rdr["LS_QteRestant"])
                        });
                    }
                }

                // ── 5. Build response, preserving page order ─────────────────
                var flatByRef = flat.GroupBy(x => x.ArRef).ToDictionary(g => g.Key);

                var articles = pageRefs.Select(pr =>
                {
                    var items = flatByRef.TryGetValue(pr.ArRef, out var g) ? g.ToList() : new List<ArticleLotFlat>();

                    return new ArticleStockRow
                    {
                        ArRef         = pr.ArRef,
                        ArDesign      = pr.ArDesign,
                        FaCodeFamille = pr.FaCodeFamille,
                        ArRefSuffixe  = pr.ArRefSuffixe,
                        Longueur      = pr.Longueur,
                        Diametre      = pr.Diametre,
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
                                    Id                   = i.LsId,
                                    Lot                  = i.LsNoSerie,
                                    Quantite             = (int)i.LsQteRestant,
                                    DateExpiration       = i.LsPeremption,
                                    CriticalPeriodMonths = i.LsPeremption.HasValue
                                        ? (int)((i.LsPeremption.Value - today).TotalDays / 30)
                                        : 99
                                }).OrderBy(l => l.DateExpiration).ToList()
                            };
                        }).ToList()
                    };
                }).ToList();

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
        public string?       Search   { get; set; }
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
        public int                    DepotId   { get; set; }
        public string                 DepotName { get; set; } = "";
        public int                    TotalQte  { get; set; }
        public List<ArticleLotDetail> Lots      { get; set; } = new();
    }

    public class ArticleStockRow
    {
        public string                   ArRef         { get; set; } = "";
        public string                   ArDesign      { get; set; } = "";
        public string                   FaCodeFamille { get; set; } = "";
        public string                   ArRefSuffixe  { get; set; } = "";   // ← NEW
        public int?                     Longueur      { get; set; }         // ← NEW  e.g. 20
        public decimal?                 Diametre      { get; set; }         // ← NEW  e.g. 3.5
        public int                      Total         { get; set; }
        public List<ArticleDepotDetail> Depots        { get; set; } = new();
    }

    public class ArticleStockResponse
    {
        public List<ArticleStockRow> Articles { get; set; } = new();
        public List<DepotInfo>       Depots   { get; set; } = new();
    }

    public class ArticleStockPagedResponse
    {
        public List<ArticleStockRow> Articles   { get; set; } = new();
        public List<DepotInfo>       Depots     { get; set; } = new();
        public int                   TotalCount { get; set; }
        public int                   Page       { get; set; }
        public int                   PageSize   { get; set; }
    }

    // Internal helper for page-ref query result
    internal class ArticleRefRow
    {
        public string   ArRef         { get; set; } = "";
        public string   ArDesign      { get; set; } = "";
        public string   FaCodeFamille { get; set; } = "";
        public string   ArRefSuffixe  { get; set; } = "";
        public int?     Longueur      { get; set; }
        public decimal? Diametre      { get; set; }
    }

    public class ArticleLotFlat
    {
        public int       LsId         { get; set; }
        public string    ArRef        { get; set; } = "";
        public string    ArDesign     { get; set; } = "";
        public string    FaCodeFamille{ get; set; } = "";
        public int       DeNo         { get; set; }
        public string    LsNoSerie    { get; set; } = "";
        public DateTime? LsPeremption { get; set; }
        public decimal   LsQteRestant { get; set; }
    }
}
