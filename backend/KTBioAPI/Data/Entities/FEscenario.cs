using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEscenario
{
    public int? ScNo { get; set; }

    public short? EsLigne { get; set; }

    public int? EsNo { get; set; }

    public string? EsIntitule { get; set; }

    public short? EsDelai { get; set; }

    public short? NRisque { get; set; }

    public decimal? EsPerteProbable { get; set; }

    public short? EsCalculPenalite { get; set; }

    public decimal? EsFraiImpaye { get; set; }

    public short? EsEnvoiType { get; set; }

    public string? EsDocument { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FDrecouvrementiv> FDrecouvrementivs { get; set; } = new List<FDrecouvrementiv>();

    public virtual FScenario? ScNoNavigation { get; set; }
}
