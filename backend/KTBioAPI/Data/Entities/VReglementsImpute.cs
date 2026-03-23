using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class VReglementsImpute
{
    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? RgPiece { get; set; }

    public DateTime? RgDate { get; set; }

    public string? RgReference { get; set; }

    public string? RgLibelle { get; set; }

    public decimal? RgMontant { get; set; }

    public string? RIntitule { get; set; }

    public short? RgImpute { get; set; }

    public short? RgCompta { get; set; }

    public DateTime? RgDateEchCont { get; set; }

    public string? DoPiece { get; set; }

    public short? DoType { get; set; }

    public decimal? RcMontant { get; set; }
}
