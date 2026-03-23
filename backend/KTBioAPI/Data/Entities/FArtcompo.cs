using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtcompo
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? AtOperation { get; set; }

    public byte[]? CbAtOperation { get; set; }

    public string? RpCode { get; set; }

    public byte[]? CbRpCode { get; set; }

    public string? AtTemps { get; set; }

    public short? AtType { get; set; }

    public string? AtDescription { get; set; }

    public short? AtOrdre { get; set; }

    public int? AgNo1Comp { get; set; }

    public int? AgNo2Comp { get; set; }

    public short? AtTypeRessource { get; set; }

    public short? AtChevauche { get; set; }

    public short? AtDemarre { get; set; }

    public string? AtOperationChevauche { get; set; }

    public byte[]? CbAtOperationChevauche { get; set; }

    public decimal? AtValeurChevauche { get; set; }

    public short? AtTypeChevauche { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FRessourceprod? RpCodeNavigation { get; set; }
}
