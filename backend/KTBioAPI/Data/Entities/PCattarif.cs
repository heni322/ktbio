using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PCattarif
{
    public string? CtIntitule { get; set; }

    public short? CtPrixTtc { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
