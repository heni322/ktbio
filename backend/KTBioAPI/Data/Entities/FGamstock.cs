using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FGamstock
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public int DeNo { get; set; }

    public decimal? GsMontSto { get; set; }

    public decimal? GsQteSto { get; set; }

    public decimal? GsQteRes { get; set; }

    public decimal? GsQteCom { get; set; }

    public decimal? GsQteResCm { get; set; }

    public decimal? GsQteComCm { get; set; }

    public decimal? GsQteMini { get; set; }

    public decimal? GsQteMaxi { get; set; }

    public decimal? GsQtePrepa { get; set; }

    public int? DpNoPrincipal { get; set; }

    public int? CbDpNoPrincipal { get; set; }

    public int? DpNoControle { get; set; }

    public int? CbDpNoControle { get; set; }

    public decimal? GsQteAcontroler { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepotempl? CbDpNoControleNavigation { get; set; }

    public virtual FDepotempl? CbDpNoPrincipalNavigation { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
