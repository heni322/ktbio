using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class Li
{
    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public string? DoTiers { get; set; }

    public int? LiNo { get; set; }

    public int Expr1 { get; set; }

    public string CtNum { get; set; } = null!;

    public string? LiIntitule { get; set; }
}
