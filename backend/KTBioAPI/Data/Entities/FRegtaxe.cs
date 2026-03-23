using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FRegtaxe
{
    public int EcNo { get; set; }

    public int? RtNo { get; set; }

    public short? RtType { get; set; }

    public DateTime? RtDateReg { get; set; }

    public DateTime? RtDatePiece { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public short? TaProvenance01 { get; set; }

    public short? TaProvenance02 { get; set; }

    public short? TaProvenance03 { get; set; }

    public short? TaProvenance04 { get; set; }

    public short? TaProvenance05 { get; set; }

    public short? TaProvenance06 { get; set; }

    public short? TaProvenance07 { get; set; }

    public short? TaProvenance08 { get; set; }

    public short? TaProvenance09 { get; set; }

    public short? TaProvenance10 { get; set; }

    public string? CgNum01 { get; set; }

    public string? CgNum02 { get; set; }

    public string? CgNum03 { get; set; }

    public string? CgNum04 { get; set; }

    public string? CgNum05 { get; set; }

    public string? CgNum06 { get; set; }

    public string? CgNum07 { get; set; }

    public string? CgNum08 { get; set; }

    public string? CgNum09 { get; set; }

    public string? CgNum10 { get; set; }

    public short? TaTtaux01 { get; set; }

    public short? TaTtaux02 { get; set; }

    public short? TaTtaux03 { get; set; }

    public short? TaTtaux04 { get; set; }

    public short? TaTtaux05 { get; set; }

    public short? TaTtaux06 { get; set; }

    public short? TaTtaux07 { get; set; }

    public short? TaTtaux08 { get; set; }

    public short? TaTtaux09 { get; set; }

    public short? TaTtaux10 { get; set; }

    public decimal? TaTaux01 { get; set; }

    public decimal? TaTaux02 { get; set; }

    public decimal? TaTaux03 { get; set; }

    public decimal? TaTaux04 { get; set; }

    public decimal? TaTaux05 { get; set; }

    public decimal? TaTaux06 { get; set; }

    public decimal? TaTaux07 { get; set; }

    public decimal? TaTaux08 { get; set; }

    public decimal? TaTaux09 { get; set; }

    public decimal? TaTaux10 { get; set; }

    public decimal? RtBase01 { get; set; }

    public decimal? RtBase02 { get; set; }

    public decimal? RtBase03 { get; set; }

    public decimal? RtBase04 { get; set; }

    public decimal? RtBase05 { get; set; }

    public decimal? RtBase06 { get; set; }

    public decimal? RtBase07 { get; set; }

    public decimal? RtBase08 { get; set; }

    public decimal? RtBase09 { get; set; }

    public decimal? RtBase10 { get; set; }

    public decimal? RtMontant01 { get; set; }

    public decimal? RtMontant02 { get; set; }

    public decimal? RtMontant03 { get; set; }

    public decimal? RtMontant04 { get; set; }

    public decimal? RtMontant05 { get; set; }

    public decimal? RtMontant06 { get; set; }

    public decimal? RtMontant07 { get; set; }

    public decimal? RtMontant08 { get; set; }

    public decimal? RtMontant09 { get; set; }

    public decimal? RtMontant10 { get; set; }

    public string? TaCode01 { get; set; }

    public string? TaCode02 { get; set; }

    public string? TaCode03 { get; set; }

    public string? TaCode04 { get; set; }

    public string? TaCode05 { get; set; }

    public string? TaCode06 { get; set; }

    public string? TaCode07 { get; set; }

    public string? TaCode08 { get; set; }

    public string? TaCode09 { get; set; }

    public string? TaCode10 { get; set; }

    public DateTime? JmDate { get; set; }

    public string? RtNbFactures { get; set; }

    public short? RtTypeTransac { get; set; }

    public string? RtNumeroDe { get; set; }

    public string? RtNumeroA { get; set; }

    public string? RtFactureRectif { get; set; }

    public string? RtMotif { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbHash { get; set; }

    public short? CbHashVersion { get; set; }

    public DateTime? CbHashDate { get; set; }

    public int? CbHashOrder { get; set; }

    public virtual FCompteg? CgNum01Navigation { get; set; }

    public virtual FCompteg? CgNum02Navigation { get; set; }

    public virtual FCompteg? CgNum03Navigation { get; set; }

    public virtual FCompteg? CgNum04Navigation { get; set; }

    public virtual FCompteg? CgNum05Navigation { get; set; }

    public virtual FCompteg? CgNum06Navigation { get; set; }

    public virtual FCompteg? CgNum07Navigation { get; set; }

    public virtual FCompteg? CgNum08Navigation { get; set; }

    public virtual FCompteg? CgNum09Navigation { get; set; }

    public virtual FCompteg? CgNum10Navigation { get; set; }

    public virtual FComptet? CtNumNavigation { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;

    public virtual FTaxe? TaCode01Navigation { get; set; }

    public virtual FTaxe? TaCode02Navigation { get; set; }

    public virtual FTaxe? TaCode03Navigation { get; set; }

    public virtual FTaxe? TaCode04Navigation { get; set; }

    public virtual FTaxe? TaCode05Navigation { get; set; }

    public virtual FTaxe? TaCode06Navigation { get; set; }

    public virtual FTaxe? TaCode07Navigation { get; set; }

    public virtual FTaxe? TaCode08Navigation { get; set; }

    public virtual FTaxe? TaCode09Navigation { get; set; }

    public virtual FTaxe? TaCode10Navigation { get; set; }
}
