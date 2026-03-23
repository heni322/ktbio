using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDepotuser
{
    public int? DeNo { get; set; }

    public int? ProtNo { get; set; }

    public int? CbProtNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FProtectioncial? CbProtNoNavigation { get; set; }
}
