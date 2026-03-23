using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtfourniss
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? AfRefFourniss { get; set; }

    public byte[]? CbAfRefFourniss { get; set; }

    public decimal? AfPrixAch { get; set; }

    public short? AfUnite { get; set; }

    public decimal? AfConversion { get; set; }

    public short? AfDelaiAppro { get; set; }

    public short? AfGarantie { get; set; }

    public decimal? AfColisage { get; set; }

    public decimal? AfQteMini { get; set; }

    public short? AfQteMont { get; set; }

    public short? EgChamp { get; set; }

    public short? AfPrincipal { get; set; }

    public decimal? AfPrixDev { get; set; }

    public short? AfDevise { get; set; }

    public decimal? AfRemise { get; set; }

    public decimal? AfConvDiv { get; set; }

    public short? AfTypeRem { get; set; }

    public string? AfCodeBarre { get; set; }

    public byte[]? CbAfCodeBarre { get; set; }

    public decimal? AfPrixAchNouv { get; set; }

    public decimal? AfPrixDevNouv { get; set; }

    public decimal? AfRemiseNouv { get; set; }

    public DateTime? AfDateApplication { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
