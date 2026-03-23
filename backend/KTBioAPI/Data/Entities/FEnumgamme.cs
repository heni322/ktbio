using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEnumgamme
{
    public short? EgChamp { get; set; }

    public short? EgLigne { get; set; }

    public string? EgEnumere { get; set; }

    public byte[]? CbEgEnumere { get; set; }

    public decimal? EgBorneSup { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
