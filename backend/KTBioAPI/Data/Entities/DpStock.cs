using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpStock
{
    public int StoDepNum { get; set; }

    public string? StoDep { get; set; }

    public string? StoDepprinc { get; set; }

    public byte[]? StoArtUk { get; set; }

    public string StoArtNum { get; set; } = null!;

    public int? StoAgno1 { get; set; }

    public int? StoAgno2 { get; set; }

    public string? StoEnumere1 { get; set; }

    public string? StoEnumere2 { get; set; }

    public decimal? StoRes { get; set; }

    public decimal? StoCde { get; set; }

    public decimal? StoAterme { get; set; }

    public decimal? StoMontant { get; set; }

    public decimal? StoQte { get; set; }

    public decimal? StoPrepa { get; set; }

    public decimal? StoDispo { get; set; }

    public decimal? StoQtemini { get; set; }

    public decimal? StoQtemaxi { get; set; }

    public int? StoEmplacementPrNum { get; set; }

    public string? StoEmplacementPrLib { get; set; }
}
