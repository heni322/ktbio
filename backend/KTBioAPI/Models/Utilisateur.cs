using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom d'utilisateur doit contenir entre 3 et 50 caractères")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom complet est requis")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le rôle est requis")]
        public string Role { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Le mot de passe doit contenir au moins 3 caractères")]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom d'utilisateur doit contenir entre 3 et 50 caractères")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom complet est requis")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "La confirmation du mot de passe est requise")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public Utilisateur? User { get; set; }
    }
}
