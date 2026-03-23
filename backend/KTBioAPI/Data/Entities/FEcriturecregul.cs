using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturecregul
{
    public int EcNo { get; set; }

    public DateTime? ErDateRegul { get; set; }

    public int EcNoRegul { get; set; }

    public short? ErStatusRegul { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;

    public virtual FEcriturec EcNoRegulNavigation { get; set; } = null!;
}
