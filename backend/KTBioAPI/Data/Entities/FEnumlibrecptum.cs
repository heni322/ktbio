using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEnumlibrecptum
{
    public short? NInfo { get; set; }

    public short? NFile { get; set; }

    public string? ElIntitule { get; set; }

    public byte[]? CbElIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
