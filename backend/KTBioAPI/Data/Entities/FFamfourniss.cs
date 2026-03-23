using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFamfourniss
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public short? FfUnite { get; set; }

    public decimal? FfConversion { get; set; }

    public short? FfDelaiAppro { get; set; }

    public short? FfGarantie { get; set; }

    public decimal? FfColisage { get; set; }

    public decimal? FfQteMini { get; set; }

    public short? FfQteMont { get; set; }

    public short? EgChamp { get; set; }

    public short? FfPrincipal { get; set; }

    public short? FfDevise { get; set; }

    public decimal? FfRemise { get; set; }

    public decimal? FfConvDiv { get; set; }

    public short? FfTypeRem { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
