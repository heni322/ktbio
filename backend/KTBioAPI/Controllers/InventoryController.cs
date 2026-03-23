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
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;

        public InventoryController(KTBioAPI.Data.KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetAll()
        {
            // Simple redirect to a basic list if needed
            return Ok(new List<InventoryItem>());
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<InventoryGroupView>>> GetFiltered([FromBody] InventoryFilterRequest request)
        {
            if (_useMockData)
            {
                var todayDate = DateTime.Now;
                var mockItems = MockData.InventoryItems;

                // Apply filters if any
                if (request.Familles != null && request.Familles.Any())
                {
                    mockItems = mockItems.Where(i => request.Familles.Contains(i.CodeFamille)).ToList();
                }

                if (request.Depots != null && request.Depots.Any())
                {
                    mockItems = mockItems.Where(i => request.Depots.Contains(i.DepotId)).ToList();
                }

                if (!string.IsNullOrEmpty(request.SousFamille))
                {
                    mockItems = mockItems.Where(i => i.SousFamille == request.SousFamille).ToList();
                }

                string CleanString(string? s) {
                    if (string.IsNullOrWhiteSpace(s)) return "";
                    // Replace multiple spaces with single space, trim and uppercase
                    return System.Text.RegularExpressions.Regex.Replace(s.Trim(), @"\s+", " ").ToUpper();
                }

                var groupedMock = mockItems
                    .GroupBy(x => new { Name = CleanString(x.Designation), x.Longueur, x.Diametre })
                    .Select(g => {
                        var first = g.First();
                        return new InventoryGroupView
                        {
                            Longueur = first.Longueur,
                            Diametre = first.Diametre,
                            Depots = MockData.Depots
                                .Select(dep => new DepotInventory
                                {
                                    DepotId = dep.deNo,
                                    DepotName = dep.deIntitule,
                                    Items = g.Where(x => x.DepotId == dep.deNo)
                                        .GroupBy(x => new { 
                                            Name = CleanString(x.SousFamille), 
                                            Expiry = x.DateExpiration.HasValue ? new DateTime(x.DateExpiration.Value.Year, x.DateExpiration.Value.Month, 1) : (DateTime?)null 
                                        })
                                        .Select(ig => {
                                            var f = ig.First();
                                            return new InventoryDetail
                                            {
                                                Id = f.Id,
                                                SousFamille = f.SousFamille,
                                                Quantite = ig.Sum(x => x.Quantite),
                                                DateExpiration = f.DateExpiration,
                                                Lot = f.Lot,
                                                CriticalPeriodMonths = f.CriticalPeriodMonths
                                            };
                                        }).ToList()
                                })
                                .Where(d => d.Items.Any())
                                .ToList(),
                            Total = g.Sum(x => x.Quantite)
                        };
                    })
                    .OrderBy(x => x.Longueur)
                    .ThenBy(x => x.Diametre)
                    .ToList();

                return Ok(groupedMock);
            }

            try {
                var today = DateTime.Now;
                var list = new List<InventoryFlatItem>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    // ... (rest of the code matches)
                    string sql = @"
                        SELECT s.cbMarq as Id, RTRIM(a.AR_Ref) as ArRef, s.LS_NoSerie as LsNoSerie, s.LS_Peremption as LsPeremption, 
                                s.LS_QteRestant as LsQteRestant, s.DE_No as DeNo, 
                                a.AR_Design as ArDesign, a.FA_CodeFamille as FaCodeFamille, 
                                a.AR_Stat01 as ArStat01, a.AR_Stat02 as ArStat02
                        FROM F_LOTSERIE s
                        INNER JOIN F_ARTICLE a ON RTRIM(s.AR_Ref) = RTRIM(a.AR_Ref)
                        WHERE s.LS_QteRestant > 0";

                    if (request.Familles != null && request.Familles.Any())
            {
                var fcs = request.Familles.Select(f => f.Trim().Replace("'", "''")).ToList();
                var values = string.Join("','", fcs);
                sql += $" AND RTRIM(a.FA_CodeFamille) IN ('{values}')";
                Console.WriteLine($"Filtering by Families: {string.Join(", ", fcs)}");
            }

            if (request.Depots != null && request.Depots.Any())
            {
                var values = string.Join(",", request.Depots);
                sql += $" AND s.DE_No IN ({values})";
                Console.WriteLine($"Filtering by Depots: {values}");
            }

            command.CommandText = sql;
            if (_context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                await _context.Database.GetDbConnection().OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    list.Add(new InventoryFlatItem {
                        Id = Convert.ToInt32(reader["Id"]),
                        ArRef = reader["ArRef"]?.ToString()?.Trim() ?? "",
                        LsNoSerie = reader["LsNoSerie"]?.ToString()?.Trim() ?? "",
                        LsPeremption = reader["LsPeremption"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LsPeremption"]),
                        LsQteRestant = reader["LsQteRestant"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["LsQteRestant"]),
                        DeNo = reader["DeNo"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DeNo"]),
                        ArDesign = reader["ArDesign"]?.ToString()?.Trim() ?? "",
                        FaCodeFamille = reader["FaCodeFamille"]?.ToString()?.Trim() ?? "",
                        ArStat01 = reader["ArStat01"]?.ToString()?.Trim() ?? "",
                        ArStat02 = reader["ArStat02"]?.ToString()?.Trim() ?? ""
                    });
                }
            }
        }

        Console.WriteLine($"SQL Found {list.Count} records matching filters.");
        
        if (list.Count == 0) return Ok(new List<InventoryGroupView>());

        var allDepots = await _context.FDepots.ToListAsync();
        var depotMap = allDepots.ToDictionary(d => d.DeNo ?? 0, d => d.DeIntitule);

                decimal ParseDimension(string? input)
                {
                    if (string.IsNullOrEmpty(input)) return 0;
                    var cleaned = new string(input.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                    if (decimal.TryParse(cleaned.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal result))
                        return result;
                    return 0;
                }

                string CleanString(string? s) {
                    if (string.IsNullOrWhiteSpace(s)) return "";
                    return System.Text.RegularExpressions.Regex.Replace(s.Trim(), @"\s+", " ").ToUpper();
                }

                // 1. Process items to have clean dimensions and normalized names
                var processed = list.Select(x => {
                    decimal diam = ParseDimension(x.ArStat01);
                    decimal longu = ParseDimension(x.ArStat02);
                    string name = CleanString(x.ArDesign);

                    if ((diam == 0 || longu == 0) && !string.IsNullOrEmpty(name))
                    {
                        var matches = System.Text.RegularExpressions.Regex.Matches(name, @"(\d+[\.,]?\d*)");
                        if (matches.Count >= 2)
                        {
                            decimal v1 = ParseDimension(matches[0].Value);
                            decimal v2 = ParseDimension(matches[1].Value);
                            if (v1 < v2) {
                                if (diam == 0) diam = v1;
                                if (longu == 0) longu = v2;
                            } else {
                                if (diam == 0) diam = v2;
                                if (longu == 0) longu = v1;
                            }
                        }
                    }
                    return new { Item = x, Longueur = longu, Diametre = diam, Name = name };
                }).ToList();

                // 2. Group by Name and Dimensions
                var grouped = processed
                    .GroupBy(x => new { x.Name, x.Longueur, x.Diametre })
                    .Select(g => {
                        var articleDepots = g.GroupBy(x => x.Item.DeNo)
                            .Select(dg => new DepotInventory
                            {
                                DepotId = dg.Key,
                                DepotName = depotMap.ContainsKey(dg.Key) ? depotMap[dg.Key] : $"Dépôt {dg.Key}",
                                // Group by Name and the Month/Year of expiry since UI only cares about that
                                Items = dg.GroupBy(x => new { 
                                        x.Name, 
                                        ExpiryDate = x.Item.LsPeremption.HasValue 
                                            ? new DateTime(x.Item.LsPeremption.Value.Year, x.Item.LsPeremption.Value.Month, 1) 
                                            : (DateTime?)null 
                                    })
                                    .Select(ig => {
                                        var f = ig.First();
                                        return new InventoryDetail
                                        {
                                            Id = f.Item.Id,
                                            SousFamille = f.Name,
                                            Quantite = (int)ig.Sum(x => x.Item.LsQteRestant),
                                            DateExpiration = f.Item.LsPeremption,
                                            Lot = f.Item.LsNoSerie ?? "SANS LOT",
                                            CriticalPeriodMonths = f.Item.LsPeremption.HasValue 
                                                ? (int)((f.Item.LsPeremption.Value - today).TotalDays / 30)
                                                : 12
                                        };
                                    }).ToList()
                            })
                            .ToList();

                        return new InventoryGroupView
                        {
                            Longueur = g.Key.Longueur,
                            Diametre = g.Key.Diametre,
                            Depots = articleDepots.Where(d => d.Items.Any()).OrderBy(d => d.DepotId).ToList(),
                            Total = (int)g.Sum(x => x.Item.LsQteRestant)
                        };
                    })
                    .OrderBy(x => x.Longueur)
                    .ThenBy(x => x.Diametre)
                    .ToList();
                return Ok(grouped);
            } catch (Exception ex) {
                Console.WriteLine($"ERROR in GetFiltered: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("sousfamilles")]
        public async Task<ActionResult<IEnumerable<string>>> GetSousFamilles()
        {
            if (_useMockData)
            {
                var mockSf = MockData.SousFamilles.Select(s => s.nom).Distinct().OrderBy(s => s).ToList();
                return Ok(mockSf);
            }
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
            var years = new List<int> { 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };
            return Ok(years);
        }

        [HttpPut("{id}/quantity/{newQuantity}")]
        public async Task<IActionResult> UpdateQuantity(int id, int newQuantity)
        {
            Console.WriteLine($"[InventoryController] Updating quantity for ID {id} to {newQuantity}");
            
            if (_useMockData)
            {
                var item = MockData.InventoryItems.FirstOrDefault(i => i.Id == id);
                if (item == null) return NotFound();
                item.Quantite = newQuantity;
                return Ok(item);
            }

            try {
                // For Sage 100 SQL, direct SQL updates are often more reliable than EF change tracking 
                // when triggers call extended stored procedures (like xp_CBIsFileLock).
                string sql = "UPDATE F_LOTSERIE SET LS_QteRestant = @qty, cbModification = GETDATE() WHERE cbMarq = @id";
                
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, 
                    new Microsoft.Data.SqlClient.SqlParameter("@qty", (decimal)newQuantity),
                    new Microsoft.Data.SqlClient.SqlParameter("@id", id));

                if (rowsAffected == 0) {
                    Console.WriteLine($"[InventoryController] ID {id} NOT FOUND in F_LOTSERIE");
                    return NotFound($"Item {id} not found");
                }

                Console.WriteLine($"[InventoryController] ID {id} updated successfully via Raw SQL to {newQuantity}");
                return Ok(new { success = true, id = id, quantity = newQuantity });
            } catch (Exception ex) {
                var innerMsg = ex.InnerException?.Message ?? "";
                Console.WriteLine($"[InventoryController] ERROR: {ex.Message} {innerMsg}");
                return StatusCode(500, $"Erreur Base de données: {ex.Message} {innerMsg}");
            }
        }

        [HttpPut("{id}/adjust/{delta}")]
        public async Task<IActionResult> AdjustQuantity(int id, int delta)
        {
            Console.WriteLine($"[InventoryController] Adjusting quantity for ID {id} by {delta}");
            
            if (_useMockData)
            {
                var item = MockData.InventoryItems.FirstOrDefault(i => i.Id == id);
                if (item == null) return NotFound();
                item.Quantite += delta;
                if (item.Quantite < 0) item.Quantite = 0;
                return Ok(item);
            }

            try {
                string sql = "UPDATE F_LOTSERIE SET LS_QteRestant = LS_QteRestant + @delta, cbModification = GETDATE() WHERE cbMarq = @id AND LS_QteRestant + @delta >= 0";
                
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, 
                    new Microsoft.Data.SqlClient.SqlParameter("@delta", (decimal)delta),
                    new Microsoft.Data.SqlClient.SqlParameter("@id", id));

                if (rowsAffected == 0) return NotFound($"Item {id} not found or adjustment would result in negative quantity");

                return Ok(new { success = true, id = id, delta = delta });
            } catch (Exception ex) {
                var innerMsg = ex.InnerException?.Message ?? "";
                return StatusCode(500, $"Erreur Base de données: {ex.Message} {innerMsg}");
            }
        }
    }
    
    public class InventoryFlatItem
    {
        public int Id { get; set; }
        public string ArRef { get; set; } = "";
        public string LsNoSerie { get; set; } = "";
        public DateTime? LsPeremption { get; set; }
        public decimal LsQteRestant { get; set; }
        public int DeNo { get; set; }
        public string ArDesign { get; set; } = "";
        public string FaCodeFamille { get; set; } = "";
        public string ArStat01 { get; set; } = "";
        public string ArStat02 { get; set; } = "";
    }
}
