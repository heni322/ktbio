using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarifcond
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? TcRefCf { get; set; }

    public byte[]? CbTcRefCf { get; set; }

    public int? CoNo { get; set; }

    public decimal? TcPrix { get; set; }

    public decimal? TcPrixNouv { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
