using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAutorisationfinbq
{
    public int BqNo { get; set; }

    public int NfNo { get; set; }

    public decimal? AfAutorisation { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FBanque BqNoNavigation { get; set; } = null!;
}
