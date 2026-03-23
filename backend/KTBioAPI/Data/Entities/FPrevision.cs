using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FPrevision
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1Comp { get; set; }

    public int? AgNo2Comp { get; set; }

    public int DeNo { get; set; }

    public decimal? PvQte { get; set; }

    public DateTime? PvDate { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
