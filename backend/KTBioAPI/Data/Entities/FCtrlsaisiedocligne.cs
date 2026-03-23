using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCtrlsaisiedocligne
{
    public short? DoDomaine { get; set; }

    public short? CfdlChamp { get; set; }

    public short? CfdlControle { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
