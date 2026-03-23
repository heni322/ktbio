using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocentetegrille
{
    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public decimal? DgBorne { get; set; }

    public decimal? DgFrais { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
