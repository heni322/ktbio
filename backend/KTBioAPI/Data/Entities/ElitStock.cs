using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class ElitStock
{
    public string Famille { get; set; } = null!;

    public decimal? QuantitéEnStock { get; set; }

    public decimal? QuantitéRéservée { get; set; }

    public string DeIntitule { get; set; } = null!;

    public string RéférenceDeLArticle { get; set; } = null!;

    public short? AsMouvemente { get; set; }
}
