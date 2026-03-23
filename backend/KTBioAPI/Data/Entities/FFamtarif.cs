using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFamtarif
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public short? FtCategorie { get; set; }

    public decimal? FtCoef { get; set; }

    public short? FtPrixTtc { get; set; }

    public short? FtArrondi { get; set; }

    public short? FtQteMont { get; set; }

    public short? EgChamp { get; set; }

    public short? FtDevise { get; set; }

    public decimal? FtRemise { get; set; }

    public short? FtCalcul { get; set; }

    public short? FtTypeRem { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
