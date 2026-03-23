using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class UpdateEcr122013
{
    public int? NEcriture { get; set; }

    public string? NPièce { get; set; }

    public string? NFacture { get; set; }

    public string? Libellé { get; set; }

    public int EcN { get; set; }

    public string? EcP { get; set; }

    public string? EcR { get; set; }

    public string Compte { get; set; } = null!;

    public string? Tiers { get; set; }

    public string? Intitulé { get; set; }

    public string? CtIntitule { get; set; }

    public string JoNum { get; set; } = null!;

    public DateTime JmDate { get; set; }
}
