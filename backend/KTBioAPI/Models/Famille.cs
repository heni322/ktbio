using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class Famille
    {
        [Key]
        public int cbMarq { get; set; }
        
        [Required(ErrorMessage = "Le code famille est requis")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Le code doit contenir entre 1 et 10 caractères")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Le code doit contenir uniquement des lettres majuscules et chiffres")]
        public string faCodeFamille { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "L'intitulé est requis")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "L'intitulé doit contenir entre 1 et 100 caractères")]
        public string faIntitule { get; set; } = string.Empty;
    }
}
