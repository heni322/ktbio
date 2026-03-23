using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbNotification
{
    public short CbSession { get; set; }

    public string? CbFile { get; set; }

    public short CbType { get; set; }

    public short CbUser { get; set; }

    public byte[]? CbIndMod { get; set; }

    public int? CbMarq { get; set; }

    public int CbModif { get; set; }

    public short? CbParam { get; set; }
}
