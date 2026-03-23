using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FNomenclat
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string NoRefDet { get; set; } = null!;

    public byte[]? CbNoRefDet { get; set; }

    public decimal? NoQte { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public short? NoType { get; set; }

    public decimal? NoRepartition { get; set; }

    public string? NoOperation { get; set; }

    public byte[]? CbNoOperation { get; set; }

    public string? NoCommentaire { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public short? NoOrdre { get; set; }

    public int? AgNo1Comp { get; set; }

    public int? AgNo2Comp { get; set; }

    public short? NoSousTraitance { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual FArticle NoRefDetNavigation { get; set; } = null!;
}
