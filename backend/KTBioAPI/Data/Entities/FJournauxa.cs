using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FJournauxa
{
    public string JaNum { get; set; } = null!;

    public byte[]? CbJaNum { get; set; }

    public string? JaIntitule { get; set; }

    public byte[]? CbJaIntitule { get; set; }

    public short? JaSommeil { get; set; }

    public short? JaIfrs { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
