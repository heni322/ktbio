using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpIntervention
{
    public string IveNum { get; set; } = null!;

    public string? IveStatut { get; set; }

    public DateTime? IveDate { get; set; }

    public string? IveHeure { get; set; }

    public int? IveNo { get; set; }

    public string? IveUser { get; set; }

    public string? IveNocontacttype { get; set; }

    public short? IveCodecontacttype { get; set; }

    public int? IveNocontact { get; set; }

    public string? IveRaison { get; set; }

    public string? IveEnvoitype { get; set; }

    public string? IveModele { get; set; }

    public string? IveDocument { get; set; }

    public string? IveCalculpenalite { get; set; }

    public decimal? IvePenalite { get; set; }

    public decimal? IveFraiimpaye { get; set; }

    public string? IveComptabilisation { get; set; }

    public string? IveType { get; set; }

    public DateTime? IveDatepromesse { get; set; }

    public DateTime? IveDatealerte { get; set; }

    public short? IveRisque { get; set; }

    public decimal? IvePerteprobable { get; set; }

    public string? IveDrstatut { get; set; }

    public string? IveEtape { get; set; }

    public string? IveScenario { get; set; }

    public short? IveLibinterlocuteur { get; set; }

    public string? IveContact { get; set; }

    public string? IveCodeRisque { get; set; }
}
