using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCondition
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public int? CoNo { get; set; }

    public string? EcEnumere { get; set; }

    public byte[]? CbEcEnumere { get; set; }

    public decimal? EcQuantite { get; set; }

    public string? CoRef { get; set; }

    public byte[]? CbCoRef { get; set; }

    public string? CoCodeBarre { get; set; }

    public byte[]? CbCoCodeBarre { get; set; }

    public short? CoPrincipal { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CoEdiCode { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
