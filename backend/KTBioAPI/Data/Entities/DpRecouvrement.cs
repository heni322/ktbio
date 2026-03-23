using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpRecouvrement
{
    public string RcvNoRecouvrement { get; set; } = null!;

    public string RcvNoTiers { get; set; } = null!;

    public decimal? RcvPerteprobabla { get; set; }

    public string? RcvStatut { get; set; }

    public short RcvPriorite { get; set; }

    public DateTime? RcvDatedebut { get; set; }

    public int? RcvAnneeDebut { get; set; }

    public string? RcvSemestreDebut { get; set; }

    public string? RcvTrimestreDebut { get; set; }

    public string? RcvMoisDebut { get; set; }

    public string? RcvLibMoisDebut { get; set; }

    public string? RcvSemaineDebut { get; set; }

    public string? RcvJourDebut { get; set; }

    public string? RcvLitige { get; set; }

    public string? RcvResume { get; set; }

    public string? RcvCcontactClient { get; set; }

    public int? RcvNoIntTiers { get; set; }

    public string? RcvNomPrenom { get; set; }

    public string? RcvCommentaire { get; set; }

    public DateTime? RcvDatefin { get; set; }

    public int? RcvAnneeFin { get; set; }

    public string? RcvSemestreFin { get; set; }

    public string? RcvTrimestreFin { get; set; }

    public string? RcvMoisFin { get; set; }

    public string? RcvLibMoisFin { get; set; }

    public string? RcvSemaineFin { get; set; }

    public string? RcvJourFin { get; set; }

    public string RcvResolution { get; set; } = null!;

    public string? RcvResultat { get; set; }

    public decimal? RcvProvision { get; set; }

    public string? RcvNoIntCollaborateur { get; set; }

    public string? RcvScenario { get; set; }

    public string RcvDerniereEtape { get; set; } = null!;

    public double? RcvFactures { get; set; }

    public double? RcvReglements { get; set; }

    public double? RcvFraisPenalites { get; set; }

    public double? RcvTotal { get; set; }
}
