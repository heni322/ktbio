using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpArtcategcptum
{
    public byte[]? ArtcbarRef { get; set; }

    public string ArtarRef { get; set; } = null!;

    public string Fartcodfam { get; set; } = null!;

    public string? Label { get; set; }

    public int Type { get; set; }

    public int Champ { get; set; }

    public string? Compteg { get; set; }

    public string? Comptea { get; set; }

    public string? Tax1 { get; set; }

    public string? Tax2 { get; set; }

    public string? Tax3 { get; set; }
}
