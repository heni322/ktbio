using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocenteteinfo
{
    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public string DiCode { get; set; } = null!;

    public byte[]? CbDiCode { get; set; }

    public string DiIntitule { get; set; } = null!;

    public byte[]? CbDiIntitule { get; set; }

    public short? DiType { get; set; }

    public string? DiValeur { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbDoPiece { get; set; }
}
