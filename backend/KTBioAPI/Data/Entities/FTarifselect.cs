using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarifselect
{
    public int TfNo { get; set; }

    public short? TsInteres { get; set; }

    public string? TsRef { get; set; }

    public byte[]? CbTsRef { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FTarif TfNoNavigation { get; set; } = null!;
}
