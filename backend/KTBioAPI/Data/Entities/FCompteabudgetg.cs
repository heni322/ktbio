using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCompteabudgetg
{
    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short? CaBgtrepart01 { get; set; }

    public short? CaBgtrepart02 { get; set; }

    public short? CaBgtrepart03 { get; set; }

    public short? CaBgtrepart04 { get; set; }

    public short? CaBgtrepart05 { get; set; }

    public short? CaBgtrepart06 { get; set; }

    public decimal? CaBgvrepart01 { get; set; }

    public decimal? CaBgvrepart02 { get; set; }

    public decimal? CaBgvrepart03 { get; set; }

    public decimal? CaBgvrepart04 { get; set; }

    public decimal? CaBgvrepart05 { get; set; }

    public decimal? CaBgvrepart06 { get; set; }

    public decimal? CaBgvrepartQ01 { get; set; }

    public decimal? CaBgvrepartQ02 { get; set; }

    public decimal? CaBgvrepartQ03 { get; set; }

    public decimal? CaBgvrepartQ04 { get; set; }

    public decimal? CaBgvrepartQ05 { get; set; }

    public decimal? CaBgvrepartQ06 { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;

    public virtual FCompteabudget FCompteabudget { get; set; } = null!;
}
