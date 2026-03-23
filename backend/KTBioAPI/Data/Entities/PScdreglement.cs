using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PScdreglement
{
    public short? ScdType { get; set; }

    public string? JoNumCli { get; set; }

    public string? JoNumFour { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
