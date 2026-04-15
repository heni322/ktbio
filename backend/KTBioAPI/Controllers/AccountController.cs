using KTBioAPI.Data;
using KTBioAPI.Models;
using KTBioAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly KTBioContext _context;
        private readonly bool _useMockData;
        private readonly JwtHelper _jwtHelper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            KTBioContext context,
            IConfiguration configuration,
            JwtHelper jwtHelper,
            ILogger<AccountController> logger)
        {
            _context = context;
            _useMockData = configuration.GetValue<bool>("ConnectionStrings:UseMockData");
            _jwtHelper = jwtHelper;
            _logger = logger;
        }

        // ─── GET /api/Account/ListeUtilisateurs ─────────────────────────────
        [HttpGet("ListeUtilisateurs")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllUsers()
        {
            try
            {
                if (_useMockData)
                    return Ok(MockData.Utilisateurs.Select(SafeUser));

                var users = await _context.Utilisateurs.ToListAsync();
                return Ok(users.Select(SafeUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users");
                return StatusCode(500, new { error = "Erreur lors de la récupération des utilisateurs" });
            }
        }

        // ─── GET /api/Account/user/{id} ──────────────────────────────────────
        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<ActionResult<Utilisateur>> GetUser(int id)
        {
            try
            {
                if (_useMockData)
                {
                    var mock = MockData.Utilisateurs.FirstOrDefault(u => u.Id == id);
                    if (mock == null) return NotFound(new { error = "Utilisateur non trouvé" });
                    return Ok(SafeUser(mock));
                }

                var user = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                    return NotFound(new { error = "Utilisateur non trouvé" });

                return Ok(SafeUser(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user {UserId}", id);
                return StatusCode(500, new { error = "Erreur lors de la récupération de l'utilisateur" });
            }
        }

        // ─── POST /api/Account/Login ─────────────────────────────────────────
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new LoginResponse { Success = false, Message = "Données invalides" });

                Utilisateur? user;

                if (_useMockData)
                {
                    user = MockData.Utilisateurs.FirstOrDefault(u =>
                        u.Username == request.Username &&
                        PasswordHelper.VerifyPassword(request.Password, u.PasswordHash));
                }
                else
                {
                    var dbUser = await _context.Utilisateurs
                        .FirstOrDefaultAsync(u => u.Username == request.Username);

                    if (dbUser == null || !PasswordHelper.VerifyPassword(request.Password, dbUser.PasswordHash))
                    {
                        _logger.LogWarning("Failed login attempt for user: {Username}", request.Username);
                        return Ok(new LoginResponse
                        {
                            Success = false,
                            Message = "Nom d'utilisateur ou mot de passe incorrect"
                        });
                    }
                    user = dbUser;
                }

                if (user == null)
                {
                    return Ok(new LoginResponse { Success = false, Message = "Identifiants incorrects" });
                }

                var (accessToken, refreshToken) = _jwtHelper.GenerateTokenPair(user);

                _logger.LogInformation("User {Username} logged in successfully", request.Username);

                return Ok(new LoginResponse
                {
                    Success = true,
                    Token = accessToken,
                    RefreshToken = refreshToken,
                    Message = "Connexion réussie",
                    User = SafeUser(user)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user: {Username}", request.Username);
                return StatusCode(500, new { error = "Erreur lors de la connexion" });
            }
        }

        // ─── POST /api/Account/Refresh ───────────────────────────────────────
        [HttpPost("Refresh")]
        [AllowAnonymous]
        public ActionResult<RefreshResponse> Refresh([FromBody] RefreshRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                    return BadRequest(new { error = "Refresh token manquant" });

                var principal = _jwtHelper.ValidateRefreshToken(request.RefreshToken);
                if (principal == null)
                    return Unauthorized(new { error = "Refresh token invalide ou expiré" });

                var idClaim       = principal.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var usernameClaim = principal.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
                var roleClaim     = principal.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;
                var emailClaim    = principal.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                var nameClaim     = principal.FindFirst(System.Security.Claims.ClaimTypes.GivenName)?.Value;

                if (idClaim == null || usernameClaim == null)
                    return Unauthorized(new { error = "Claims invalides dans le refresh token" });

                var user = new Utilisateur
                {
                    Id           = int.Parse(idClaim),
                    Username     = usernameClaim,
                    Role         = roleClaim ?? "User",
                    Email        = emailClaim ?? "",
                    FullName     = nameClaim ?? usernameClaim,
                    PasswordHash = ""
                };

                var (newAccessToken, newRefreshToken) = _jwtHelper.GenerateTokenPair(user);

                return Ok(new RefreshResponse
                {
                    Token        = newAccessToken,
                    RefreshToken = newRefreshToken
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh");
                return StatusCode(500, new { error = "Erreur lors du renouvellement du token" });
            }
        }

        // ─── POST /api/Account/Register ──────────────────────────────────────
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    return BadRequest(new { error = "Données invalides", details = errors });
                }

                if (_useMockData)
                {
                    if (MockData.Utilisateurs.Any(u =>
                        u.Username == request.Username || u.Email == request.Email))
                        return BadRequest(new { error = "Un utilisateur avec ce nom ou cet email existe déjà" });

                    var newMock = new Utilisateur
                    {
                        Id           = MockData.Utilisateurs.Any() ? MockData.Utilisateurs.Max(u => u.Id) + 1 : 1,
                        Username     = request.Username,
                        FullName     = request.FullName,
                        Email        = request.Email,
                        Role         = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role,
                        PasswordHash = PasswordHelper.HashPassword(request.Password)
                    };
                    MockData.Utilisateurs.Add(newMock);
                    return Ok(new { message = "Utilisateur créé avec succès", userId = newMock.Id });
                }

                var existing = await _context.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Username == request.Username || u.Email == request.Email);
                if (existing != null)
                    return BadRequest(new { error = "Un utilisateur avec ce nom ou cet email existe déjà" });

                var newUser = new Utilisateur
                {
                    Username     = request.Username,
                    FullName     = request.FullName,
                    Email        = request.Email,
                    Role         = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role,
                    PasswordHash = PasswordHelper.HashPassword(request.Password)
                };

                _context.Utilisateurs.Add(newUser);
                await _context.SaveChangesAsync();

                _logger.LogInformation("User {Username} registered successfully", request.Username);
                return Ok(new { message = "Utilisateur créé avec succès", userId = newUser.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for user: {Username}", request.Username);
                return StatusCode(500, new { error = "Erreur lors de l'inscription", details = ex.Message });
            }
        }

        // ─── POST /api/Account/AddUtilisateur (Admin only) ───────────────────
        [HttpPost("AddUtilisateur")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUtilisateur([FromBody] AddUtilisateurRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    return BadRequest(new { error = "Données invalides", details = errors });
                }

                if (_useMockData)
                {
                    if (MockData.Utilisateurs.Any(u =>
                        u.Username == request.Username || u.Email == request.Email))
                        return BadRequest(new { error = "Un utilisateur avec ce nom ou cet email existe déjà" });

                    var newMock = new Utilisateur
                    {
                        Id           = MockData.Utilisateurs.Any() ? MockData.Utilisateurs.Max(u => u.Id) + 1 : 1,
                        Username     = request.Username,
                        FullName     = request.FullName,
                        Email        = request.Email,
                        Role         = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role,
                        PasswordHash = PasswordHelper.HashPassword(request.Password)
                    };
                    MockData.Utilisateurs.Add(newMock);
                    return Ok(new { message = "Utilisateur créé avec succès", userId = newMock.Id });
                }

                var existing = await _context.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Username == request.Username || u.Email == request.Email);
                if (existing != null)
                    return BadRequest(new { error = "Un utilisateur avec ce nom ou cet email existe déjà" });

                var newUser = new Utilisateur
                {
                    Username     = request.Username,
                    FullName     = request.FullName,
                    Email        = request.Email,
                    Role         = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role,
                    PasswordHash = PasswordHelper.HashPassword(request.Password)
                };

                _context.Utilisateurs.Add(newUser);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Admin created user {Username}", request.Username);
                return Ok(new { message = "Utilisateur créé avec succès", userId = newUser.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user by admin");
                return StatusCode(500, new { error = "Erreur lors de la création de l'utilisateur", details = ex.Message });
            }
        }

        // ─── DELETE /api/Account/DeleteUtilisateur/{id} (Admin only) ─────────
        [HttpDelete("DeleteUtilisateur/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            try
            {
                var currentUserId = int.Parse(
                    User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (currentUserId == id)
                    return BadRequest(new { error = "Vous ne pouvez pas supprimer votre propre compte" });

                if (_useMockData)
                {
                    var mockUser = MockData.Utilisateurs.FirstOrDefault(u => u.Id == id);
                    if (mockUser == null) return NotFound(new { error = "Utilisateur non trouvé" });
                    MockData.Utilisateurs.Remove(mockUser);
                    return Ok(new { message = "Utilisateur supprimé" });
                }

                var user = await _context.Utilisateurs.FindAsync(id);
                if (user == null)
                    return NotFound(new { error = "Utilisateur non trouvé" });

                _context.Utilisateurs.Remove(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Admin deleted user {UserId}", id);
                return Ok(new { message = "Utilisateur supprimé" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return StatusCode(500, new { error = "Erreur lors de la suppression" });
            }
        }

        // ─── PUT /api/Account/UpdateUtilisateur/{id} (Admin only) ────────────
        [HttpPut("UpdateUtilisateur/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUtilisateur(int id, [FromBody] UpdateUtilisateurRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    return BadRequest(new { error = "Données invalides", details = errors });
                }

                if (_useMockData)
                {
                    var mock = MockData.Utilisateurs.FirstOrDefault(u => u.Id == id);
                    if (mock == null) return NotFound(new { error = "Utilisateur non trouvé" });
                    mock.FullName = request.FullName;
                    mock.Email    = request.Email;
                    mock.Role     = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role;
                    return Ok(new { message = "Utilisateur mis à jour" });
                }

                var user = await _context.Utilisateurs.FindAsync(id);
                if (user == null)
                    return NotFound(new { error = "Utilisateur non trouvé" });

                // Check email not taken by another user
                var emailTaken = await _context.Utilisateurs
                    .AnyAsync(u => u.Email == request.Email && u.Id != id);
                if (emailTaken)
                    return BadRequest(new { error = "Cet email est déjà utilisé par un autre compte" });

                user.FullName = request.FullName;
                user.Email    = request.Email;
                user.Role     = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Admin updated user {UserId}", id);
                return Ok(new { message = "Utilisateur mis à jour" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", id);
                return StatusCode(500, new { error = "Erreur lors de la modification de l'utilisateur", details = ex.Message });
            }
        }

        // ─── POST /api/Account/ResetPasswordAdmin/{id} (Admin only) ──────────
        [HttpPost("ResetPasswordAdmin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResetPasswordAdmin(int id, [FromBody] ResetPasswordAdminRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);
                    return BadRequest(new { error = "Données invalides", details = errors });
                }

                if (_useMockData)
                {
                    var mock = MockData.Utilisateurs.FirstOrDefault(u => u.Id == id);
                    if (mock == null) return NotFound(new { error = "Utilisateur non trouvé" });
                    mock.PasswordHash = PasswordHelper.HashPassword(request.NewPassword);
                    return Ok(new { message = "Mot de passe réinitialisé avec succès" });
                }

                var user = await _context.Utilisateurs.FindAsync(id);
                if (user == null)
                    return NotFound(new { error = "Utilisateur non trouvé" });

                user.PasswordHash = PasswordHelper.HashPassword(request.NewPassword);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Admin reset password for user {UserId}", id);
                return Ok(new { message = "Mot de passe réinitialisé avec succès" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting password for user {UserId}", id);
                return StatusCode(500, new { error = "Erreur lors de la réinitialisation du mot de passe", details = ex.Message });
            }
        }

        // ─── POST /api/Account/ChangePassword ────────────────────────────────
        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                var userId = int.Parse(
                    User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");

                if (_useMockData)
                {
                    var mockUser = MockData.Utilisateurs.FirstOrDefault(u => u.Id == userId);
                    if (mockUser == null) return NotFound(new { error = "Utilisateur non trouvé" });
                    if (!PasswordHelper.VerifyPassword(request.OldPassword, mockUser.PasswordHash))
                        return BadRequest(new { error = "Ancien mot de passe incorrect" });
                    mockUser.PasswordHash = PasswordHelper.HashPassword(request.NewPassword);
                    return Ok(new { message = "Mot de passe modifié avec succès" });
                }

                var user = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                    return NotFound(new { error = "Utilisateur non trouvé" });

                if (!PasswordHelper.VerifyPassword(request.OldPassword, user.PasswordHash))
                    return BadRequest(new { error = "Ancien mot de passe incorrect" });

                user.PasswordHash = PasswordHelper.HashPassword(request.NewPassword);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Password changed for user {UserId}", userId);
                return Ok(new { message = "Mot de passe modifié avec succès" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password");
                return StatusCode(500, new { error = "Erreur lors du changement de mot de passe" });
            }
        }

        // ─── Private helpers ─────────────────────────────────────────────────
        private static Utilisateur SafeUser(Utilisateur u) => new()
        {
            Id           = u.Id,
            Username     = u.Username,
            FullName     = u.FullName,
            Email        = u.Email,
            Role         = u.Role,
            PasswordHash = ""
        };
    }

    // ─── DTOs ─────────────────────────────────────────────────────────────────
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "L'ancien mot de passe est requis")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nouveau mot de passe est requis")]
        [StringLength(100, MinimumLength = 6)]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    /// <summary>
    /// Used by the Admin "Add User" form — no complex password regex enforced
    /// so admins can set simple initial passwords and users change later.
    /// </summary>
    public class AddUtilisateurRequest
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom complet est requis")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
    }

    public class UpdateUtilisateurRequest
    {
        [Required(ErrorMessage = "Le nom complet est requis")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
    }

    public class ResetPasswordAdminRequest
    {
        [Required(ErrorMessage = "Le nouveau mot de passe est requis")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string NewPassword { get; set; } = string.Empty;
    }

    public class RefreshRequest
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshResponse
    {
        public string Token        { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
