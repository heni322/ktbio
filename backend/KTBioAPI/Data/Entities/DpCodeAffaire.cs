using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpCodeAffaire
{
    public string CaCode { get; set; } = null!;

    public string? CaInitule { get; set; }

    public string? CaNiveauAnalyse { get; set; }

    public string? CaPlanAnalytique { get; set; }

    public string CaCodeAffaire { get; set; } = null!;
}
