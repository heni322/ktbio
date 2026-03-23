using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FJmouv
{
    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public DateTime JmDate { get; set; }

    public short? JmCloture { get; set; }

    public short? JmImpression { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
