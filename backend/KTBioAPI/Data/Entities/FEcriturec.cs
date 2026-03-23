using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturec
{
    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public int EcNo { get; set; }

    public int? EcNoLink { get; set; }

    public DateTime JmDate { get; set; }

    public short? EcJour { get; set; }

    public DateTime? EcDate { get; set; }

    public string? EcPiece { get; set; }

    public byte[]? CbEcPiece { get; set; }

    public string? EcRefPiece { get; set; }

    public byte[]? CbEcRefPiece { get; set; }

    public string? EcTresoPiece { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public string? CgNumCont { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public string? EcIntitule { get; set; }

    public short? NReglement { get; set; }

    public DateTime? EcEcheance { get; set; }

    public decimal? EcParite { get; set; }

    public decimal? EcQuantite { get; set; }

    public short? NDevise { get; set; }

    public short? EcSens { get; set; }

    public decimal? EcMontant { get; set; }

    public short? EcLettre { get; set; }

    public string? EcLettrage { get; set; }

    public short? EcPoint { get; set; }

    public string? EcPointage { get; set; }

    public short? EcImpression { get; set; }

    public short? EcCloture { get; set; }

    public short? EcCtype { get; set; }

    public short? EcRappel { get; set; }

    public string? CtNumCont { get; set; }

    public short? EcLettreQ { get; set; }

    public string? EcLettrageQ { get; set; }

    public short? EcAntype { get; set; }

    public short? EcRtype { get; set; }

    public decimal? EcDevise { get; set; }

    public short? EcRemise { get; set; }

    public short? EcExportExpert { get; set; }

    public string? TaCode { get; set; }

    public byte[]? CbTaCode { get; set; }

    public short? EcNorme { get; set; }

    public short? TaProvenance { get; set; }

    public short? EcPenalType { get; set; }

    public DateTime? EcDatePenal { get; set; }

    public DateTime? EcDateRelance { get; set; }

    public DateTime? EcDateRappro { get; set; }

    public string? EcReference { get; set; }

    public short? EcStatusRegle { get; set; }

    public decimal? EcMontantRegle { get; set; }

    public DateTime? EcDateRegle { get; set; }

    public int? EcRib { get; set; }

    public DateTime? EcDateOp { get; set; }

    public int? EcNoCloture { get; set; }

    public short? EcExportRappro { get; set; }

    public Guid? EcFactureGuid { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? EcDateCloture { get; set; }

    public short? EcStatFinexKap { get; set; }

    public Guid? EcFactureFile { get; set; }

    public byte[]? CbHash { get; set; }

    public short? CbHashVersion { get; set; }

    public DateTime? CbHashDate { get; set; }

    public int? CbHashOrder { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;

    public virtual FComptet? CtNumNavigation { get; set; }

    public virtual ICollection<FBonapayerhisto> FBonapayerhistos { get; set; } = new List<FBonapayerhisto>();

    public virtual FDrecouvrementec? FDrecouvrementec { get; set; }

    public virtual ICollection<FEcriturea> FEcritureas { get; set; } = new List<FEcriturea>();

    public virtual ICollection<FEcriturecmedium> FEcriturecmedia { get; set; } = new List<FEcriturecmedium>();

    public virtual ICollection<FEcriturecregul> FEcriturecregulEcNoNavigations { get; set; } = new List<FEcriturecregul>();

    public virtual FEcriturecregul? FEcriturecregulEcNoRegulNavigation { get; set; }

    public virtual ICollection<FEextraitec> FEextraitecs { get; set; } = new List<FEextraitec>();

    public virtual ICollection<FEfinancierec> FEfinancierecs { get; set; } = new List<FEfinancierec>();

    public virtual FRegrevision? FRegrevision { get; set; }

    public virtual FRegtaxe? FRegtaxe { get; set; }

    public virtual FTaxe? TaCodeNavigation { get; set; }
}
