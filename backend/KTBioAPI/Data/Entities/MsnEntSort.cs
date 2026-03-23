using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class MsnEntSort
{
    public string? DoPiece { get; set; }

    public string? CtNum { get; set; }

    public DateTime? DoDate { get; set; }

    public string? ArRef { get; set; }

    public string? LsNoSerie { get; set; }

    public DateTime? LsFabrication { get; set; }

    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public string? CtIntitule { get; set; }

    public string? DoRef { get; set; }

    public decimal? EuQte { get; set; }

    public string? DlDesign { get; set; }

    public string Expr1 { get; set; } = null!;

    public short? ArSuiviStock { get; set; }
}
