using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpArticle
{
    public string ArtNum { get; set; } = null!;

    public int ArtPk { get; set; }

    public byte[]? ArtUk { get; set; }

    public string? ArtLib { get; set; }

    public string ArtFacodefamille { get; set; } = null!;

    public string? ArtGamme1 { get; set; }

    public string? ArtGamme2 { get; set; }

    public string ArtCondition { get; set; } = null!;

    public string? ArtUniteven { get; set; }

    public string? ArtFourprinc { get; set; }

    public string? ArtLibstat01 { get; set; }

    public string? ArtLibstat02 { get; set; }

    public string? ArtLibstat03 { get; set; }

    public string? ArtLibstat04 { get; set; }

    public string? ArtLibstat05 { get; set; }

    public string? ArtStat01 { get; set; }

    public string? ArtStat02 { get; set; }

    public string? ArtStat03 { get; set; }

    public string? ArtStat04 { get; set; }

    public string? ArtStat05 { get; set; }

    public decimal? ArtPrixach { get; set; }

    public decimal? ArtCoef { get; set; }

    public decimal? ArtPrix { get; set; }

    public string ArtTypeprix { get; set; } = null!;

    public string ArtUnitepoids { get; set; } = null!;

    public string? ArtSuivistock { get; set; }

    public decimal? ArtPoidsnet { get; set; }

    public decimal? ArtPoidsbrut { get; set; }

    public string? ArtDelai { get; set; }

    public string? ArtGarantie { get; set; }

    public string ArtContremarque { get; set; } = null!;

    public string ArtVtedebit { get; set; } = null!;

    public string ArtFactpoids { get; set; } = null!;

    public string ArtFactforfait { get; set; } = null!;

    public string ArtEscompte { get; set; } = null!;

    public string ArtNotimp { get; set; } = null!;

    public string ArtHorsstat { get; set; } = null!;

    public string ArtSommeil { get; set; } = null!;

    public string ArtPublie { get; set; } = null!;

    public string? ArtLangue1 { get; set; }

    public string? ArtLangue2 { get; set; }

    public string? ArtCodeedied { get; set; }

    public string? ArtCodebarre { get; set; }

    public string? ArtCodefiscal { get; set; }

    public string? ArtPays { get; set; }

    public decimal? ArtDerprixach { get; set; }

    public string? ArtCatLib01 { get; set; }

    public string? ArtCatLib02 { get; set; }

    public string? ArtCatLib03 { get; set; }

    public string? ArtCatLib04 { get; set; }

    public string? ArtType { get; set; }
}
