using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PDossiercial
{
    public string? DRaisonS { get; set; }

    public string? DFormatQte { get; set; }

    public string? DFormatPrix { get; set; }

    public short? NDeviseCompte { get; set; }

    public short? NDeviseEquival { get; set; }

    public DateTime? DArchivePeriod { get; set; }

    public short? DValiditePeriod { get; set; }

    public int CbMarq { get; set; }

    public DateTime? DDerniereCloture { get; set; }

    public string? DImprimeFacture { get; set; }

    public string? DImprimeCgv { get; set; }
}
