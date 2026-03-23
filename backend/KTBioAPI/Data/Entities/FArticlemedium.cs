using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArticlemedium
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? MeCommentaire { get; set; }

    public string? MeFichier { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? MeTypeMime { get; set; }

    public string? MeOrigine { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
