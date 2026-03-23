using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptegnote
{
    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public string? CgNote { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;
}
