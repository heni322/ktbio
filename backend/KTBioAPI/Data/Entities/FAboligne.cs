using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboligne
{
    public int AbNo { get; set; }

    public int? AlLigne { get; set; }

    public string? AlRef { get; set; }

    public short? AlTremPied { get; set; }

    public short? AlTremExep { get; set; }

    public string? ArRef { get; set; }

    public byte[]? CbArRef { get; set; }

    public string? AlDesign { get; set; }

    public decimal? AlQte { get; set; }

    public decimal? AlPoidsNet { get; set; }

    public decimal? AlPoidsBrut { get; set; }

    public decimal? AlRemise01RemValeur { get; set; }

    public short? AlRemise01RemType { get; set; }

    public decimal? AlRemise02RemValeur { get; set; }

    public short? AlRemise02RemType { get; set; }

    public decimal? AlRemise03RemValeur { get; set; }

    public short? AlRemise03RemType { get; set; }

    public decimal? AlPrixUnitaire { get; set; }

    public decimal? AlTaxe1 { get; set; }

    public short? AlTypeTaux1 { get; set; }

    public short? AlTypeTaxe1 { get; set; }

    public decimal? AlTaxe2 { get; set; }

    public short? AlTypeTaux2 { get; set; }

    public short? AlTypeTaxe2 { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public int? DtNo { get; set; }

    public int? CbDtNo { get; set; }

    public string? AfRefFourniss { get; set; }

    public byte[]? CbAfRefFourniss { get; set; }

    public string? EuEnumere { get; set; }

    public decimal? EuQte { get; set; }

    public short? AlTtc { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public decimal? AlPudevise { get; set; }

    public decimal? AlPuttc { get; set; }

    public string? CaNum { get; set; }

    public byte[]? CbCaNum { get; set; }

    public decimal? AlTaxe3 { get; set; }

    public short? AlTypeTaux3 { get; set; }

    public short? AlTypeTaxe3 { get; set; }

    public short? AlPeriod { get; set; }

    public DateTime? AlDebut { get; set; }

    public DateTime? AlFin { get; set; }

    public short? AlGestAnnee { get; set; }

    public short? AlProrata { get; set; }

    public short? AlReconduction { get; set; }

    public decimal? AlPrixRu { get; set; }

    public decimal? AlCmup { get; set; }

    public short? AlValorise { get; set; }

    public string? ArRefCompose { get; set; }

    public string? AcRefClient { get; set; }

    public decimal? AlMontantHt { get; set; }

    public decimal? AlMontantTtc { get; set; }

    public short? AlFactPoids { get; set; }

    public short? AlEscompte { get; set; }

    public string? RpCode { get; set; }

    public byte[]? CbRpCode { get; set; }

    public int? AlQteRessource { get; set; }

    public int? AlNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? Divers1 { get; set; }

    public string? RefClient { get; set; }

    public string? AlCodeTaxe1 { get; set; }

    public string? AlCodeTaxe2 { get; set; }

    public string? AlCodeTaxe3 { get; set; }

    public int? AlNoSousTotal { get; set; }

    public virtual FAboentete AbNoNavigation { get; set; } = null!;

    public virtual FTaxe? AlCodeTaxe1Navigation { get; set; }

    public virtual FTaxe? AlCodeTaxe2Navigation { get; set; }

    public virtual FTaxe? AlCodeTaxe3Navigation { get; set; }

    public virtual FArticle? ArRefNavigation { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual ICollection<FAboligneinfo> FAboligneinfos { get; set; } = new List<FAboligneinfo>();

    public virtual FRessourceprod? RpCodeNavigation { get; set; }
}
