using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PEchangecial
{
    public decimal? ETauxRemise01 { get; set; }

    public decimal? ETauxRemise02 { get; set; }

    public decimal? ETauxRemise03 { get; set; }

    public decimal? ETauxRemise04 { get; set; }

    public decimal? ETauxRemise05 { get; set; }

    public string? ArRef01 { get; set; }

    public string? ArRef02 { get; set; }

    public string? ArRef03 { get; set; }

    public string? ArRef04 { get; set; }

    public string? ArRef05 { get; set; }

    public short? ESousTrait { get; set; }

    public int CbMarq { get; set; }

    public short? ESousTraitCommande { get; set; }
}
