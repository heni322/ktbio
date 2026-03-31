using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    /// <summary>
    /// Familles — lecture depuis dbo.F_FAMILLE (Sage) avec filtre :
    ///   SELECT FA_CodeFamille, FA_Intitule
    ///   FROM dbo.F_FAMILLE
    ///   WHERE FA_CodeFamille IN ('CARD01','CARD02','CARD03','CARD29','CARD30')
    ///
    /// La table App_Familles n'est plus utilisée.
    /// POST /Sync  → synchronise App_Familles depuis Sage (Admin uniquement, appelé au démarrage).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FamilleController : ControllerBase
    {
        // Codes autorisés — modifier ici pour en ajouter/retirer
        private static readonly string[] AllowedCodes =
            { "CARD01", "CARD02", "CARD03", "CARD29", "CARD30" };

        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public FamilleController(KTBioContext context, IConfiguration configuration)
        {
            _context   = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        // ── GET api/Famille ──────────────────────────────────────────────────
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Famille>>> GetAll()
        {
            if (_useMockData)
                return Ok(MockData.Familles);

            // SELECT FA_CodeFamille, FA_Intitule FROM dbo.F_FAMILLE
            // WHERE FA_CodeFamille IN ('CARD01','CARD02','CARD03','CARD29','CARD30')
            var familles = await _context.FFamilles
                .Where(f => AllowedCodes.Contains(f.FaCodeFamille.Trim()))
                .OrderBy(f => f.FaCodeFamille)
                .Select(f => new Famille
                {
                    cbMarq        = f.CbMarq,
                    faCodeFamille = f.FaCodeFamille.Trim(),
                    faIntitule    = f.FaIntitule.Trim()
                })
                .ToListAsync();

            return Ok(familles);
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

            var f = await _context.FFamilles
                .FirstOrDefaultAsync(f => f.FaCodeFamille.Trim() == code.Trim());

            if (f is null)
                return NotFound(new { error = "Famille non trouvée dans Sage." });

            return Ok(new Famille
            {
                cbMarq        = f.CbMarq,
                faCodeFamille = f.FaCodeFamille.Trim(),
                faIntitule    = f.FaIntitule.Trim()
            });
        }

        // ── DELETE api/Famille/DeleteAll ─────────────────────────────────────
        // Vide la table App_Familles (utilisée uniquement si UseMockData=true)
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            if (!_useMockData)
                return BadRequest(new { error = "App_Familles n'est pas utilisée en mode SQL — aucune action nécessaire." });

            MockData.Familles.Clear();
            return Ok(new { message = "Toutes les familles mock ont été supprimées." });
        }
    }
}
