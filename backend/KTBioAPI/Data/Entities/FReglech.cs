using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FReglech
{
    public int RgNo { get; set; }

    public int DrNo { get; set; }

    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public decimal? RcMontant { get; set; }

    public short? RgTypeReg { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public virtual FDocregl DrNoNavigation { get; set; } = null!;

    public virtual FCreglement RgNoNavigation { get; set; } = null!;
}
