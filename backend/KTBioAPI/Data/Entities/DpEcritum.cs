using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpEcritum
{
    public int? EaEcno { get; set; }

    public short EaNanalytique { get; set; }

    public string EaCanum { get; set; } = null!;

    public decimal? EaEamontant { get; set; }

    public decimal? EaEaquantite { get; set; }

    public short? EaEaligne { get; set; }

    public DateTime? EaEadate { get; set; }

    public string EaCgnum { get; set; } = null!;

    public string? EaSens { get; set; }

    public string EaJanum { get; set; } = null!;

    public string? EaErpiece { get; set; }

    public string? EaErrefpiece { get; set; }

    public string? EaErintitule { get; set; }
}
