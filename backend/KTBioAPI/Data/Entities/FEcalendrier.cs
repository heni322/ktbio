using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcalendrier
{
    public int? CalNo { get; set; }

    public DateTime? EcalDate { get; set; }

    public string? EcalMotif { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCalendrier? CalNoNavigation { get; set; }
}
