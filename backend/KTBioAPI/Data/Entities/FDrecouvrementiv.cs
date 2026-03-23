using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDrecouvrementiv
{
    public string DrNum { get; set; } = null!;

    public byte[]? CbDrNum { get; set; }

    public short? IvStatut { get; set; }

    public DateTime? IvDate { get; set; }

    public string? IvHeure { get; set; }

    public int? EsNo { get; set; }

    public int? CbEsNo { get; set; }

    public string? IvUser { get; set; }

    public short? IvNoContactType { get; set; }

    public int? IvNoContact { get; set; }

    public string? IvRaison { get; set; }

    public short? IvEnvoiType { get; set; }

    public string? IvModele { get; set; }

    public string? IvDocument { get; set; }

    public short? IvCalculPenalite { get; set; }

    public decimal? IvPenalite { get; set; }

    public decimal? IvFraiImpaye { get; set; }

    public short? IvComptabilisation { get; set; }

    public short? IvType { get; set; }

    public DateTime? IvDatePromesse { get; set; }

    public DateTime? IvDateAlerte { get; set; }

    public short? NRisque { get; set; }

    public decimal? IvPerteProbable { get; set; }

    public short? IvDrstatut { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEscenario? CbEsNoNavigation { get; set; }

    public virtual FDrecouvrement DrNumNavigation { get; set; } = null!;
}
