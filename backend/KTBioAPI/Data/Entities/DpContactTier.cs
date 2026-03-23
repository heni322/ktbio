using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpContactTier
{
    public string CtCtnum { get; set; } = null!;

    public string? CtCtnom { get; set; }

    public string? CtCtprenom { get; set; }

    public short? CtNserviceCode { get; set; }

    public string? CtNservice { get; set; }

    public string? CtCtfonction { get; set; }

    public string? CtCttelephone { get; set; }

    public string? CtCttelportable { get; set; }

    public string? CtCttelecopie { get; set; }

    public string? CtCtemail { get; set; }
}
