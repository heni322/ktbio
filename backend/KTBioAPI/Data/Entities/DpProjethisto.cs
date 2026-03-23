using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpProjethisto
{
    public string PhNum { get; set; } = null!;

    public DateTime? PhDate { get; set; }

    public int PhNo { get; set; }

    public decimal? PhQuantiterealisee { get; set; }

    public decimal? PhQuantitereservee { get; set; }

    public int? PhTempsrealise { get; set; }

    public short? PhDomaine { get; set; }

    public string? PhLibelleDomaine { get; set; }

    public string? PhPiece { get; set; }

    public string? PhTypeDoc { get; set; }

    public string? PhDocLie { get; set; }

    public string? PhIntitule { get; set; }

    public string? PhType { get; set; }

    public string? PhRefcompose { get; set; }

    public string? PhRefcomposeIntitule { get; set; }

    public int? PhNo1Compose { get; set; }

    public string? PhLibelleNo1Compose { get; set; }

    public int? PhNo2Compose { get; set; }

    public string? PhLibelleNo2Compose { get; set; }

    public string? PhOperation { get; set; }

    public string? PhRefcomposant { get; set; }

    public string? PhRefcomposantIntitule { get; set; }

    public int? PhNo1Composant { get; set; }

    public string? PhLibelleNo1Composant { get; set; }

    public int? PhNo2Composant { get; set; }

    public string? PhLibelleNo2Composant { get; set; }

    public string? PhComposelie { get; set; }

    public string? PhNodepot { get; set; }
}
