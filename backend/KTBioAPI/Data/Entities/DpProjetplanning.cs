using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpProjetplanning
{
    public string PpNum { get; set; } = null!;

    public string? PpType { get; set; }

    public string? PpRefcompose { get; set; }

    public string? PpRefcomposeIntitule { get; set; }

    public int? PpNo1Compose { get; set; }

    public string? PpLibelleNo1Compose { get; set; }

    public int? PpNo2Compose { get; set; }

    public string? PpLibelleNo2Compose { get; set; }

    public string? PpOperation { get; set; }

    public string? PpRefcomposant { get; set; }

    public string? PpRefcomposantIntitule { get; set; }

    public int? PpNo1Composant { get; set; }

    public string? PpLibelleNo1Composant { get; set; }

    public int? PpNo2Composant { get; set; }

    public string? PpLibelleNo2Composant { get; set; }

    public string? PpComposelie { get; set; }

    public string? PpCode { get; set; }

    public string? PpIntitule { get; set; }

    public decimal? PpQuantite { get; set; }

    public decimal? PpQAFabriquerCpe { get; set; }

    public int? PpTemps { get; set; }

    public decimal? PpQuantiteaffectee { get; set; }

    public decimal? PpPuht { get; set; }

    public DateTime? PpDatedebut { get; set; }

    public DateTime? PpDatefin { get; set; }

    public string? PpNoDepot { get; set; }

    public int? PpNo { get; set; }

    public decimal? PpQterealise { get; set; }

    public decimal? PpQFabriqueCpe { get; set; }

    public decimal? PpQRestant { get; set; }

    public decimal? PpQRestantCpe { get; set; }

    public decimal? PpAvencQuantite { get; set; }

    public double? PpAvencDuree { get; set; }

    public int? PpTempsrealise { get; set; }

    public string? PpHeuredebut { get; set; }

    public string? PpHeureffin { get; set; }
}
