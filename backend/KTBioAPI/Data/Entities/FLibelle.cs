using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLibelle
{
    public string? LbIntitule { get; set; }

    public byte[]? CbLbIntitule { get; set; }

    public string? LbRaccourci { get; set; }

    public byte[]? CbLbRaccourci { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
