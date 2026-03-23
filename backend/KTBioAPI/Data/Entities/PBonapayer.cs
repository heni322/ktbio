using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PBonapayer
{
    public short? BAutorisation { get; set; }

    public int? CoNo { get; set; }

    public short? BFacture { get; set; }

    public decimal? BSeuil { get; set; }

    public int CbMarq { get; set; }
}
