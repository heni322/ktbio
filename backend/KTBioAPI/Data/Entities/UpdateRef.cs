using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class UpdateRef
{
    public string? NPièce { get; set; }

    public string? NFacture { get; set; }

    public string? NouveauNFacture { get; set; }

    public string JoNum { get; set; } = null!;

    public int EcNo { get; set; }

    public string? EcPiece { get; set; }

    public string? EcRefPiece { get; set; }
}
