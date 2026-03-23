using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class View2
{
    public string? CtNum { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? DoRef { get; set; }

    public string? Expr1 { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public int? DlNo { get; set; }

    public int? DlNoOut { get; set; }

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public decimal? LsQte { get; set; }

    public string? LsNoSerie { get; set; }

    public string? CtIntitule { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public short? DlTtc { get; set; }

    public decimal? DlMontantHt { get; set; }

    public decimal? DlMontantTtc { get; set; }
}
