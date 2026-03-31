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

        // POST api/ArticleStock/filter
        // Body: { familles: ["CARD01",...], depots: [1,2,...] }
        [HttpPost("filter")]
        public async Task<ActionResult<ArticleStockResponse>> GetFiltered([FromBody] ArticleStockFilterRequest request)
        {
            if (_useMockData)
            {
                // Return empty mock for now
                return Ok(new ArticleStockResponse { Articles = new List<ArticleStockRow>(), Depots = new List<DepotInfo>() });
            }

            try
            {
                var today = DateTime.Now;

                // 1. Load depots
                var allDepots = await _context.FDepots.ToListAsync();
                List<DepotInfo> depotList;
                if (request.Depots != null && request.Depots.Any())
                    depotList = allDepots
                        .Where(d => request.Depots.Contains(d.DeNo ?? 0))
                        .Select(d => new DepotInfo { DeNo = d.DeNo ?? 0, DeIntitule = d.DeIntitule ?? "" })
                        .OrderBy(d => d.DeNo)
                        .ToList();
                else
                    depotList = allDepots
                        .Select(d => new DepotInfo { DeNo = d.DeNo ?? 0, DeIntitule = d.DeIntitule ?? "" })
                        .OrderBy(d => d.DeNo)
                        .ToList();

                // 2. Build SQL using the native query from the user
                string sql = @"
                    SELECT
                        a.AR_Ref,
                        RTRIM(a.AR_Design) AS AR_Design,
                        a.FA_CodeFamille,
                        s.DE_No,
                        ls.LS_Qte,
                        ls.LS_NoSerie,
                        ls.LS_Peremption,
                        ls.cbMarq AS LsId,
                        ls.LS_QteRestant
                    FROM dbo.F_ARTICLE a
                    INNER JOIN dbo.F_ARTSTOCK s  ON a.AR_Ref = s.AR_Ref
                    INNER JOIN dbo.F_LOTSERIE ls ON a.AR_Ref = ls.AR_Ref AND s.DE_No = ls.DE_No
                    WHERE ls.LS_QteRestant > 0";

                if (request.Familles != null && request.Familles.Any())
                {
                    var values = string.Join("','", request.Familles.Select(f => f.Trim().Replace("'", "''")));
                    sql += $" AND RTRIM(a.FA_CodeFamille) IN ('{values}')";
                }

                if (request.Depots != null && request.Depots.Any())
                {
                    var values = string.Join(",", request.Depots);
                    sql += $" AND s.DE_No IN ({values})";
                }

                sql += " ORDER BY a.AR_Design, ls.LS_Peremption";

                var flat = new List<ArticleLotFlat>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    if (_context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                        await _context.Database.GetDbConnection().OpenAsync();

                    using var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        flat.Add(new ArticleLotFlat
                        {
                            LsId = reader["LsId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["LsId"]),
                            ArRef = reader["AR_Ref"]?.ToString()?.Trim() ?? "",
                            ArDesign = reader["AR_Design"]?.ToString()?.Trim() ?? "",
                            FaCodeFamille = reader["FA_CodeFamille"]?.ToString()?.Trim() ?? "",
                            DeNo = reader["DE_No"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DE_No"]),
                            LsNoSerie = reader["LS_NoSerie"]?.ToString()?.Trim() ?? "",
                            LsPeremption = reader["LS_Peremption"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LS_Peremption"]),
                            LsQteRestant = reader["LS_QteRestant"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["LS_QteRestant"])
                        });
                    }
                }

                // 3. Group by article
                var grouped = flat
                    .GroupBy(x => new { x.ArRef, x.ArDesign, x.FaCodeFamille })
                    .Select(g =>
                    {
                        var row = new ArticleStockRow
                        {
                            ArRef = g.Key.ArRef,
                            ArDesign = g.Key.ArDesign,
                            FaCodeFamille = g.Key.FaCodeFamille,
                            Total = (int)g.Sum(x => x.LsQteRestant),
                            Depots = depotList.Select(dep =>
                            {
                                var depItems = g.Where(x => x.DeNo == dep.DeNo).ToList();
                                return new ArticleDepotDetail
                                {
                                    DepotId = dep.DeNo,
                                    DepotName = dep.DeIntitule,
                                    TotalQte = (int)depItems.Sum(x => x.LsQteRestant),
                                    Lots = depItems.Select(i => new ArticleLotDetail
                                    {
                                        Id = i.LsId,
                                        Lot = i.LsNoSerie,
                                        Quantite = (int)i.LsQteRestant,
                                        DateExpiration = i.LsPeremption,
                                        CriticalPeriodMonths = i.LsPeremption.HasValue
                                            ? (int)((i.LsPeremption.Value - today).TotalDays / 30)
                                            : 99
                                    }).OrderBy(l => l.DateExpiration).ToList()
                                };
                            }).ToList()
                        };
                        return row;
                    })
                    .OrderBy(r => r.ArDesign)
                    .ToList();

                return Ok(new ArticleStockResponse { Articles = grouped, Depots = depotList });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ArticleStockController] ERROR: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}/adjust/{delta}")]
        public async Task<IActionResult> AdjustQuantity(int id, int delta)
        {
            if (_useMockData) return Ok(new { success = true });

            try
            {
                string sql = "UPDATE F_LOTSERIE SET LS_QteRestant = LS_QteRestant + @delta, cbModification = GETDATE() WHERE cbMarq = @id AND LS_QteRestant + @delta >= 0";
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
        public List<int>? Depots { get; set; }
    }

    public class DepotInfo
    {
        public int DeNo { get; set; }
        public string DeIntitule { get; set; } = "";
    }

    public class ArticleLotDetail
    {
        public int Id { get; set; }
        public string Lot { get; set; } = "";
        public int Quantite { get; set; }
        public DateTime? DateExpiration { get; set; }
        public int CriticalPeriodMonths { get; set; }
    }

    public class ArticleDepotDetail
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; } = "";
        public int TotalQte { get; set; }
        public List<ArticleLotDetail> Lots { get; set; } = new();
    }

    public class ArticleStockRow
    {
        public string ArRef { get; set; } = "";
        public string ArDesign { get; set; } = "";
        public string FaCodeFamille { get; set; } = "";
        public int Total { get; set; }
        public List<ArticleDepotDetail> Depots { get; set; } = new();
    }

    public class ArticleStockResponse
    {
        public List<ArticleStockRow> Articles { get; set; } = new();
        public List<DepotInfo> Depots { get; set; } = new();
    }

    public class ArticleLotFlat
    {
        public int LsId { get; set; }
        public string ArRef { get; set; } = "";
        public string ArDesign { get; set; } = "";
        public string FaCodeFamille { get; set; } = "";
        public int DeNo { get; set; }
        public string LsNoSerie { get; set; } = "";
        public DateTime? LsPeremption { get; set; }
        public decimal LsQteRestant { get; set; }
    }
}
