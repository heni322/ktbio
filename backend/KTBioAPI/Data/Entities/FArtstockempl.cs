using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtstockempl
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int DeNo { get; set; }

    public int DpNo { get; set; }

    public decimal? AeQteSto { get; set; }

    public decimal? AeQtePrepa { get; set; }

    public decimal? AeQteAcontroler { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepotempl FDepotempl { get; set; } = null!;
}
