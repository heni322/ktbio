using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtgloss
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int GlNo { get; set; }

    public short? AglNum { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FGlossaire GlNoNavigation { get; set; } = null!;
}
