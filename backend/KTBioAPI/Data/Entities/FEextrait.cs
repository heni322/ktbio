using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEextrait
{
    public int ExNo { get; set; }

    public short EeLigne { get; set; }

    public DateTime? EeDateOp { get; set; }

    public DateTime? EeDateVal { get; set; }

    public string? EeIntitule { get; set; }

    public string? EePiece { get; set; }

    public short? EeEtat { get; set; }

    public short? EeIndispo { get; set; }

    public short? EeExo { get; set; }

    public decimal? EeMontant { get; set; }

    public string? EeRef { get; set; }

    public string? EeCodeInterne { get; set; }

    public string? IbAfb { get; set; }

    public short? NRejet { get; set; }

    public string? EeLettre { get; set; }

    public decimal? EeMontantCpta { get; set; }

    public short? EePoint { get; set; }

    public string? EePointage { get; set; }

    public byte[]? CbEePointage { get; set; }

    public DateTime? EeDatePoint { get; set; }

    public int? EeNatureTreso { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbEeLettre { get; set; }

    public virtual FExtrait ExNoNavigation { get; set; } = null!;

    public virtual ICollection<FEextraitec> FEextraitecs { get; set; } = new List<FEextraitec>();

    public virtual ICollection<FEextraitlib> FEextraitlibs { get; set; } = new List<FEextraitlib>();
}
