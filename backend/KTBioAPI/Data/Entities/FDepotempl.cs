using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDepotempl
{
    public int DeNo { get; set; }

    public int? DpNo { get; set; }

    public string? DpCode { get; set; }

    public byte[]? CbDpCode { get; set; }

    public string? DpIntitule { get; set; }

    public short? DpZone { get; set; }

    public short? DpType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;

    public virtual ICollection<FArtstock> FArtstockCbDpNoControleNavigations { get; set; } = new List<FArtstock>();

    public virtual ICollection<FArtstock> FArtstockCbDpNoPrincipalNavigations { get; set; } = new List<FArtstock>();

    public virtual ICollection<FArtstockempl> FArtstockempls { get; set; } = new List<FArtstockempl>();

    public virtual ICollection<FDepot> FDepots { get; set; } = new List<FDepot>();

    public virtual ICollection<FDocligneempl> FDocligneempls { get; set; } = new List<FDocligneempl>();

    public virtual ICollection<FGamstock> FGamstockCbDpNoControleNavigations { get; set; } = new List<FGamstock>();

    public virtual ICollection<FGamstock> FGamstockCbDpNoPrincipalNavigations { get; set; } = new List<FGamstock>();

    public virtual ICollection<FGamstockempl> FGamstockempls { get; set; } = new List<FGamstockempl>();
}
