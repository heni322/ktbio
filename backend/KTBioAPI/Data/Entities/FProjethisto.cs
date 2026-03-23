using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FProjethisto
{
    public string PfNum { get; set; } = null!;

    public byte[]? CbPfNum { get; set; }

    public DateTime? PhDate { get; set; }

    public int PpNo { get; set; }

    public decimal? PhQteRealisee { get; set; }

    public string? PhTempsRealise { get; set; }

    public short? DoDomaine { get; set; }

    public string? DoPiece { get; set; }

    public string? PhIntitule { get; set; }

    public short? PhType { get; set; }

    public string ArRefCompose { get; set; } = null!;

    public byte[]? CbArRefCompose { get; set; }

    public int? AgNo1Compose { get; set; }

    public int? AgNo2Compose { get; set; }

    public string? PpOperation { get; set; }

    public byte[]? CbPpOperation { get; set; }

    public string? ArRefComposant { get; set; }

    public byte[]? CbArRefComposant { get; set; }

    public int? AgNo1Composant { get; set; }

    public int? AgNo2Composant { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public decimal? PhQteReservee { get; set; }

    public short? PfType { get; set; }

    public decimal? PhCoutRealise { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle? ArRefComposantNavigation { get; set; }

    public virtual FArticle ArRefComposeNavigation { get; set; } = null!;

    public virtual FProjetfabrication PfNumNavigation { get; set; } = null!;

    public virtual FProjetplanning PpNoNavigation { get; set; } = null!;
}
