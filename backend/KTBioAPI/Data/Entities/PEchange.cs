using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PEchange
{
    public short? EEdiCodeType { get; set; }

    public string? EEdiCode { get; set; }

    public string? EEdiCodeSage { get; set; }

    public int? CdNo { get; set; }

    public string? JoNum { get; set; }

    public int? PiNo { get; set; }

    public int CbMarq { get; set; }
}
