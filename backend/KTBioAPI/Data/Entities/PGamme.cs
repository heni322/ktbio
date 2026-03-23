using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PGamme
{
    public string? GIntitule { get; set; }

    public short? GType { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
