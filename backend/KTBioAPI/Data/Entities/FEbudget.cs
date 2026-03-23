using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEbudget
{
    public int BdNo { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FBudget BdNoNavigation { get; set; } = null!;

    public virtual FCompteg CgNumNavigation { get; set; } = null!;
}
