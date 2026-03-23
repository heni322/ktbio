using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepotController : ControllerBase
    {
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;

        public DepotController(KTBioAPI.Data.KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetAll()
        {
            if (_useMockData)
            {
                return Ok(MockData.Depots);
            }

            var depots = await _context.FDepots
                .Select(d => new Depot
                {
                    deNo = d.DeNo ?? 0,
                    deIntitule = d.DeIntitule
                })
                .ToListAsync();
            return Ok(depots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetById(int id)
        {
            var d = await _context.FDepots.FirstOrDefaultAsync(d => d.DeNo == id);
            if (d == null)
                return NotFound();
            
            return Ok(new Depot
            {
                deNo = d.DeNo ?? 0,
                deIntitule = d.DeIntitule
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Depot depot)
        {
            if (_useMockData)
            {
                depot.deNo = MockData.Depots.Any() ? MockData.Depots.Max(d => d.deNo) + 1 : 1;
                MockData.Depots.Add(depot);
                return CreatedAtAction(nameof(GetById), new { id = depot.deNo }, depot);
            }
            return StatusCode(501, "Creation not supported on real database via this API yet.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Depot depot)
        {
            if (_useMockData)
            {
                var existing = MockData.Depots.FirstOrDefault(d => d.deNo == id);
                if (existing == null) return NotFound();
                existing.deIntitule = depot.deIntitule;
                return Ok(existing);
            }
            return StatusCode(501, "Update not supported on real database via this API yet.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_useMockData)
            {
                var existing = MockData.Depots.FirstOrDefault(d => d.deNo == id);
                if (existing == null) return NotFound();
                MockData.Depots.Remove(existing);
                return NoContent();
            }
            return StatusCode(501, "Delete not supported on real database via this API yet.");
        }
    }
}
