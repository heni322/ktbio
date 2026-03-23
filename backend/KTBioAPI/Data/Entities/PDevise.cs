using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PDevise
{
    public string? DIntitule { get; set; }

    public string? DFormat { get; set; }

    public decimal? DCours { get; set; }

    public decimal? DCoursP { get; set; }

    public string? DMonnaie { get; set; }

    public string? DSousMonnaie { get; set; }

    public string? DCodeIso { get; set; }

    public string? DSigle { get; set; }

    public short? DMode { get; set; }

    public short? NDeviseCot { get; set; }

    public decimal? DCoursClot { get; set; }

    public DateTime? DAncDate { get; set; }

    public decimal? DAncCours { get; set; }

    public short? DAncMode { get; set; }

    public short? NDeviseAncCot { get; set; }

    public short? DCodeRemise { get; set; }

    public short? DEuro { get; set; }

    public string? DCodeIsonum { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }

    public DateTime? DUpdateDate { get; set; }

    public string? DUpdateTime { get; set; }
}
