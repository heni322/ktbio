using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCtrlfieldecriturecjnl
{
    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public short? CfjChamp { get; set; }

    public short? CfjControle { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
