using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEfinanciera
{
    public int EfNo { get; set; }

    public short NAnalytique { get; set; }

    public short? FaLigne { get; set; }

    public string CaNum { get; set; } = null!;

    public decimal? FaMontant { get; set; }

    public decimal? FaQuantite { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEfinancier EfNoNavigation { get; set; } = null!;

    public virtual FComptea FComptea { get; set; } = null!;
}
