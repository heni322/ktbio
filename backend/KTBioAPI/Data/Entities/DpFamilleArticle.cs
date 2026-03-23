using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpFamilleArticle
{
    public string FaCodefamille { get; set; } = null!;

    public int FaArtPk { get; set; }

    public string? FaCatArtLib01 { get; set; }

    public string? FaCatArtLib02 { get; set; }

    public string? FaCatArtLib03 { get; set; }

    public string? FaCatArtLib04 { get; set; }

    public string? FaCodefamilleCentralisatrice { get; set; }

    public string? FaLibCentralisatrice { get; set; }
}
