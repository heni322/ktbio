using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FPiecea
{
    public int PiNo { get; set; }

    public short PgLigne { get; set; }

    public short? PaLigne { get; set; }

    public short? NAnalytique { get; set; }

    public string? CaNum { get; set; }

    public short? PaTmontant { get; set; }

    public decimal? PaVmontant { get; set; }

    public short? PaTquantite { get; set; }

    public decimal? PaVquantite { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FPieceg FPieceg { get; set; } = null!;
}
