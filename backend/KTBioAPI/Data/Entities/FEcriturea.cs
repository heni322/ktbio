using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturea
{
    public int EcNo { get; set; }

    public short NAnalytique { get; set; }

    public short? EaLigne { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public decimal? EaMontant { get; set; }

    public decimal? EaQuantite { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;

    public virtual FComptea FComptea { get; set; } = null!;
}
