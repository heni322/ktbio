using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFamtarifqte
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public string? FqRefCf { get; set; }

    public byte[]? CbFqRefCf { get; set; }

    public decimal? FqBorneSup { get; set; }

    public decimal? FqRemise01RemValeur { get; set; }

    public short? FqRemise01RemType { get; set; }

    public decimal? FqRemise02RemValeur { get; set; }

    public short? FqRemise02RemType { get; set; }

    public decimal? FqRemise03RemValeur { get; set; }

    public short? FqRemise03RemType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
