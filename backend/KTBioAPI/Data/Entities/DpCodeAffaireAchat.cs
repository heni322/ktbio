using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpCodeAffaireAchat
{
    public string CaaCode { get; set; } = null!;

    public string? CaaInitule { get; set; }

    public string? CaaNiveauAnalyse { get; set; }

    public string? CaaPlanAnalytique { get; set; }

    public string CaaCodeAffaire { get; set; } = null!;
}
