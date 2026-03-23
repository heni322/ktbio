using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class Test2
{
    public decimal? MontantFacture { get; set; }

    public decimal? MontantRegle { get; set; }

    public decimal? Solde { get; set; }

    public string? CtIntitule { get; set; }

    public DateTime? DoDate { get; set; }

    public string? CtNum { get; set; }
}
