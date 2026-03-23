using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAfficheur
{
    public short? AfAction { get; set; }

    public short? AfCadrage { get; set; }

    public string? AfTexte { get; set; }

    public short? AfNumOrdre { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
