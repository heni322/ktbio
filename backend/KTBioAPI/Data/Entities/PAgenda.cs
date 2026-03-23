using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PAgenda
{
    public string? AIntitule { get; set; }

    public short? AFichier { get; set; }

    public short? AIndisponible { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
