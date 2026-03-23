using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEnumanal
{
    public short? NAnalytique { get; set; }

    public short? EaRupture { get; set; }

    public string? EaNum { get; set; }

    public byte[]? CbEaNum { get; set; }

    public string? EaIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
