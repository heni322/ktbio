using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArticle
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? ArDesign { get; set; }

    public byte[]? CbArDesign { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public string? ArSubstitut { get; set; }

    public byte[]? CbArSubstitut { get; set; }

    public string? ArRaccourci { get; set; }

    public byte[]? CbArRaccourci { get; set; }

    public short? ArGarantie { get; set; }

    public short? ArUnitePoids { get; set; }

    public decimal? ArPoidsNet { get; set; }

    public decimal? ArPoidsBrut { get; set; }

    public short? ArUniteVen { get; set; }

    public decimal? ArPrixAch { get; set; }

    public decimal? ArCoef { get; set; }

    public decimal? ArPrixVen { get; set; }

    public short? ArPrixTtc { get; set; }

    public short? ArGamme1 { get; set; }

    public short? ArGamme2 { get; set; }

    public short? ArSuiviStock { get; set; }

    public short? ArNomencl { get; set; }

    public string? ArStat01 { get; set; }

    public string? ArStat02 { get; set; }

    public string? ArStat03 { get; set; }

    public string? ArStat04 { get; set; }

    public string? ArStat05 { get; set; }

    public short? ArEscompte { get; set; }

    public short? ArDelai { get; set; }

    public short? ArHorsStat { get; set; }

    public short? ArVteDebit { get; set; }

    public short? ArNotImp { get; set; }

    public short? ArSommeil { get; set; }

    public string? ArLangue1 { get; set; }

    public string? ArLangue2 { get; set; }

    public string? ArEdiCode { get; set; }

    public string? ArCodeBarre { get; set; }

    public byte[]? CbArCodeBarre { get; set; }

    public string? ArCodeFiscal { get; set; }

    public string? ArPays { get; set; }

    public string? ArFrais01FrDenomination { get; set; }

    public decimal? ArFrais01FrRem01RemValeur { get; set; }

    public short? ArFrais01FrRem01RemType { get; set; }

    public decimal? ArFrais01FrRem02RemValeur { get; set; }

    public short? ArFrais01FrRem02RemType { get; set; }

    public decimal? ArFrais01FrRem03RemValeur { get; set; }

    public short? ArFrais01FrRem03RemType { get; set; }

    public string? ArFrais02FrDenomination { get; set; }

    public decimal? ArFrais02FrRem01RemValeur { get; set; }

    public short? ArFrais02FrRem01RemType { get; set; }

    public decimal? ArFrais02FrRem02RemValeur { get; set; }

    public short? ArFrais02FrRem02RemType { get; set; }

    public decimal? ArFrais02FrRem03RemValeur { get; set; }

    public short? ArFrais02FrRem03RemType { get; set; }

    public string? ArFrais03FrDenomination { get; set; }

    public decimal? ArFrais03FrRem01RemValeur { get; set; }

    public short? ArFrais03FrRem01RemType { get; set; }

    public decimal? ArFrais03FrRem02RemValeur { get; set; }

    public short? ArFrais03FrRem02RemType { get; set; }

    public decimal? ArFrais03FrRem03RemValeur { get; set; }

    public short? ArFrais03FrRem03RemType { get; set; }

    public short? ArCondition { get; set; }

    public decimal? ArPunet { get; set; }

    public short? ArContremarque { get; set; }

    public short? ArFactPoids { get; set; }

    public short? ArFactForfait { get; set; }

    public DateTime? ArDateCreation { get; set; }

    public short? ArSaisieVar { get; set; }

    public short? ArTransfere { get; set; }

    public short? ArPublie { get; set; }

    public DateTime? ArDateModif { get; set; }

    public string? ArPhoto { get; set; }

    public decimal? ArPrixAchNouv { get; set; }

    public decimal? ArCoefNouv { get; set; }

    public decimal? ArPrixVenNouv { get; set; }

    public DateTime? ArDateApplication { get; set; }

    public decimal? ArCoutStd { get; set; }

    public decimal? ArQteComp { get; set; }

    public decimal? ArQteOperatoire { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public short? ArPrevision { get; set; }

    public int? ClNo1 { get; set; }

    public int? CbClNo1 { get; set; }

    public int? ClNo2 { get; set; }

    public int? CbClNo2 { get; set; }

    public int? ClNo3 { get; set; }

    public int? CbClNo3 { get; set; }

    public int? ClNo4 { get; set; }

    public int? CbClNo4 { get; set; }

    public short? ArType { get; set; }

    public string? RpCodeDefaut { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? UpnCodeCatalogue { get; set; }

    public byte[]? CbArEdiCode { get; set; }

    public short? ArNature { get; set; }

    public short? ArDelaiFabrication { get; set; }

    public short? ArNbColis { get; set; }

    public short? ArDelaiPeremption { get; set; }

    public short? ArDelaiSecurite { get; set; }

    public short? ArFictif { get; set; }

    public short? ArSousTraitance { get; set; }

    public short? ArTypeLancement { get; set; }

    public short? ArCycle { get; set; }

    public short? ArCriticite { get; set; }

    public virtual FArticle? ArSubstitutNavigation { get; set; }

    public virtual FCatalogue? CbClNo1Navigation { get; set; }

    public virtual FCatalogue? CbClNo2Navigation { get; set; }

    public virtual FCatalogue? CbClNo3Navigation { get; set; }

    public virtual FCatalogue? CbClNo4Navigation { get; set; }

    public virtual ICollection<FAboligne> FAbolignes { get; set; } = new List<FAboligne>();

    public virtual ICollection<FArtclient> FArtclients { get; set; } = new List<FArtclient>();

    public virtual ICollection<FArtcompo> FArtcompos { get; set; } = new List<FArtcompo>();

    public virtual ICollection<FArtcomptum> FArtcompta { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtenumref> FArtenumrefs { get; set; } = new List<FArtenumref>();

    public virtual ICollection<FArtfourniss> FArtfournisses { get; set; } = new List<FArtfourniss>();

    public virtual ICollection<FArtgamme> FArtgammes { get; set; } = new List<FArtgamme>();

    public virtual ICollection<FArtgloss> FArtglosses { get; set; } = new List<FArtgloss>();

    public virtual ICollection<FArticlemedium> FArticlemedia { get; set; } = new List<FArticlemedium>();

    public virtual ICollection<FArticleressource> FArticleressources { get; set; } = new List<FArticleressource>();

    public virtual ICollection<FArtmodele> FArtmodeles { get; set; } = new List<FArtmodele>();

    public virtual ICollection<FArtprix> FArtprixes { get; set; } = new List<FArtprix>();

    public virtual ICollection<FArtstockempl> FArtstockempls { get; set; } = new List<FArtstockempl>();

    public virtual ICollection<FArtstock> FArtstocks { get; set; } = new List<FArtstock>();

    public virtual ICollection<FClavier> FClaviers { get; set; } = new List<FClavier>();

    public virtual ICollection<FCondition> FConditions { get; set; } = new List<FCondition>();

    public virtual ICollection<FDocligne> FDoclignes { get; set; } = new List<FDocligne>();

    public virtual ICollection<FGamstockempl> FGamstockempls { get; set; } = new List<FGamstockempl>();

    public virtual ICollection<FGamstock> FGamstocks { get; set; } = new List<FGamstock>();

    public virtual ICollection<FLignearchive> FLignearchives { get; set; } = new List<FLignearchive>();

    public virtual ICollection<FLotfifo> FLotfifos { get; set; } = new List<FLotfifo>();

    public virtual ICollection<FLotserie> FLotseries { get; set; } = new List<FLotserie>();

    public virtual ICollection<FNomenclat> FNomenclatArRefNavigations { get; set; } = new List<FNomenclat>();

    public virtual ICollection<FNomenclat> FNomenclatNoRefDetNavigations { get; set; } = new List<FNomenclat>();

    public virtual ICollection<FPrevision> FPrevisions { get; set; } = new List<FPrevision>();

    public virtual ICollection<FProjethisto> FProjethistoArRefComposantNavigations { get; set; } = new List<FProjethisto>();

    public virtual ICollection<FProjethisto> FProjethistoArRefComposeNavigations { get; set; } = new List<FProjethisto>();

    public virtual ICollection<FProjetplanning> FProjetplanningArRefComposantNavigations { get; set; } = new List<FProjetplanning>();

    public virtual ICollection<FProjetplanning> FProjetplanningArRefComposeNavigations { get; set; } = new List<FProjetplanning>();

    public virtual ICollection<FRessourceprod> FRessourceprods { get; set; } = new List<FRessourceprod>();

    public virtual ICollection<FTarifcond> FTarifconds { get; set; } = new List<FTarifcond>();

    public virtual ICollection<FTarifgam> FTarifgams { get; set; } = new List<FTarifgam>();

    public virtual ICollection<FTarifqte> FTarifqtes { get; set; } = new List<FTarifqte>();

    public virtual ICollection<FTarif> FTarifs { get; set; } = new List<FTarif>();

    public virtual ICollection<FArticle> InverseArSubstitutNavigation { get; set; } = new List<FArticle>();

    public virtual FRessourceprod? RpCodeDefautNavigation { get; set; }
}
