using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SousFamilleController : ControllerBase
    {
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;

        public SousFamilleController(KTBioAPI.Data.KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SousFamille>>> GetAll([FromQuery] string? familleCode = null)
        {
            if (_useMockData)
            {
                var mockSf = MockData.SousFamilles;
                if (!string.IsNullOrEmpty(familleCode))
                    mockSf = mockSf.Where(s => s.fCodeFFamille == familleCode).ToList();
                return Ok(mockSf);
            }

            var query = _context.FArticles.AsQueryable();
            
            if (!string.IsNullOrEmpty(familleCode))
                query = query.Where(a => a.FaCodeFamille == familleCode);

            var items = await query
                .GroupBy(a => new { a.FaCodeFamille, a.ArDesign })
                .Select(g => new SousFamille
                {
                    cbMarq = g.Min(a => a.CbMarq),
                    code = g.Key.ArDesign != null ? (g.Key.ArDesign.Length > 20 ? g.Key.ArDesign.Substring(0, 20) : g.Key.ArDesign) : "",
                    nom = g.Key.ArDesign ?? "SANS DESIGNATION",
                    fCodeFFamille = g.Key.FaCodeFamille
                })
                .OrderBy(s => s.nom)
                .ToListAsync();
            
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SousFamille>> GetById(int id)
        {
            var sf = await _context.FCatalogues.FirstOrDefaultAsync(s => s.CbMarq == id);
            if (sf == null)
                return NotFound();
            
            return Ok(new SousFamille
            {
                cbMarq = sf.CbMarq,
                code = sf.ClCode ?? "",
                nom = sf.ClIntitule,
                fCodeFFamille = ""
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] SousFamille sousFamille)
        {
            if (_useMockData)
            {
                sousFamille.cbMarq = MockData.SousFamilles.Any() ? MockData.SousFamilles.Max(s => s.cbMarq) + 1 : 1;
                MockData.SousFamilles.Add(sousFamille);
                return CreatedAtAction(nameof(GetById), new { id = sousFamille.cbMarq }, sousFamille);
            }
            return StatusCode(501, "Creation not supported on real database via this API yet.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SousFamille sousFamille)
        {
            if (_useMockData)
            {
                var existing = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                if (existing == null) return NotFound();
                existing.nom = sousFamille.nom;
                existing.code = sousFamille.code;
                existing.fCodeFFamille = sousFamille.fCodeFFamille;
                return Ok(existing);
            }
            return StatusCode(501, "Update not supported on real database via this API yet.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_useMockData)
            {
                var existing = MockData.SousFamilles.FirstOrDefault(s => s.cbMarq == id);
                if (existing == null) return NotFound();
                MockData.SousFamilles.Remove(existing);
                return NoContent();
            }
            return StatusCode(501, "Delete not supported on real database via this API yet.");
        }
    }
}
