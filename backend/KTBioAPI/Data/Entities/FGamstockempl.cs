using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FGamstockempl
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public int DeNo { get; set; }

    public int DpNo { get; set; }

    public decimal? GeQteSto { get; set; }

    public decimal? GeQtePrepa { get; set; }

    public decimal? GeQteAcontroler { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepotempl FDepotempl { get; set; } = null!;
}
