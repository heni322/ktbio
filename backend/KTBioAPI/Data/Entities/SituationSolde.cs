using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class SituationSolde
{
    public string? Cpte { get; set; }

    public int SoldeTot { get; set; }

    public int Solde2ans { get; set; }

    public int Solde8mois { get; set; }

    public string? CtIntitule { get; set; }
}
