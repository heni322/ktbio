using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FExtrait
{
    public int ExNo { get; set; }

    public short? ExType { get; set; }

    public string? ExReference { get; set; }

    public byte[]? CbExReference { get; set; }

    public short? ExEtat { get; set; }

    public DateTime? ExAncDate { get; set; }

    public decimal? ExAncSolde { get; set; }

    public DateTime? ExNouvDate { get; set; }

    public int EbNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEbanque EbNoNavigation { get; set; } = null!;

    public virtual ICollection<FEextrait> FEextraits { get; set; } = new List<FEextrait>();
}
