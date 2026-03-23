using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcrituref
{
    public int? EfNo { get; set; }

    public DateTime? EfDate { get; set; }

    public string? EfPiece { get; set; }

    public byte[]? CbEfPiece { get; set; }

    public string CgNum { get; set; } = null!;

    public byte[]? CbCgNum { get; set; }

    public string? EfIntitule { get; set; }

    public short? EfSens { get; set; }

    public decimal? EfMontant { get; set; }

    public short? EfType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg CgNumNavigation { get; set; } = null!;
}
