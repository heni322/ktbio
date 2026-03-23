using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCaissecaissier
{
    public int CaNo { get; set; }

    public int CoNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCaisse CaNoNavigation { get; set; } = null!;

    public virtual FCollaborateur CoNoNavigation { get; set; } = null!;
}
