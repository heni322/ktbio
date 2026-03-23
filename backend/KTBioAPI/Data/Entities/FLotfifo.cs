using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLotfifo
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public decimal? LfQte { get; set; }

    public decimal? LfQteRestant { get; set; }

    public short? LfLotEpuise { get; set; }

    public int DeNo { get; set; }

    public int? DlNoIn { get; set; }

    public int? DlNoOut { get; set; }

    public short? LfMvtStock { get; set; }

    public DateTime? LfDateBl { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
