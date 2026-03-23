using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLienrectif
{
    public short? DoDomaine { get; set; }

    public string? LrRectifiee { get; set; }

    public string? LrRectificative { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbLrRectifiee { get; set; }

    public byte[]? CbLrRectificative { get; set; }
}
