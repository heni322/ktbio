using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    /// <summary>
    /// Dépôts — lecture seule depuis dbo.F_DEPOT (Sage).
    /// La requête exécutée est :
    ///   SELECT DE_No, DE_Intitule FROM dbo.F_DEPOT
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepotController : ControllerBase
    {
        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public DepotController(KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        // GET api/Depot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetAll()
        {
            if (_useMockData)
                return Ok(MockData.Depots);

            // SELECT DE_No, DE_Intitule FROM dbo.F_DEPOT
            var depots = await _context.FDepots
                .Where(d => d.DeNo != null)
                .OrderBy(d => d.DeNo)
                .Select(d => new Depot
                {
                    deNo      = d.DeNo!.Value,
                    deIntitule = d.DeIntitule.Trim()
                })
                .ToListAsync();

            return Ok(depots);
        }

        // GET api/Depot/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Depot>> GetById(int id)
        {
            if (_useMockData)
            {
                var mock = MockData.Depots.FirstOrDefault(d => d.deNo == id);
                return mock is null ? NotFound() : Ok(mock);
            }

            var d = await _context.FDepots.FirstOrDefaultAsync(d => d.DeNo == id);
            if (d is null)
                return NotFound(new { error = "Dépôt non trouvé." });

            return Ok(new Depot { deNo = d.DeNo!.Value, deIntitule = d.DeIntitule.Trim() });
        }
    }
}
