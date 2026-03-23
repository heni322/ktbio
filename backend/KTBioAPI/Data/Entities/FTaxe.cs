using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTaxe
{
    public string? TaIntitule { get; set; }

    public byte[]? CbTaIntitule { get; set; }

    public short? TaTtaux { get; set; }

    public decimal? TaTaux { get; set; }

    public short? TaType { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public int TaNo { get; set; }

    public string TaCode { get; set; } = null!;

    public byte[]? CbTaCode { get; set; }

    public short? TaNp { get; set; }

    public short? TaSens { get; set; }

    public short? TaProvenance { get; set; }

    public string? TaRegroup { get; set; }

    public byte[]? CbTaRegroup { get; set; }

    public decimal? TaAssujet { get; set; }

    public string? TaGrilleBase { get; set; }

    public string? TaGrilleTaxe { get; set; }

    public string? TaEdiCode { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;

    public virtual ICollection<FAboligne> FAboligneAlCodeTaxe1Navigations { get; set; } = new List<FAboligne>();

    public virtual ICollection<FAboligne> FAboligneAlCodeTaxe2Navigations { get; set; } = new List<FAboligne>();

    public virtual ICollection<FAboligne> FAboligneAlCodeTaxe3Navigations { get; set; } = new List<FAboligne>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxe1Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxe2Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxe3Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxeAnc1Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxeAnc2Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FArtcomptum> FArtcomptumAcpComptaCptTaxeAnc3Navigations { get; set; } = new List<FArtcomptum>();

    public virtual ICollection<FCompteg> FComptegs { get; set; } = new List<FCompteg>();

    public virtual ICollection<FDocentete> FDocenteteDoCodeTaxe1Navigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocentete> FDocenteteDoCodeTaxe2Navigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocentete> FDocenteteDoCodeTaxe3Navigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocligne> FDocligneDlCodeTaxe1Navigations { get; set; } = new List<FDocligne>();

    public virtual ICollection<FDocligne> FDocligneDlCodeTaxe2Navigations { get; set; } = new List<FDocligne>();

    public virtual ICollection<FDocligne> FDocligneDlCodeTaxe3Navigations { get; set; } = new List<FDocligne>();

    public virtual ICollection<FEcriturec> FEcriturecs { get; set; } = new List<FEcriturec>();

    public virtual ICollection<FEfinancier> FEfinanciers { get; set; } = new List<FEfinancier>();

    public virtual ICollection<FEtaxe> FEtaxes { get; set; } = new List<FEtaxe>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxe1Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxe2Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxe3Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxeAnc1Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxeAnc2Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FFamcomptum> FFamcomptumFcpComptaCptTaxeAnc3Navigations { get; set; } = new List<FFamcomptum>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode01Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode02Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode03Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode04Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode05Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode06Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode07Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode08Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode09Navigations { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FRegtaxe> FRegtaxeTaCode10Navigations { get; set; } = new List<FRegtaxe>();
}
