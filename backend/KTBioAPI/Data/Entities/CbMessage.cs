using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbMessage
{
    public short? CbSession { get; set; }

    public short? CbUser { get; set; }

    public string? CbMessage1 { get; set; }

    public int CbModif { get; set; }
}
