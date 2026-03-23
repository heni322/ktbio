using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboligneinfo
{
    public int AlNo { get; set; }

    public string AcCode { get; set; } = null!;

    public byte[]? CbAcCode { get; set; }

    public string AcIntitule { get; set; } = null!;

    public byte[]? CbAcIntitule { get; set; }

    public short? AcType { get; set; }

    public string? AcValeur { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FAboligne AlNoNavigation { get; set; } = null!;
}
