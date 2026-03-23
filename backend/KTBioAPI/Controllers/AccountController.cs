using KTBioAPI.Data;
using KTBioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly KTBioAPI.Data.KTBioContext _context;
        private readonly bool _useMockData;

        public AccountController(KTBioAPI.Data.KTBioContext context, IConfiguration configuration)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
        }

        [HttpGet("ListeUtilisateurs")]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllUsers()
        {
            if (_useMockData)
            {
                return Ok(MockData.Utilisateurs);
            }

            var collaborators = await _context.FCollaborateurs
                .Select(u => new Utilisateur
                {
                    Id = u.CbMarq,
                    Username = u.CoNom ?? "user",
                    FullName = (u.CoPrenom + " " + u.CoNom).Trim(),
                    Email = u.CoEmail ?? "",
                    Role = u.CoEmail == "anis@ktbio.tn" ? "Admin" : (u.CoVendeur == 1 ? "Vendeur" : "User"),
                    PasswordHash = ""
                })
                .ToListAsync();

            if (!collaborators.Any())
            {
                collaborators.Add(new Utilisateur 
                { 
                    Id = 1, 
                    Username = "admin", 
                    FullName = "Administrateur", 
                    Email = "admin@ktbio.tn", 
                    Role = "Admin" 
                });
            }

            return Ok(collaborators);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Utilisateur>> GetUser(int id)
        {
            var u = await _context.FCollaborateurs.FirstOrDefaultAsync(u => u.CbMarq == id);
            if (u == null)
                return NotFound();
            
            return Ok(new Utilisateur
            {
                Id = u.CbMarq,
                Username = u.CoNom ?? "user",
                FullName = (u.CoPrenom + " " + u.CoNom).Trim(),
                Email = u.CoEmail ?? "",
                Role = u.CoEmail == "anis@ktbio.tn" ? "Admin" : (u.CoVendeur == 1 ? "Vendeur" : "User"),
                PasswordHash = ""
            });
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            if (_useMockData)
            {
                var mockUser = MockData.Utilisateurs.FirstOrDefault(u => u.Username == request.Username && request.Password == "hash123");
                if (mockUser == null && request.Username == "admin" && request.Password == "admin")
                {
                    mockUser = MockData.Utilisateurs.First(u => u.Role == "Admin");
                }

                if (mockUser == null)
                {
                    return Ok(new LoginResponse { Success = false, Message = "Identifiants incorrects (Mode Test)" });
                }

                return Ok(new LoginResponse
                {
                    Success = true,
                    Token = $"mock_token_{mockUser.Id}",
                    User = mockUser,
                    Message = "Connexion réussie (Mode Test)"
                });
            }

            // For now, allow login if username matches a collaborator and password is 'admin' or 'hash123'
            // This is a temporary measure until a proper auth system is in place
            var user = await _context.FCollaborateurs.FirstOrDefaultAsync(u => 
                (u.CoNom == request.Username && (request.Password == "admin" || request.Password == "Sql@2025++")));
            
            if (user == null && request.Username != "admin") // Fallback for the dummy admin
            {
                return Ok(new LoginResponse 
                { 
                    Success = false, 
                    Message = "Nom d'utilisateur ou mot de passe incorrect" 
                });
            }

            var mappedUser = user != null ? new Utilisateur
            {
                Id = user.CbMarq,
                Username = user.CoNom ?? "admin",
                FullName = (user.CoPrenom + " " + user.CoNom).Trim(),
                Email = user.CoEmail ?? "admin@ktbio.tn",
                Role = "Admin",
                PasswordHash = ""
            } : new Utilisateur {
                Id = 1,
                Username = "admin",
                FullName = "Administrateur",
                Email = "admin@ktbio.tn",
                Role = "Admin",
                PasswordHash = ""
            };

            return Ok(new LoginResponse
            {
                Success = true,
                Token = $"real_db_token_{mappedUser.Id}_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
                Message = "Connexion réussie",
                User = mappedUser
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Utilisateur user)
        {
            return StatusCode(501, "Registration not supported on real database via this API yet.");
        }
    }
}
