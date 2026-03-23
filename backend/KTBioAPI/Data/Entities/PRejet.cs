using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PRejet
{
    public string? RIntitule { get; set; }

    public string? RCode { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
