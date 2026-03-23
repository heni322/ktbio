using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PResultat
{
    public short? RGenere { get; set; }

    public string? CgNumResultat { get; set; }

    public string? CgNumImposition { get; set; }

    public string? CgNumContrepartie { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
