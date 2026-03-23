using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarifremise
{
    public int TfNo { get; set; }

    public decimal? TrBorneSup { get; set; }

    public decimal? TrRemise01RemValeur { get; set; }

    public short? TrRemise01RemType { get; set; }

    public decimal? TrRemise02RemValeur { get; set; }

    public short? TrRemise02RemType { get; set; }

    public decimal? TrRemise03RemValeur { get; set; }

    public short? TrRemise03RemType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FTarif TfNoNavigation { get; set; } = null!;
}
