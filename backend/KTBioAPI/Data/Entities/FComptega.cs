using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptega
{
    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public short? CgAtrepart { get; set; }

    public decimal? CgAvrepart { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;

    public virtual FComptea FComptea { get; set; } = null!;
}
