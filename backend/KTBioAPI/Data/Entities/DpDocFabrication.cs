using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpDocFabrication
{
    public string? DfDocnum { get; set; }

    public short? DfDoctype { get; set; }

    public int DfPk { get; set; }

    public byte[]? DfDocnumbin { get; set; }

    public string? DfType { get; set; }

    public string? DfDoref { get; set; }

    public string? DfDocan { get; set; }

    public string? DfDocsemestre { get; set; }

    public string? DfDoctrimestre { get; set; }

    public string? DfDocmois { get; set; }

    public string? DfDocweek { get; set; }

    public string DfDocjour { get; set; } = null!;

    public DateTime? DfDocdate { get; set; }
}
