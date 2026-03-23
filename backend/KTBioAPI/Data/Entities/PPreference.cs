using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PPreference
{
    public string? PrRefEsc { get; set; }

    public short? PrAlerteAg { get; set; }

    public short? PrDelaiPreAlert { get; set; }

    public short? PrConfirmation { get; set; }

    public short? PrChoixRemise { get; set; }

    public short? PrUnitePoids { get; set; }

    public short? PrMarge { get; set; }

    public short? PrCodeEan { get; set; }

    public short? PrPrefixe20 { get; set; }

    public short? PrUnitePrix { get; set; }

    public short? PrPoids { get; set; }

    public short? PrModifImport { get; set; }

    public short? PrStockNeg { get; set; }

    public short? PrDelaiLivr { get; set; }

    public string? PrRefTaxeNp { get; set; }

    public string? CgNumCli { get; set; }

    public string? CgNumFrs { get; set; }

    public string? CtNum { get; set; }

    public short? PrLignesAfficheur { get; set; }

    public short? PrColonnesAfficheur { get; set; }

    public short? PrIdentifCaissier { get; set; }

    public short? PrPrixTtc { get; set; }

    public string? CgNumVirement { get; set; }

    public short? PrSouche { get; set; }

    public short? PrRegroupTicket { get; set; }

    public short? PrRegroupRglt { get; set; }

    public string? PrEmail { get; set; }

    public int? DeNo { get; set; }

    public short? PrArtNonLivre { get; set; }

    public short? PrRecalculModele { get; set; }

    public short? PrMajPafrs { get; set; }

    public short? PrCreeFrs { get; set; }

    public short? NReglement { get; set; }

    public short? PrDateFact { get; set; }

    public short? PrCliCaisse { get; set; }

    public string? CgNumComptoirDebit { get; set; }

    public string? CgNumComptoirCredit { get; set; }

    public short? PrFondCaisse { get; set; }

    public short? PrIntegration { get; set; }

    public short? PrComptaBonAchat { get; set; }

    public decimal? PrMontantMaxTicket { get; set; }

    public int? CdNo { get; set; }

    public short? PrFormatFacture { get; set; }

    public string? PrCertificat { get; set; }

    public short? PrCreeArticle { get; set; }

    public short? PrCreeTiers { get; set; }

    public short? PrCreeAffaire { get; set; }

    public short? PrEfacture { get; set; }

    public int CbMarq { get; set; }
}
