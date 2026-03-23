using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarifqte
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string? TqRefCf { get; set; }

    public byte[]? CbTqRefCf { get; set; }

    public decimal? TqBorneSup { get; set; }

    public decimal? TqRemise01RemValeur { get; set; }

    public short? TqRemise01RemType { get; set; }

    public decimal? TqRemise02RemValeur { get; set; }

    public short? TqRemise02RemType { get; set; }

    public decimal? TqRemise03RemValeur { get; set; }

    public short? TqRemise03RemType { get; set; }

    public decimal? TqPrixNet { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
