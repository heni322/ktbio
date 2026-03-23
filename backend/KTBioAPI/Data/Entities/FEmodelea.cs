using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEmodelea
{
    public int MaNo { get; set; }

    public DateTime? EaDate { get; set; }

    public decimal? EaMontant { get; set; }

    public short? EaGeneration { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FModelea MaNoNavigation { get; set; } = null!;
}
