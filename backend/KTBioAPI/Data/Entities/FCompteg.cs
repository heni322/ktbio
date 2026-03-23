using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCompteg
{
    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short? CgType { get; set; }

    public string? CgIntitule { get; set; }

    public string? CgClassement { get; set; }

    public byte[]? CbCgClassement { get; set; }

    public short? NNature { get; set; }

    public short? CgReport { get; set; }

    public string? CrNum { get; set; }

    public byte[]? CbCrNum { get; set; }

    public string? CgRaccourci { get; set; }

    public byte[]? CbCgRaccourci { get; set; }

    public short? CgSaut { get; set; }

    public short? CgRegroup { get; set; }

    public short? CgAnalytique { get; set; }

    public short? CgEcheance { get; set; }

    public short? CgQuantite { get; set; }

    public short? CgLettrage { get; set; }

    public short? CgTiers { get; set; }

    public DateTime? CgDateCreate { get; set; }

    public short? CgDevise { get; set; }

    public short? NDevise { get; set; }

    public string? TaCode { get; set; }

    public byte[]? CbTaCode { get; set; }

    public short? CgSommeil { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? CgReportAnal { get; set; }

    public short? CgLettrageSaisie { get; set; }

    public virtual FCompter? CrNumNavigation { get; set; }

    public virtual ICollection<FAboentete> FAboentetes { get; set; } = new List<FAboentete>();

    public virtual ICollection<FArtcomptum> FArtcompta { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FBanque> FBanqueCgNumFraisOpcvmNavigations { get; set; } = new List<FBanque>();

    public virtual ICollection<FBanque> FBanqueCgNumMoinsValueOpcvmNavigations { get; set; } = new List<FBanque>();

    public virtual ICollection<FBanque> FBanqueCgNumPlusValueOpcvmNavigations { get; set; } = new List<FBanque>();

    public virtual ICollection<FBanque> FBanqueCgNumTvaopcvmNavigations { get; set; } = new List<FBanque>();

    public virtual ICollection<FCompteabudgetg> FCompteabudgetgs { get; set; } = new List<FCompteabudgetg>();

    public virtual ICollection<FComptega> FComptegas { get; set; } = new List<FComptega>();

    public virtual FComptegbudget? FComptegbudget { get; set; }

    public virtual ICollection<FComptegnote> FComptegnotes { get; set; } = new List<FComptegnote>();

    public virtual ICollection<FComptetg> FComptetgs { get; set; } = new List<FComptetg>();

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual ICollection<FCreglement> FCreglementCgNumContNavigations { get; set; } = new List<FCreglement>();

    public virtual ICollection<FCreglement> FCreglementCgNumEcartNavigations { get; set; } = new List<FCreglement>();

    public virtual ICollection<FCreglement> FCreglementCgNumNavigations { get; set; } = new List<FCreglement>();

    public virtual ICollection<FDocentete> FDocentetes { get; set; } = new List<FDocentete>();

    public virtual ICollection<FEbudget> FEbudgets { get; set; } = new List<FEbudget>();

    public virtual ICollection<FEcriturec> FEcriturecs { get; set; } = new List<FEcriturec>();

    public virtual ICollection<FEcrituref> FEcriturefs { get; set; } = new List<FEcrituref>();

    public virtual ICollection<FEcriturer> FEcriturers { get; set; } = new List<FEcriturer>();

    public virtual ICollection<FEfinancier> FEfinanciers { get; set; } = new List<FEfinancier>();

    public virtual ICollection<FEtaxe> FEtaxes { get; set; } = new List<FEtaxe>();

    public virtual ICollection<FFamcomptum> FFamcompta { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FJournaux> FJournauxes { get; set; } = new List<FJournaux>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum01Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum02Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum03Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum04Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum05Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum06Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum07Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum08Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum09Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeCgNum10Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FTaxe> FTaxes { get; set; } = new List<FTaxe>();

    public virtual FTaxe? TaCodeNavigation { get; set; }
}
