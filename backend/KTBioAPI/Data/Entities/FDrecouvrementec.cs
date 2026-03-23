using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDrecouvrementec
{
    public string DrNum { get; set; } = null!;

    public byte[]? CbDrNum { get; set; }

    public int EcNo { get; set; }

    public DateTime? EcDateTiersDouteux { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FDrecouvrement DrNumNavigation { get; set; } = null!;

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;
}
