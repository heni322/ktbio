using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpStockADate
{
    public int? StdDeno { get; set; }

    public string StdDeintitule { get; set; } = null!;

    public string StdArref { get; set; } = null!;

    public string? StdArdesing { get; set; }

    public string? StdArsuivistock { get; set; }

    public string? StdAgn01 { get; set; }

    public string? StdAgn02 { get; set; }

    public string? StdEnumere1 { get; set; }

    public string? StdEnumere2 { get; set; }

    public string? StdAeref { get; set; }

    public string? StdLsnoserie { get; set; }

    public DateTime? StdPeremption { get; set; }

    public DateTime? StdFabrication { get; set; }

    public string StdDopiece { get; set; } = null!;

    public DateTime? StdDodate { get; set; }

    public DateTime? StdDldatebl { get; set; }

    public decimal? StdQte { get; set; }

    public short DoType { get; set; }

    public short? DlMvtStock { get; set; }

    public short? DlTypePl { get; set; }

    public short? ArSuivistock { get; set; }

    public decimal? StdCmup { get; set; }

    public decimal? StdPr { get; set; }

    public byte[]? StdArtUk { get; set; }

    public string? StdDldatean { get; set; }

    public string? StdDldateblsemestre { get; set; }

    public string? StdDldatebltrimestre { get; set; }

    public string? StdDldateblmois { get; set; }

    public string? StdDldateblweek { get; set; }

    public string StdDldatebljour { get; set; } = null!;
}
