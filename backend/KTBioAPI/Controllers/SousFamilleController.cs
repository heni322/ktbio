using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SousFamilleController : ControllerBase
    {
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;
        private readonly ILogger<SousFamilleController> _logger;

        public SousFamilleController(
            KTBioAPI.Data.KTBioContext context,
            IConfiguration configuration,
            ILogger<SousFamilleController> logger)
        {
            _context     = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
            _logger      = logger;
        }

        // ── GET api/SousFamille?page=1&pageSize=10&search=...&familleCode=... ─
        [HttpGet]
        public async Task<ActionResult<PagedResult<SousFamille>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] string? familleCode = null)
        {
            try
            {
                page     = Math.Max(1, page);
                pageSize = Math.Clamp(pageSize, 1, 500);

                if (_useMockData)
                {
                    var source = MockData.SousFamilles.AsEnumerable();

                    if (!string.IsNullOrEmpty(familleCode))
                        source = source.Where(s => s.fCodeFFamille == familleCode);

                    if (!string.IsNullOrWhiteSpace(search))
                        source = source.Where(s =>
                            s.nom.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                            s.code.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                            s.fCodeFFamille.Contains(search, StringComparison.OrdinalIgnoreCase));

                    var total = source.Count();
                    var items = source.OrderBy(s => s.nom).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    return Ok(new PagedResult<SousFamille> { Items = items, TotalCount = total, Page = page, PageSize = pageSize });
                }

                var query = _context.SousFamilles.AsQueryable();

                if (!string.IsNullOrEmpty(familleCode))
                    query = query.Where(s => s.fCodeFFamille == familleCode);

                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(s =>
                        s.nom.Contains(search) ||
                        s.code.Contains(search) ||
                        s.fCodeFFamille.Contains(search));

                var totalCount = await query.CountAsync();
                var pagedItems = await query
                    .OrderBy(s => s.nom)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(new PagedResult<SousFamille> { Items = pagedItems, TotalCount = totalCount, Page = page, PageSize = pageSize });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sous-familles");
                return StatusCode(500, new { error = "Erreur lors de la récupération des sous-familles" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SousFamille>> GetById(int id)
        {
            try
            {
                if (_useMockData)
                {
                    var mockSf = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                    if (mockSf == null) return NotFound(new { error = "Sous-famille non trouvée" });
                    return Ok(mockSf);
                }

                var sf = await _context.SousFamilles.FirstOrDefaultAsync(s => s.cbMarq == id);
                if (sf == null) return NotFound(new { error = "Sous-famille non trouvée" });
                return Ok(sf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sous-famille {Id}", id);
                return StatusCode(500, new { error = "Erreur lors de la récupération de la sous-famille" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create([FromBody] SousFamille sousFamille)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (_useMockData)
                {
                    sousFamille.cbMarq        = MockData.SousFamilles.Any() ? MockData.SousFamilles.Max(s => s.cbMarq) + 1 : 1;
                    sousFamille.dateCreation  = DateTime.Now;
                    MockData.SousFamilles.Add(sousFamille);
                    return CreatedAtAction(nameof(GetById), new { id = sousFamille.cbMarq }, sousFamille);
                }

                var existing = await _context.SousFamilles.FirstOrDefaultAsync(s => s.code == sousFamille.code);
                if (existing != null) return BadRequest(new { error = "Une sous-famille avec ce code existe déjà" });

                sousFamille.cbMarq       = _context.SousFamilles.Any() ? _context.SousFamilles.Max(s => s.cbMarq) + 1 : 1;
                sousFamille.dateCreation = DateTime.Now;
                _context.SousFamilles.Add(sousFamille);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = sousFamille.cbMarq }, sousFamille);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating sous-famille");
                return StatusCode(500, new { error = "Erreur lors de la création de la sous-famille", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Update(int id, [FromBody] SousFamille sousFamille)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (_useMockData)
                {
                    var existing = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                    if (existing == null) return NotFound(new { error = "Sous-famille non trouvée" });
                    existing.nom           = sousFamille.nom;
                    existing.code          = sousFamille.code;
                    existing.fCodeFFamille = sousFamille.fCodeFFamille;
                    return Ok(existing);
                }

                var existingSf = await _context.SousFamilles.FirstOrDefaultAsync(s => s.cbMarq == id);
                if (existingSf == null) return NotFound(new { error = "Sous-famille non trouvée" });

                existingSf.nom           = sousFamille.nom;
                existingSf.code          = sousFamille.code;
                existingSf.fCodeFFamille = sousFamille.fCodeFFamille;
                await _context.SaveChangesAsync();

                return Ok(existingSf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating sous-famille {Id}", id);
                return StatusCode(500, new { error = "Erreur lors de la mise à jour de la sous-famille", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_useMockData)
                {
                    var existing = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                    if (existing == null) return NotFound(new { error = "Sous-famille non trouvée" });
                    MockData.SousFamilles.Remove(existing);
                    return NoContent();
                }

                var existingSf = await _context.SousFamilles.FirstOrDefaultAsync(s => s.cbMarq == id);
                if (existingSf == null) return NotFound(new { error = "Sous-famille non trouvée" });

                _context.SousFamilles.Remove(existingSf);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return Conflict(new { error = "Impossible de supprimer cette sous-famille car elle est utilisée dans d'autres enregistrements" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting sous-famille {Id}", id);
                return StatusCode(500, new { error = "Erreur lors de la suppression de la sous-famille", details = ex.Message });
            }
        }
    }
}
