using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PSoucheinterne
{
    public string? SIntitule { get; set; }

    public short? SValide { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
