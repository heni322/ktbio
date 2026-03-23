using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarifgam
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? TgRefCf { get; set; }

    public byte[]? CbTgRefCf { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public decimal? TgPrix { get; set; }

    public string? TgRef { get; set; }

    public byte[]? CbTgRef { get; set; }

    public string? TgCodeBarre { get; set; }

    public byte[]? CbTgCodeBarre { get; set; }

    public decimal? TgPrixNouv { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
