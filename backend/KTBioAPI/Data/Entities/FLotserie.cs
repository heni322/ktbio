using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLotserie
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? LsNoSerie { get; set; }

    public byte[]? CbLsNoSerie { get; set; }

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public decimal? LsQte { get; set; }

    public decimal? LsQteRestant { get; set; }

    public decimal? LsQteRes { get; set; }

    public short? LsLotEpuise { get; set; }

    public int DeNo { get; set; }

    public int? DlNoIn { get; set; }

    public int? DlNoOut { get; set; }

    public short? LsMvtStock { get; set; }

    public string? LsComplement { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? NPièce { get; set; }

    public string? Amc { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
