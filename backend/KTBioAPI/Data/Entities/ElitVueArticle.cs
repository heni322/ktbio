using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class ElitVueArticle
{
    public string CodeFamille { get; set; } = null!;

    public string Référence { get; set; } = null!;

    public string? Désignation { get; set; }

    public string? Amc { get; set; }

    public string? NSérie { get; set; }

    public DateTime? DateFabrication { get; set; }

    public DateTime? DatePéremption { get; set; }

    public string Dépôt { get; set; } = null!;

    public decimal? QtéStock { get; set; }
}
