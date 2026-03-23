using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class VTotalFacture
{
    public string CtNum { get; set; } = null!;

    public string? CtIntitule { get; set; }

    public short? Type { get; set; }

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public decimal? MontantHt { get; set; }

    public decimal? MontantTtc { get; set; }
}
