using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FScenario
{
    public int? ScNo { get; set; }

    public string? ScIntitule { get; set; }

    public byte[]? CbScIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FEscenario> FEscenarios { get; set; } = new List<FEscenario>();
}
