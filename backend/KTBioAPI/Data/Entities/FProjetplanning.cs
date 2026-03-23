using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FProjetplanning
{
    public string PfNum { get; set; } = null!;

    public byte[]? CbPfNum { get; set; }

    public short? PpType { get; set; }

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

    public string? RpCode { get; set; }

    public byte[]? CbRpCode { get; set; }

    public string? PpIntitule { get; set; }

    public decimal? PpQuantite { get; set; }

    public string? PpTemps { get; set; }

    public decimal? PpQteAffectee { get; set; }

    public string? PpTempsAffecte { get; set; }

    public decimal? PpPuht { get; set; }

    public DateTime? PpDateDebut { get; set; }

    public DateTime? PpDateFin { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public int? PpNo { get; set; }

    public short? PpAjout { get; set; }

    public short? PpOrdre { get; set; }

    public short? PpSousTraitance { get; set; }

    public short? PpChevauche { get; set; }

    public short? PpDemarre { get; set; }

    public string? PpOperationChevauche { get; set; }

    public decimal? PpValeurChevauche { get; set; }

    public short? PpTypeChevauche { get; set; }

    public short? PpTypeNomencl { get; set; }

    public decimal? PpQteRealisee { get; set; }

    public string? PpTempsRealise { get; set; }

    public string? PpHeureDebut { get; set; }

    public string? PpHeureFin { get; set; }

    public decimal? PpQteReservee { get; set; }

    public short? PfType { get; set; }

    public int? PpNoOrigine { get; set; }

    public decimal? PpCoutStd { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle? ArRefComposantNavigation { get; set; }

    public virtual FArticle ArRefComposeNavigation { get; set; } = null!;

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual ICollection<FAgendum> FAgenda { get; set; } = new List<FAgendum>();

    public virtual ICollection<FProjethisto> FProjethistos { get; set; } = new List<FProjethisto>();

    public virtual FProjetfabrication PfNumNavigation { get; set; } = null!;

    public virtual FRessourceprod? RpCodeNavigation { get; set; }
}
