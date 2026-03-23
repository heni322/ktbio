using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilleController : ControllerBase
    {
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;

        public FamilleController(KTBioAPI.Data.KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Famille>>> GetAll()
        {
            if (_useMockData)
            {
                return Ok(MockData.Familles);
            }

            var familles = await _context.FFamilles
                .Select(f => new Famille
                {
                    cbMarq = f.CbMarq,
                    faCodeFamille = f.FaCodeFamille.Trim(),
                    faIntitule = f.FaIntitule.Trim()
                })
                .ToListAsync();
            return Ok(familles);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Famille>> GetByCode(string code)
        {
            var f = await _context.FFamilles.FirstOrDefaultAsync(f => f.FaCodeFamille == code);
            if (f == null)
                return NotFound();
            
            return Ok(new Famille
            {
                cbMarq = f.CbMarq,
                faCodeFamille = f.FaCodeFamille,
                faIntitule = f.FaIntitule
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Famille famille)
        {
            if (_useMockData)
            {
                famille.cbMarq = MockData.Familles.Any() ? MockData.Familles.Max(f => f.cbMarq) + 1 : 1;
                MockData.Familles.Add(famille);
                return CreatedAtAction(nameof(GetByCode), new { code = famille.faCodeFamille }, famille);
            }
            return StatusCode(501, "Creation not supported on real database via this API yet.");
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] Famille famille)
        {
            if (_useMockData)
            {
                var existing = MockData.Familles.FirstOrDefault(f => f.faCodeFamille == code);
                if (existing == null) return NotFound();
                existing.faIntitule = famille.faIntitule;
                return Ok(existing);
            }
            return StatusCode(501, "Update not supported on real database via this API yet.");
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            if (_useMockData)
            {
                var existing = MockData.Familles.FirstOrDefault(f => f.faCodeFamille == code);
                if (existing == null) return NotFound();
                MockData.Familles.Remove(existing);
                return NoContent();
            }
            return StatusCode(501, "Delete not supported on real database via this API yet.");
        }
    }
}
