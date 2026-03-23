using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class ListeDesBl2015
{
    public string? CtNum { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public string? CtIntitule { get; set; }

    public string FaCodeFamille { get; set; } = null!;
}
