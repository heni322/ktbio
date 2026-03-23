using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PCrisque
{
    public string? RIntitule { get; set; }

    public short? RType { get; set; }

    public decimal? RMin { get; set; }

    public decimal? RMax { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
