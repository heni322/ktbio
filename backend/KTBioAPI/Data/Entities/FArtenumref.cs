using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtenumref
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public string? AeRef { get; set; }

    public byte[]? CbAeRef { get; set; }

    public decimal? AePrixAch { get; set; }

    public string? AeCodeBarre { get; set; }

    public byte[]? CbAeCodeBarre { get; set; }

    public decimal? AePrixAchNouv { get; set; }

    public string? AeEdiCode { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbAeEdiCode { get; set; }

    public short? AeSommeil { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
