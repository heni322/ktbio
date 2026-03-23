using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEprotectioncptum
{
    public int ProtNo { get; set; }

    public int? EprotCmd { get; set; }

    public short? EprotRight { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FProtectioncptum ProtNoNavigation { get; set; } = null!;
}
