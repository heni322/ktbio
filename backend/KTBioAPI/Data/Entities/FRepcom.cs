using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FRepcom
{
    public int CoNo { get; set; }

    public int TfNo { get; set; }

    public short? TfInteres { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCollaborateur CoNoNavigation { get; set; } = null!;

    public virtual FTarif TfNoNavigation { get; set; } = null!;
}
