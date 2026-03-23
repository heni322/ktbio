using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAgendadet
{
    public short? AdChamp { get; set; }

    public string AdEvenem { get; set; } = null!;

    public byte[]? CbAdEvenem { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
