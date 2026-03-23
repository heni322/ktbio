using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTBioAPI.Data.Entities
{
    [Table("App_Etats")]
    public class EtatEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nom { get; set; } = string.Empty;
        
        [Required]
        public string FamillesJson { get; set; } = "[]";
        
        [Required]
        public string UtilisateursJson { get; set; } = "[]";
        
        [Required]
        public string DepotsJson { get; set; } = "[]";
    }
}
