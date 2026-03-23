using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptegbudgetum
{
    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public short? CgBatrepart01 { get; set; }

    public short? CgBatrepart02 { get; set; }

    public short? CgBatrepart03 { get; set; }

    public short? CgBatrepart04 { get; set; }

    public short? CgBatrepart05 { get; set; }

    public short? CgBatrepart06 { get; set; }

    public decimal? CgBavrepart01 { get; set; }

    public decimal? CgBavrepart02 { get; set; }

    public decimal? CgBavrepart03 { get; set; }

    public decimal? CgBavrepart04 { get; set; }

    public decimal? CgBavrepart05 { get; set; }

    public decimal? CgBavrepart06 { get; set; }

    public decimal? CgBavrepartQ01 { get; set; }

    public decimal? CgBavrepartQ02 { get; set; }

    public decimal? CgBavrepartQ03 { get; set; }

    public decimal? CgBavrepartQ04 { get; set; }

    public decimal? CgBavrepartQ05 { get; set; }

    public decimal? CgBavrepartQ06 { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptegbudget CgNumNavigation { get; set; } = null!;

    public virtual FComptea FComptea { get; set; } = null!;
}
