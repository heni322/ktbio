using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtprix
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public decimal? ArPunet { get; set; }

    public decimal? ArCoutStd { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
