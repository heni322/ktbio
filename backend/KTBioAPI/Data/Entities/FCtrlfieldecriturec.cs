using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCtrlfieldecriturec
{
    public short? JoType { get; set; }

    public short? CfeChamp { get; set; }

    public short? CfeControle { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
