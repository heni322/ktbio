using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtclient
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public short? AcCategorie { get; set; }

    public decimal? AcPrixVen { get; set; }

    public decimal? AcCoef { get; set; }

    public short? AcPrixTtc { get; set; }

    public short? AcArrondi { get; set; }

    public short? AcQteMont { get; set; }

    public short? EgChamp { get; set; }

    public decimal? AcPrixDev { get; set; }

    public short? AcDevise { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public decimal? AcRemise { get; set; }

    public short? AcCalcul { get; set; }

    public short? AcTypeRem { get; set; }

    public string? AcRefClient { get; set; }

    public byte[]? CbAcRefClient { get; set; }

    public decimal? AcCoefNouv { get; set; }

    public decimal? AcPrixVenNouv { get; set; }

    public decimal? AcPrixDevNouv { get; set; }

    public decimal? AcRemiseNouv { get; set; }

    public DateTime? AcDateApplication { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FComptet? CtNumNavigation { get; set; }
}
