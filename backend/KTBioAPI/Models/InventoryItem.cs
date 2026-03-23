using System.ComponentModel.DataAnnotations;

namespace KTBioAPI.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public string CodeFamille { get; set; } = string.Empty;
        public string ReferenceArticle { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string SousFamille { get; set; } = string.Empty;
        public decimal Longueur { get; set; }
        public decimal Diametre { get; set; }
        public int DepotId { get; set; }
        public string DepotName { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public DateTime? DateExpiration { get; set; }
        public string? Lot { get; set; }
        public int CriticalPeriodMonths { get; set; }
    }

    public class InventoryFilterRequest
    {
        public string? Annee { get; set; }
        public string? SousFamille { get; set; }
        public List<string>? Familles { get; set; }
        public List<int>? Depots { get; set; }
        public string? ModeAffichage { get; set; } = "Date";
    }

    public class InventoryGroupView
    {
        public decimal Longueur { get; set; }
        public decimal Diametre { get; set; }
        public List<DepotInventory> Depots { get; set; } = new();
        public int Total { get; set; }
    }

    public class DepotInventory
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; } = string.Empty;
        public List<InventoryDetail> Items { get; set; } = new();
    }

    public class InventoryDetail
    {
        public int Id { get; set; }
        public string SousFamille { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public DateTime? DateExpiration { get; set; }
        public string? Lot { get; set; }
        public int CriticalPeriodMonths { get; set; }
    }
}
