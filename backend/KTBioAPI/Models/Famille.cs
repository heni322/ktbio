using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class Famille
    {
        [Key]
        public int cbMarq { get; set; }
        public string faCodeFamille { get; set; } = string.Empty;
        public string faIntitule { get; set; } = string.Empty;
    }
}
