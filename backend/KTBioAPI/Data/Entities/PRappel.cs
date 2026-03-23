using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PRappel
{
    public string? RIntitule { get; set; }

    public short? RDebut { get; set; }

    public short? RFin { get; set; }

    public short? RNbJours { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
