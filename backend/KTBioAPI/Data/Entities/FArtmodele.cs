using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtmodele
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int MoNo { get; set; }

    public short? AmDomaine { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FModele MoNoNavigation { get; set; } = null!;
}
