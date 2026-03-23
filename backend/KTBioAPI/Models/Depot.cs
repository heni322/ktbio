using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class Depot
    {
        [Key]
        public int deNo { get; set; }
        public string deIntitule { get; set; } = string.Empty;
    }
}
