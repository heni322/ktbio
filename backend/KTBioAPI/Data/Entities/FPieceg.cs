using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FPieceg
{
    public int PiNo { get; set; }

    public short PgLigne { get; set; }

    public string? PgJour { get; set; }

    public string? PgPiece { get; set; }

    public string? PgRefPiece { get; set; }

    public string? CgNum { get; set; }

    public string? CgNumCont { get; set; }

    public string? CtNum { get; set; }

    public string? PgIntitule { get; set; }

    public short? NReglement { get; set; }

    public string? PgEcheance { get; set; }

    public string? PgParite { get; set; }

    public string? PgQuantite { get; set; }

    public short? NDevise { get; set; }

    public short? PgSens { get; set; }

    public string? PgMontant { get; set; }

    public string? CtNumCont { get; set; }

    public string? PgDevise { get; set; }

    public string? PgInfoL01 { get; set; }

    public string? PgInfoL02 { get; set; }

    public string? PgInfoL03 { get; set; }

    public string? PgInfoL04 { get; set; }

    public string? PgInfoL05 { get; set; }

    public string? PgInfoL06 { get; set; }

    public string? PgInfoL07 { get; set; }

    public string? PgInfoL08 { get; set; }

    public string? PgInfoL09 { get; set; }

    public string? PgInfoL10 { get; set; }

    public string? PgInfoL11 { get; set; }

    public string? PgInfoL12 { get; set; }

    public string? PgInfoL13 { get; set; }

    public string? PgInfoL14 { get; set; }

    public string? PgInfoL15 { get; set; }

    public string? PgInfoL16 { get; set; }

    public string? PgInfoL17 { get; set; }

    public string? PgInfoL18 { get; set; }

    public string? PgInfoL19 { get; set; }

    public string? PgInfoL20 { get; set; }

    public string? PgInfoL21 { get; set; }

    public string? PgInfoL22 { get; set; }

    public string? PgInfoL23 { get; set; }

    public string? PgInfoL24 { get; set; }

    public string? PgInfoL25 { get; set; }

    public string? PgInfoL26 { get; set; }

    public string? PgInfoL27 { get; set; }

    public string? PgInfoL28 { get; set; }

    public string? PgInfoL29 { get; set; }

    public string? PgInfoL30 { get; set; }

    public string? PgInfoL31 { get; set; }

    public string? PgInfoL32 { get; set; }

    public string? PgInfoL33 { get; set; }

    public string? PgInfoL34 { get; set; }

    public string? PgInfoL35 { get; set; }

    public string? PgInfoL36 { get; set; }

    public string? PgInfoL37 { get; set; }

    public string? PgInfoL38 { get; set; }

    public string? PgInfoL39 { get; set; }

    public string? PgInfoL40 { get; set; }

    public string? PgInfoL41 { get; set; }

    public string? PgInfoL42 { get; set; }

    public string? PgInfoL43 { get; set; }

    public string? PgInfoL44 { get; set; }

    public string? PgInfoL45 { get; set; }

    public string? PgInfoL46 { get; set; }

    public string? PgInfoL47 { get; set; }

    public string? PgInfoL48 { get; set; }

    public string? PgInfoL49 { get; set; }

    public string? PgInfoL50 { get; set; }

    public string? PgInfoL51 { get; set; }

    public string? PgInfoL52 { get; set; }

    public string? PgInfoL53 { get; set; }

    public string? PgInfoL54 { get; set; }

    public string? PgInfoL55 { get; set; }

    public string? PgInfoL56 { get; set; }

    public string? PgInfoL57 { get; set; }

    public string? PgInfoL58 { get; set; }

    public string? PgInfoL59 { get; set; }

    public string? PgInfoL60 { get; set; }

    public string? PgInfoL61 { get; set; }

    public string? PgInfoL62 { get; set; }

    public string? PgInfoL63 { get; set; }

    public string? PgInfoL64 { get; set; }

    public string? TaCode { get; set; }

    public short? TaProvenance { get; set; }

    public string? PgReference { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FPiecea> FPieceas { get; set; } = new List<FPiecea>();

    public virtual FPiece PiNoNavigation { get; set; } = null!;
}
