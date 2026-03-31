using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class Depot
    {
        [Key]
        public int deNo { get; set; }
        
        [Required(ErrorMessage = "L'intitulé du dépôt est requis")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "L'intitulé doit contenir entre 1 et 100 caractères")]
        public string deIntitule { get; set; } = string.Empty;
    }
}
