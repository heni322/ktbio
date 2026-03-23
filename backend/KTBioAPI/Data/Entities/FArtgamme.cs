using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtgamme
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? AgNo { get; set; }

    public string? EgEnumere { get; set; }

    public byte[]? CbEgEnumere { get; set; }

    public short? AgType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
