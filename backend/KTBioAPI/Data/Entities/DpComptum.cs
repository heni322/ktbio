using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpComptum
{
    public short CaNanalytique { get; set; }

    public string CaCanum { get; set; } = null!;

    public short? CaNanalyse { get; set; }

    public string? CaCaintitule { get; set; }

    public string CaCatype { get; set; } = null!;

    public string? CaCaclassement { get; set; }

    public string CaCasommeil { get; set; } = null!;

    public string CaCareport { get; set; } = null!;
}
