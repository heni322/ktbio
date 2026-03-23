using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocligneempl
{
    public int DlNo { get; set; }

    public int DpNo { get; set; }

    public decimal? DlQte { get; set; }

    public decimal? DlQteAcontroler { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FDocligne DlNoNavigation { get; set; } = null!;

    public virtual FDepotempl DpNoNavigation { get; set; } = null!;
}
