using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class UpdateLibelle210814
{
    public double? NoEcr { get; set; }

    public string? NoPie { get; set; }

    public string? RefPie { get; set; }

    public string? NvLib { get; set; }

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

    public string? Expr1 { get; set; }

    public string? Expr2 { get; set; }
}
