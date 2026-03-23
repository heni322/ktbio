using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocentetemedium
{
    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public string? DmIntitule { get; set; }

    public string? DmFichier { get; set; }

    public short? DmTransmettre { get; set; }

    public string? DmTypeMime { get; set; }

    public string? DmOrigine { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
