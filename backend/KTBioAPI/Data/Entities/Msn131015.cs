using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class Msn131015
{
    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public string? CtNum { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public int? DlNo { get; set; }

    public DateTime? Expr4 { get; set; }

    public short? Expr1 { get; set; }

    public string? Expr2 { get; set; }

    public short Expr3 { get; set; }

    public string? LsNoSerie { get; set; }

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public string? FaIntitule { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public string? CtIntitule { get; set; }
}
