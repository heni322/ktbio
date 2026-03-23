using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FRegrevision
{
    public int EcNo { get; set; }

    public DateTime? RrDebut { get; set; }

    public DateTime? RrFin { get; set; }

    public string? RrReviseur { get; set; }

    public string? RrCommentaire { get; set; }

    public string? RrControleur { get; set; }

    public DateTime? RrDateRev { get; set; }

    public DateTime? RrDateCont { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;
}
