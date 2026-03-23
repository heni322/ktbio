using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEnumcond
{
    public short? EcChamp { get; set; }

    public string? EcEnumere { get; set; }

    public byte[]? CbEcEnumere { get; set; }

    public decimal? EcQuantite { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? EcEdiCode { get; set; }
}
