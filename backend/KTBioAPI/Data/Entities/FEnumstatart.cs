using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEnumstatart
{
    public short? SaChamp { get; set; }

    public string SaEnumere { get; set; } = null!;

    public byte[]? CbSaEnumere { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
