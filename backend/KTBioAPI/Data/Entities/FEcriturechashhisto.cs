using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturechashhisto
{
    public byte[]? HhHash { get; set; }

    public int? HhHashOrder { get; set; }

    public byte[]? HhHashCrc { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
