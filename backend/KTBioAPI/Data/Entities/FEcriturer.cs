using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturer
{
    public DateTime? ErDate { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public short? ErSens { get; set; }

    public decimal? ErMontantA { get; set; }

    public decimal? ErQuantiteA { get; set; }

    public short? ErType { get; set; }

    public string JaNum { get; set; } = null!;

    public byte[]? CbJaNum { get; set; }

    public string? ErPiece { get; set; }

    public byte[]? CbErPiece { get; set; }

    public string? ErRefPiece { get; set; }

    public string? ErIntitule { get; set; }

    public int? ErNo { get; set; }

    public short? ErNorme { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;

    public virtual FComptea FComptea { get; set; } = null!;
}
