using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFourchetteresultat
{
    public short? NResultat { get; set; }

    public string? CgNumDe { get; set; }

    public byte[]? CbCgNumDe { get; set; }

    public string? CgNumA { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
