using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEmodeleg
{
    public int MgNo { get; set; }

    public short? NAnalytique { get; set; }

    public string? CxNum { get; set; }

    public byte[]? CbCxNum { get; set; }

    public short? EgTrepart { get; set; }

    public decimal? EgVrepart { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FModeleg MgNoNavigation { get; set; } = null!;
}
