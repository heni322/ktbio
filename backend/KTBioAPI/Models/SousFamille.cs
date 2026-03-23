using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class SousFamille
    {
        [Key]
        public int cbMarq { get; set; }
        public string code { get; set; } = string.Empty;
        public string nom { get; set; } = string.Empty;
        public string fCodeFFamille { get; set; } = string.Empty;
        public DateTime dateCreation { get; set; }
    }
}
