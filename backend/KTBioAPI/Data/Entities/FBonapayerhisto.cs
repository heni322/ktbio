using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FBonapayerhisto
{
    public int EcNo { get; set; }

    public short? BpType { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public DateTime? BpDate { get; set; }

    public string? BpCommentaire { get; set; }

    public short? BpApplication { get; set; }

    public short? BpRetour { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;
}
