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
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SousFamille>>> GetAll([FromQuery] string? familleCode = null)
        {
            try
            {
                if (_useMockData)
                {
                    var mockSf = MockData.SousFamilles;
                    if (!string.IsNullOrEmpty(familleCode))
                        mockSf = mockSf.Where(s => s.fCodeFFamille == familleCode).ToList();
                    return Ok(mockSf);
                }

                // Use App_SousFamilles table instead
                var query = _context.SousFamilles.AsQueryable();
                
                if (!string.IsNullOrEmpty(familleCode))
                {
                    query = query.Where(s => s.fCodeFFamille == familleCode);
                }

                var items = await query.OrderBy(s => s.nom).ToListAsync();
                
                return Ok(items);
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
                if (sf == null)
                    return NotFound(new { error = "Sous-famille non trouvée" });
                
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (_useMockData)
                {
                    sousFamille.cbMarq = MockData.SousFamilles.Any() ? MockData.SousFamilles.Max(s => s.cbMarq) + 1 : 1;
                    sousFamille.dateCreation = DateTime.Now;
                    MockData.SousFamilles.Add(sousFamille);
                    return CreatedAtAction(nameof(GetById), new { id = sousFamille.cbMarq }, sousFamille);
                }

                // Check if already exists
                var existing = await _context.SousFamilles
                    .FirstOrDefaultAsync(s => s.code == sousFamille.code);

                if (existing != null)
                {
                    return BadRequest(new { error = "Une sous-famille avec ce code existe déjà" });
                }

                // Generate new ID
                sousFamille.cbMarq = _context.SousFamilles.Any() ? _context.SousFamilles.Max(s => s.cbMarq) + 1 : 1;
                sousFamille.dateCreation = DateTime.Now;

                _context.SousFamilles.Add(sousFamille);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Sous-famille {Code} created successfully", sousFamille.code);

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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (_useMockData)
                {
                    var existing = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                    if (existing == null) return NotFound(new { error = "Sous-famille non trouvée" });
                    existing.nom = sousFamille.nom;
                    existing.code = sousFamille.code;
                    existing.fCodeFFamille = sousFamille.fCodeFFamille;
                    return Ok(existing);
                }

                var existingSousFamille = await _context.SousFamilles.FirstOrDefaultAsync(s => s.cbMarq == id);
                if (existingSousFamille == null)
                {
                    return NotFound(new { error = "Sous-famille non trouvée" });
                }

                existingSousFamille.nom = sousFamille.nom;
                existingSousFamille.code = sousFamille.code;
                existingSousFamille.fCodeFFamille = sousFamille.fCodeFFamille;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Sous-famille {Id} updated successfully", id);

                return Ok(existingSousFamille);
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

                var existingSousFamille = await _context.SousFamilles.FirstOrDefaultAsync(s => s.cbMarq == id);
                if (existingSousFamille == null)
                {
                    return NotFound(new { error = "Sous-famille non trouvée" });
                }

                _context.SousFamilles.Remove(existingSousFamille);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Sous-famille {Id} deleted successfully", id);

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
