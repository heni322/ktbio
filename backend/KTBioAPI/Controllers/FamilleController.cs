using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    [ApiController]
    [Route("api/[controller]")]
    public class FamilleController : ControllerBase
    {
        private static readonly string[] AllowedCodes =
            { "CARD01", "CARD02", "CARD03", "CARD29", "CARD30" };

        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public FamilleController(KTBioContext context, IConfiguration configuration)
        {
            _context     = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        // ── GET api/Famille?page=1&pageSize=10&search=... ────────────────────
        [HttpGet]
        public async Task<ActionResult<PagedResult<Famille>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null)
        {
            page     = Math.Max(1, page);
            pageSize = Math.Clamp(pageSize, 1, 100);

            if (_useMockData)
            {
                var source = MockData.Familles.AsEnumerable();
                if (!string.IsNullOrWhiteSpace(search))
                    source = source.Where(f =>
                        f.faCodeFamille.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        f.faIntitule.Contains(search, StringComparison.OrdinalIgnoreCase));

                var total  = source.Count();
                var items  = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Ok(new PagedResult<Famille> { Items = items, TotalCount = total, Page = page, PageSize = pageSize });
            }

            var query = _context.FFamilles
                .Where(f => AllowedCodes.Contains(f.FaCodeFamille.Trim()))
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(f =>
                    f.FaCodeFamille.Contains(search) ||
                    f.FaIntitule.Contains(search));

            var totalCount = await query.CountAsync();
            var pagedItems = await query
                .OrderBy(f => f.FaCodeFamille)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new Famille
                {
                    cbMarq        = f.CbMarq,
                    faCodeFamille = f.FaCodeFamille.Trim(),
                    faIntitule    = f.FaIntitule.Trim()
                })
                .ToListAsync();

            return Ok(new PagedResult<Famille> { Items = pagedItems, TotalCount = totalCount, Page = page, PageSize = pageSize });
        }

        // ── GET api/Famille/{code} ───────────────────────────────────────────
        [HttpGet("{code}")]
        public async Task<ActionResult<Famille>> GetByCode(string code)
        {
            if (_useMockData)
            {
                var mock = MockData.Familles.FirstOrDefault(f => f.faCodeFamille == code);
                return mock is null ? NotFound() : Ok(mock);
            }

            if (!AllowedCodes.Contains(code.Trim().ToUpper()))
                return NotFound(new { error = "Famille non autorisée ou non trouvée." });

            var f = await _context.FFamilles.FirstOrDefaultAsync(f => f.FaCodeFamille.Trim() == code.Trim());
            if (f is null) return NotFound(new { error = "Famille non trouvée dans Sage." });

            return Ok(new Famille { cbMarq = f.CbMarq, faCodeFamille = f.FaCodeFamille.Trim(), faIntitule = f.FaIntitule.Trim() });
        }

        // ── POST api/Famille ─────────────────────────────────────────────────
        [HttpPost]
        public IActionResult Create([FromBody] Famille famille)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_useMockData)
            {
                if (MockData.Familles.Any(f => f.faCodeFamille == famille.faCodeFamille))
                    return Conflict(new { error = "Une famille avec ce code existe déjà." });

                var newFamille = new Famille
                {
                    cbMarq        = MockData.Familles.Any() ? MockData.Familles.Max(f => f.cbMarq) + 1 : 1,
                    faCodeFamille = famille.faCodeFamille.Trim().ToUpper(),
                    faIntitule    = famille.faIntitule.Trim()
                };
                MockData.Familles.Add(newFamille);
                return CreatedAtAction(nameof(GetByCode), new { code = newFamille.faCodeFamille }, newFamille);
            }

            return StatusCode(501, new { error = "La création de familles n'est pas supportée en mode Sage." });
        }

        // ── PUT api/Famille/{code} ───────────────────────────────────────────
        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] Famille famille)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_useMockData)
            {
                var existing = MockData.Familles.FirstOrDefault(f => f.faCodeFamille == code);
                if (existing is null) return NotFound(new { error = "Famille non trouvée." });
                existing.faIntitule = famille.faIntitule.Trim();
                return Ok(existing);
            }

            return StatusCode(501, new { error = "La modification de familles n'est pas supportée en mode Sage." });
        }

        // ── DELETE api/Famille/{code} ────────────────────────────────────────
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            if (_useMockData)
            {
                var existing = MockData.Familles.FirstOrDefault(f => f.faCodeFamille == code);
                if (existing is null) return NotFound(new { error = "Famille non trouvée." });
                MockData.Familles.Remove(existing);
                return NoContent();
            }

            return StatusCode(501, new { error = "La suppression de familles n'est pas supportée en mode Sage." });
        }

        // ── DELETE api/Famille/DeleteAll ─────────────────────────────────────
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            if (!_useMockData)
                return BadRequest(new { error = "App_Familles n'est pas utilisée en mode SQL." });
            MockData.Familles.Clear();
            return Ok(new { message = "Toutes les familles mock ont été supprimées." });
        }
    }
}
