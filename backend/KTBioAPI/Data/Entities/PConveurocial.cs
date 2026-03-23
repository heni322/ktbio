using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PConveurocial
{
    public short? CBasculeTarif { get; set; }

    public short? CBasculeLibre { get; set; }

    public short? CBasculeCompte { get; set; }

    public int CbMarq { get; set; }
}
