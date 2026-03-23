using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEextraitec
{
    public int ExNo { get; set; }

    public short EeLigne { get; set; }

    public int EcNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;

    public virtual FEextrait FEextrait { get; set; } = null!;
}
