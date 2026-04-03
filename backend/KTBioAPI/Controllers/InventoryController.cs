using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public InventoryController(KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventoryItem>> GetAll()
        {
            return Ok(new List<InventoryItem>());
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<InventoryGroupView>>> GetFiltered(
            [FromBody] InventoryFilterRequest request)
        {
            if (_useMockData)
                return Ok(BuildMockGrouped(request));

            try
            {
                var today = DateTime.Now;

                // Load App_SousFamilles once — we need their nom to populate
                // InventoryDetail.SousFamille correctly.
                var sousFamillesLookup = await _context.SousFamilles
                    .ToDictionaryAsync(s => s.code.Trim(), s => s.nom.Trim());

                var list = await FetchFlatItemsAsync(request);

                Console.WriteLine($"[Inventory] SQL returned {list.Count} rows for filter.");

                if (list.Count == 0)
                    return Ok(new List<InventoryGroupView>());

                var grouped = BuildGrouped(list, today, sousFamillesLookup);
                return Ok(grouped);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Inventory] ERROR in GetFiltered: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Core SQL — fully parameterised.
        // Filters applied:
        //   - LS_QteRestant > 0                        (always)
        //   - FA_CodeFamille IN (...)                   (optional)
        //   - d.DE_No IN (...)                          (optional)
        //   - CodeSousFamille derived from AR_Ref = X   (optional)
        // ─────────────────────────────────────────────────────────────────────
        private async Task<List<InventoryFlatItem>> FetchFlatItemsAsync(InventoryFilterRequest request)
        {
            var parameters = new List<SqlParameter>();

            // CodeSousFamille is derived in SQL with the same logic as the reference query:
            //   CASE WHEN CHARINDEX('-', AR_Ref) > 0
            //        THEN LEFT(AR_Ref, CHARINDEX('-', AR_Ref) - 1)
            //        ELSE RTRIM(AR_Ref)
            //   END
            var sql = @"
                SELECT
                    s.cbMarq                                                        AS Id,
                    RTRIM(a.AR_Ref)                                                 AS ArRef,
                    ISNULL(a.AR_Design, '')                                         AS ArDesign,
                    a.AR_SuiviStock                                                 AS ArSuiviStock,
                    ast.DE_No                                                       AS DeNo,
                    ISNULL(d.DE_Intitule, '')                                       AS DeIntitule,
                    s.LS_Qte                                                        AS LsQte,
                    s.LS_QteRestant                                                 AS LsQteRestant,
                    ISNULL(s.LS_NoSerie, '')                                        AS LsNoSerie,
                    s.LS_Peremption                                                 AS LsPeremption,
                    RTRIM(ISNULL(a.FA_CodeFamille,''))                              AS FaCodeFamille,
                    ISNULL(a.AR_Stat01, '')                                         AS ArStat01,
                    ISNULL(a.AR_Stat02, '')                                         AS ArStat02,
                    CASE
                        WHEN CHARINDEX('-', RTRIM(a.AR_Ref)) > 0
                        THEN LEFT(RTRIM(a.AR_Ref), CHARINDEX('-', RTRIM(a.AR_Ref)) - 1)
                        ELSE RTRIM(a.AR_Ref)
                    END                                                             AS CodeSousFamille
                FROM dbo.F_ARTICLE  a
                INNER JOIN dbo.F_ARTSTOCK ast ON RTRIM(a.AR_Ref) = RTRIM(ast.AR_Ref)
                INNER JOIN dbo.F_LOTSERIE s   ON RTRIM(a.AR_Ref) = RTRIM(s.AR_Ref)
                                              AND s.DE_No = ast.DE_No
                INNER JOIN dbo.F_DEPOT    d   ON ast.DE_No = d.DE_No
                WHERE s.LS_QteRestant > 0";

            // ── Famille filter ──────────────────────────────────────────────
            if (request.Familles?.Count > 0)
            {
                var pNames = request.Familles.Select((_, i) => $"@fam{i}").ToList();
                sql += $" AND RTRIM(a.FA_CodeFamille) IN ({string.Join(",", pNames)})";
                for (int i = 0; i < request.Familles.Count; i++)
                    parameters.Add(new SqlParameter($"@fam{i}", request.Familles[i].Trim()));

                Console.WriteLine($"[Inventory] Famille filter: {string.Join(", ", request.Familles)}");
            }

            // ── Depot filter ────────────────────────────────────────────────
            if (request.Depots?.Count > 0)
            {
                var pNames = request.Depots.Select((_, i) => $"@dep{i}").ToList();
                sql += $" AND d.DE_No IN ({string.Join(",", pNames)})";
                for (int i = 0; i < request.Depots.Count; i++)
                    parameters.Add(new SqlParameter($"@dep{i}", request.Depots[i]));

                Console.WriteLine($"[Inventory] Depot filter: {string.Join(", ", request.Depots)}");
            }

            // ── Sous-famille code filter ─────────────────────────────────────
            // Matches articles whose AR_Ref prefix (before the first '-') equals the
            // requested code, e.g. CodeSousFamille = "39113" matches "39113-1225",
            // "39113-0826", and plain "39113".
            // Note: SQL Server cannot reference a SELECT alias in the same WHERE clause,
            // so the CASE expression is repeated here.
            if (!string.IsNullOrWhiteSpace(request.CodeSousFamille))
            {
                sql += @"
                    AND CASE
                            WHEN CHARINDEX('-', RTRIM(a.AR_Ref)) > 0
                            THEN LEFT(RTRIM(a.AR_Ref), CHARINDEX('-', RTRIM(a.AR_Ref)) - 1)
                            ELSE RTRIM(a.AR_Ref)
                        END = @codeSousFamille";
                parameters.Add(new SqlParameter("@codeSousFamille", request.CodeSousFamille.Trim()));
                Console.WriteLine($"[Inventory] CodeSousFamille filter: {request.CodeSousFamille.Trim()}");
            }

            var list = new List<InventoryFlatItem>();
            var conn = _context.Database.GetDbConnection();

            using var command = conn.CreateCommand();
            command.CommandText = sql;
            foreach (var p in parameters)
                command.Parameters.Add(p);

            if (conn.State != System.Data.ConnectionState.Open)
                await conn.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new InventoryFlatItem
                {
                    Id              = Convert.ToInt32(reader["Id"]),
                    ArRef           = reader["ArRef"]?.ToString()?.Trim()           ?? "",
                    ArDesign        = reader["ArDesign"]?.ToString()?.Trim()        ?? "",
                    ArSuiviStock    = reader["ArSuiviStock"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ArSuiviStock"]),
                    DeNo            = reader["DeNo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DeNo"]),
                    DeIntitule      = reader["DeIntitule"]?.ToString()?.Trim()      ?? "",
                    LsQte           = reader["LsQte"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["LsQte"]),
                    LsQteRestant    = reader["LsQteRestant"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["LsQteRestant"]),
                    LsNoSerie       = reader["LsNoSerie"]?.ToString()?.Trim()       ?? "",
                    LsPeremption    = reader["LsPeremption"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LsPeremption"]),
                    FaCodeFamille   = reader["FaCodeFamille"]?.ToString()?.Trim()   ?? "",
                    ArStat01        = reader["ArStat01"]?.ToString()?.Trim()        ?? "",
                    ArStat02        = reader["ArStat02"]?.ToString()?.Trim()        ?? "",
                    CodeSousFamille = reader["CodeSousFamille"]?.ToString()?.Trim() ?? "",
                });
            }

            return list;
        }

        // ── Grouping ──────────────────────────────────────────────────────────
        //
        // FIX: BuildGrouped now receives the App_SousFamilles lookup so it can
        // correctly populate InventoryDetail.SousFamille with the human-readable
        // "nom" from App_SousFamilles (keyed by CodeSousFamille = AR_Ref prefix).
        //
        // Previously SousFamille was set to `f.Name` (the article designation),
        // which made the client-side "Sous Famille" dropdown filter completely
        // broken — comparing a designation string against App_SousFamilles names
        // always returned 0 matches.
        private static List<InventoryGroupView> BuildGrouped(
            List<InventoryFlatItem> list,
            DateTime today,
            Dictionary<string, string> sousFamillesLookup)
        {
            var processed = list.Select(x =>
            {
                decimal diam  = ParseDimension(x.ArStat01);
                decimal longu = ParseDimension(x.ArStat02);
                string  name  = CleanString(x.ArDesign);

                if ((diam == 0 || longu == 0) && !string.IsNullOrEmpty(name))
                {
                    var matches = System.Text.RegularExpressions.Regex
                        .Matches(name, @"(\d+[\.,]?\d*)");
                    if (matches.Count >= 2)
                    {
                        decimal v1 = ParseDimension(matches[0].Value);
                        decimal v2 = ParseDimension(matches[1].Value);
                        if (v1 < v2) { if (diam == 0) diam = v1; if (longu == 0) longu = v2; }
                        else         { if (diam == 0) diam = v2; if (longu == 0) longu = v1; }
                    }
                }

                // Resolve the human-readable sous-famille name from App_SousFamilles.
                // CodeSousFamille = LEFT(AR_Ref, CHARINDEX('-', AR_Ref) - 1)
                // e.g. "39113" → App_SousFamilles lookup → "XD"
                // Fall back to CodeSousFamille itself if no mapping is found.
                string sfNom = !string.IsNullOrEmpty(x.CodeSousFamille) &&
                               sousFamillesLookup.TryGetValue(x.CodeSousFamille, out var resolved)
                    ? resolved
                    : x.CodeSousFamille;

                return new { Item = x, Longueur = longu, Diametre = diam, Name = name, SousFamilleNom = sfNom };
            }).ToList();

            return processed
                .GroupBy(x => new { x.Name, x.Longueur, x.Diametre })
                .Select(g =>
                {
                    var articleDepots = g
                        .GroupBy(x => new { x.Item.DeNo, x.Item.DeIntitule })
                        .Select(dg => new DepotInventory
                        {
                            DepotId   = dg.Key.DeNo,
                            DepotName = dg.Key.DeIntitule,
                            Items = dg
                                .GroupBy(x => new
                                {
                                    // FIX: group by the real sous-famille nom + expiry month,
                                    // not by the article designation (Name).
                                    SousFamille = x.SousFamilleNom,
                                    ExpiryMonth = x.Item.LsPeremption.HasValue
                                        ? new DateTime(x.Item.LsPeremption.Value.Year,
                                                       x.Item.LsPeremption.Value.Month, 1)
                                        : (DateTime?)null
                                })
                                .Select(ig =>
                                {
                                    var f = ig.First();
                                    int monthsLeft = f.Item.LsPeremption.HasValue
                                        ? (int)((f.Item.LsPeremption.Value - today).TotalDays / 30)
                                        : 99;
                                    return new InventoryDetail
                                    {
                                        Id                   = f.Item.Id,
                                        // FIX: use the resolved sous-famille nom, not f.Name
                                        SousFamille          = f.SousFamilleNom,
                                        Quantite             = (int)ig.Sum(x => x.Item.LsQteRestant),
                                        DateExpiration       = f.Item.LsPeremption,
                                        Lot                  = string.IsNullOrEmpty(f.Item.LsNoSerie)
                                                                   ? "SANS LOT"
                                                                   : f.Item.LsNoSerie,
                                        CriticalPeriodMonths = monthsLeft
                                    };
                                })
                                .OrderBy(i => i.DateExpiration ?? DateTime.MaxValue)
                                .ToList()
                        })
                        .Where(d => d.Items.Count > 0)
                        .OrderBy(d => d.DepotId)
                        .ToList();

                    return new InventoryGroupView
                    {
                        Longueur = g.Key.Longueur,
                        Diametre = g.Key.Diametre,
                        Depots   = articleDepots,
                        Total    = (int)g.Sum(x => x.Item.LsQteRestant)
                    };
                })
                .OrderBy(x => x.Longueur)
                .ThenBy(x => x.Diametre)
                .ToList();
        }

        // ── Mock data path ────────────────────────────────────────────────────
        private static List<InventoryGroupView> BuildMockGrouped(InventoryFilterRequest request)
        {
            var mockItems = MockData.InventoryItems.AsEnumerable();

            if (request.Familles?.Count > 0)
                mockItems = mockItems.Where(i => request.Familles.Contains(i.CodeFamille));

            if (request.Depots?.Count > 0)
                mockItems = mockItems.Where(i => request.Depots.Contains(i.DepotId));

            // CodeSousFamille: match the prefix extracted from ReferenceArticle
            // (mirrors the DB CASE/CHARINDEX logic exactly)
            if (!string.IsNullOrWhiteSpace(request.CodeSousFamille))
            {
                var code = request.CodeSousFamille.Trim();
                mockItems = mockItems.Where(i =>
                {
                    var dash   = i.ReferenceArticle.IndexOf('-');
                    var prefix = dash > 0 ? i.ReferenceArticle[..dash] : i.ReferenceArticle;
                    return string.Equals(prefix, code, StringComparison.OrdinalIgnoreCase);
                });
            }

            // Legacy name-based filter — also support filtering by SousFamille.nom
            if (!string.IsNullOrEmpty(request.SousFamille))
                mockItems = mockItems.Where(i => i.SousFamille == request.SousFamille);

            return mockItems
                .GroupBy(x => new { Name = CleanString(x.Designation), x.Longueur, x.Diametre })
                .Select(g =>
                {
                    var first = g.First();
                    return new InventoryGroupView
                    {
                        Longueur = first.Longueur,
                        Diametre = first.Diametre,
                        Depots = MockData.Depots
                            .Select(dep => new DepotInventory
                            {
                                DepotId   = dep.deNo,
                                DepotName = dep.deIntitule,
                                Items = g.Where(x => x.DepotId == dep.deNo)
                                    .GroupBy(x => new
                                    {
                                        // Group by the actual SousFamille name + expiry month
                                        SousFamille = x.SousFamille,
                                        Expiry = x.DateExpiration.HasValue
                                            ? new DateTime(x.DateExpiration.Value.Year,
                                                           x.DateExpiration.Value.Month, 1)
                                            : (DateTime?)null
                                    })
                                    .Select(ig =>
                                    {
                                        var f = ig.First();
                                        return new InventoryDetail
                                        {
                                            Id                   = f.Id,
                                            SousFamille          = f.SousFamille,
                                            Quantite             = ig.Sum(x => x.Quantite),
                                            DateExpiration       = f.DateExpiration,
                                            Lot                  = f.Lot,
                                            CriticalPeriodMonths = f.CriticalPeriodMonths
                                        };
                                    })
                                    .OrderBy(i => i.DateExpiration ?? DateTime.MaxValue)
                                    .ToList()
                            })
                            .Where(d => d.Items.Count > 0)
                            .ToList(),
                        Total = g.Sum(x => x.Quantite)
                    };
                })
                .OrderBy(x => x.Longueur)
                .ThenBy(x => x.Diametre)
                .ToList();
        }

        // ── Utilities ─────────────────────────────────────────────────────────

        private static decimal ParseDimension(string? input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var cleaned = new string(input.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            return decimal.TryParse(
                cleaned.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal result) ? result : 0;
        }

        private static string CleanString(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";
            return System.Text.RegularExpressions.Regex
                .Replace(s.Trim(), @"\s+", " ")
                .ToUpper();
        }

        // ── Other endpoints ───────────────────────────────────────────────────

        [HttpGet("sousfamilles")]
        public async Task<ActionResult<IEnumerable<string>>> GetSousFamilles()
        {
            if (_useMockData)
                return Ok(MockData.SousFamilles.Select(s => s.nom).Distinct().OrderBy(s => s).ToList());

            var sf = await _context.FArticles
                .Where(a => a.ArDesign != null)
                .Select(a => a.ArDesign!)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();
            return Ok(sf);
        }

        [HttpGet("annees")]
        public ActionResult<IEnumerable<int>> GetAnnees()
        {
            return Ok(new List<int> { 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 });
        }

        [HttpPut("{id}/quantity/{newQuantity}")]
        public async Task<IActionResult> UpdateQuantity(int id, int newQuantity)
        {
            Console.WriteLine($"[Inventory] UpdateQuantity id={id} newQty={newQuantity}");
            if (_useMockData)
            {
                var mock = MockData.InventoryItems.FirstOrDefault(i => i.Id == id);
                if (mock == null) return NotFound();
                mock.Quantite = newQuantity;
                return Ok(mock);
            }
            try
            {
                const string sql = @"
                    UPDATE dbo.F_LOTSERIE
                    SET LS_QteRestant = @qty, cbModification = GETDATE()
                    WHERE cbMarq = @id";
                int rows = await _context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@qty", (decimal)newQuantity),
                    new SqlParameter("@id", id));
                if (rows == 0) return NotFound($"Item {id} not found");
                return Ok(new { success = true, id, quantity = newQuantity });
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? "";
                Console.WriteLine($"[Inventory] UpdateQuantity ERROR: {ex.Message} {inner}");
                return StatusCode(500, $"Erreur Base de données: {ex.Message} {inner}");
            }
        }

        [HttpPut("{id}/adjust/{delta}")]
        public async Task<IActionResult> AdjustQuantity(int id, int delta)
        {
            Console.WriteLine($"[Inventory] AdjustQuantity id={id} delta={delta}");
            if (_useMockData)
            {
                var mock = MockData.InventoryItems.FirstOrDefault(i => i.Id == id);
                if (mock == null) return NotFound();
                mock.Quantite = Math.Max(0, mock.Quantite + delta);
                return Ok(mock);
            }
            try
            {
                const string sql = @"
                    UPDATE dbo.F_LOTSERIE
                    SET LS_QteRestant = LS_QteRestant + @delta, cbModification = GETDATE()
                    WHERE cbMarq = @id AND LS_QteRestant + @delta >= 0";
                int rows = await _context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@delta", (decimal)delta),
                    new SqlParameter("@id", id));
                if (rows == 0)
                    return NotFound($"Item {id} not found or result would be negative");
                return Ok(new { success = true, id, delta });
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? "";
                return StatusCode(500, $"Erreur Base de données: {ex.Message} {inner}");
            }
        }
    }

    // ── Flat row DTO ──────────────────────────────────────────────────────────
    public class InventoryFlatItem
    {
        public int       Id              { get; set; }
        public string    ArRef           { get; set; } = "";
        public string    ArDesign        { get; set; } = "";
        public int       ArSuiviStock    { get; set; }
        public int       DeNo            { get; set; }
        public string    DeIntitule      { get; set; } = "";
        public decimal   LsQte           { get; set; }
        public decimal   LsQteRestant    { get; set; }
        public string    LsNoSerie       { get; set; } = "";
        public DateTime? LsPeremption    { get; set; }
        public string    FaCodeFamille   { get; set; } = "";
        public string    ArStat01        { get; set; } = "";
        public string    ArStat02        { get; set; } = "";

        /// <summary>
        /// LEFT(AR_Ref, CHARINDEX('-', AR_Ref) - 1) — computed by SQL.
        /// e.g. "39113" from "39113-1225".
        /// </summary>
        public string    CodeSousFamille { get; set; } = "";
    }
}
