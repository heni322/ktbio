using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTarif
{
    public int? TfNo { get; set; }

    public string? TfIntitule { get; set; }

    public byte[]? CbTfIntitule { get; set; }

    public short? TfInteres { get; set; }

    public DateTime? TfDebut { get; set; }

    public DateTime? TfFin { get; set; }

    public short? TfObjectif { get; set; }

    public short? TfDomaine { get; set; }

    public short? TfBase { get; set; }

    public short? TfCalcul { get; set; }

    public string? ArRef { get; set; }

    public byte[]? CbArRef { get; set; }

    public decimal? TfRemise01RemValeur { get; set; }

    public short? TfRemise01RemType { get; set; }

    public decimal? TfRemise02RemValeur { get; set; }

    public short? TfRemise02RemType { get; set; }

    public decimal? TfRemise03RemValeur { get; set; }

    public short? TfRemise03RemType { get; set; }

    public short? TfType { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle? ArRefNavigation { get; set; }

    public virtual FComptet? CtNumNavigation { get; set; }

    public virtual ICollection<FRepcom> FRepcoms { get; set; } = new List<FRepcom>();

    public virtual ICollection<FTarifremise> FTarifremises { get; set; } = new List<FTarifremise>();

    public virtual ICollection<FTarifselect> FTarifselects { get; set; } = new List<FTarifselect>();
}
