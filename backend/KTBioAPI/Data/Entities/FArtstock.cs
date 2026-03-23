using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtstock
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int DeNo { get; set; }

    public decimal? AsQteMini { get; set; }

    public decimal? AsQteMaxi { get; set; }

    public decimal? AsMontSto { get; set; }

    public decimal? AsQteSto { get; set; }

    public decimal? AsQteRes { get; set; }

    public decimal? AsQteCom { get; set; }

    public short? AsPrincipal { get; set; }

    public decimal? AsQteResCm { get; set; }

    public decimal? AsQteComCm { get; set; }

    public decimal? AsQtePrepa { get; set; }

    public int? DpNoPrincipal { get; set; }

    public int? CbDpNoPrincipal { get; set; }

    public int? DpNoControle { get; set; }

    public int? CbDpNoControle { get; set; }

    public decimal? AsQteAcontroler { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? AsMouvemente { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepotempl? CbDpNoControleNavigation { get; set; }

    public virtual FDepotempl? CbDpNoPrincipalNavigation { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
