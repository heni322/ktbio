using KTBioAPI.Data;
using KTBioAPI.Models;
using KTBioAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Tous les endpoints Etat nécessitent une authentification
    public class EtatController : ControllerBase
    {
        private readonly KTBioContext _context;
        private readonly bool _useMockData;

        public EtatController(KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        // Lecture : tout utilisateur authentifié
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etat>>> GetAll()
        {
            if (_useMockData)
                return Ok(MockData.Etats);

            var entities = await _context.Etats.ToListAsync();
            return Ok(entities.Select(MapToModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Etat>> GetById(int id)
        {
            if (_useMockData)
            {
                var mock = MockData.Etats.FirstOrDefault(e => e.Id == id);
                if (mock == null) return NotFound();
                return Ok(mock);
            }

            var entity = await _context.Etats.FindAsync(id);
            if (entity == null) return NotFound();
            return Ok(MapToModel(entity));
        }

        // Écriture : Admin seulement
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Etat>> Create([FromBody] CreateEtatRequest request)
        {
            if (_useMockData)
            {
                var newEtat = new Etat
                {
                    Id           = MockData.Etats.Any() ? MockData.Etats.Max(e => e.Id) + 1 : 1,
                    Nom          = request.Nom,
                    Familles     = request.Familles,
                    Utilisateurs = request.Utilisateurs,
                    Depots       = request.Depots
                };
                MockData.Etats.Add(newEtat);
                return CreatedAtAction(nameof(GetById), new { id = newEtat.Id }, newEtat);
            }

            var entity = new EtatEntity
            {
                Nom              = request.Nom,
                FamillesJson     = JsonSerializer.Serialize(request.Familles),
                UtilisateursJson = JsonSerializer.Serialize(request.Utilisateurs),
                DepotsJson       = JsonSerializer.Serialize(request.Depots)
            };
            _context.Etats.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MapToModel(entity));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateEtatRequest request)
        {
            if (_useMockData)
            {
                var existing = MockData.Etats.FirstOrDefault(e => e.Id == id);
                if (existing == null) return NotFound();
                existing.Nom          = request.Nom;
                existing.Familles     = request.Familles;
                existing.Utilisateurs = request.Utilisateurs;
                existing.Depots       = request.Depots;
                return NoContent();
            }

            var entity = await _context.Etats.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Nom              = request.Nom;
            entity.FamillesJson     = JsonSerializer.Serialize(request.Familles);
            entity.UtilisateursJson = JsonSerializer.Serialize(request.Utilisateurs);
            entity.DepotsJson       = JsonSerializer.Serialize(request.Depots);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_useMockData)
            {
                var existing = MockData.Etats.FirstOrDefault(e => e.Id == id);
                if (existing == null) return NotFound();
                MockData.Etats.Remove(existing);
                return NoContent();
            }

            var entity = await _context.Etats.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Etats.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private static Etat MapToModel(EtatEntity entity) => new()
        {
            Id           = entity.Id,
            Nom          = entity.Nom,
            Familles     = JsonSerializer.Deserialize<List<string>>(entity.FamillesJson)  ?? new(),
            Utilisateurs = JsonSerializer.Deserialize<List<string>>(entity.UtilisateursJson) ?? new(),
            Depots       = JsonSerializer.Deserialize<List<int>>(entity.DepotsJson)       ?? new()
        };
    }

    // ─── DTO ──────────────────────────────────────────────────────────────────
    public class CreateEtatRequest
    {
        public string       Nom          { get; set; } = string.Empty;
        public List<string> Familles     { get; set; } = new();
        public List<string> Utilisateurs { get; set; } = new();
        public List<int>    Depots       { get; set; } = new();
    }
}
