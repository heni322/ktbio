using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PSouchevente
{
    public string? SIntitule { get; set; }

    public short? SValide { get; set; }

    public string? JoNum { get; set; }

    public string? JoNumSituation { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
