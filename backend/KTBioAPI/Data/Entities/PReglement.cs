using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PReglement
{
    public string? RIntitule { get; set; }

    public string? RCode { get; set; }

    public short? RModePaieDebit { get; set; }

    public short? RModePaieCredit { get; set; }

    public string? IbAfbdecaissPrinc { get; set; }

    public string? IbAfbencaissPrinc { get; set; }

    public int? EbNoDecaiss { get; set; }

    public int? EbNoEncaiss { get; set; }

    public string? REdiCode { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
