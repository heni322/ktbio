using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEfinancierec
{
    public int EfNo { get; set; }

    public int EcNo { get; set; }

    public decimal? FcMontantPartiel { get; set; }

    public decimal? FcMontantRegl { get; set; }

    public decimal? FcMontantChange { get; set; }

    public decimal? FcMontantEsc { get; set; }

    public decimal? FcMontantAutre { get; set; }

    public string? JoNumAutre { get; set; }

    public int? PiNoAutre { get; set; }

    public int? CbPiNoAutre { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FPiece? CbPiNoAutreNavigation { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;

    public virtual FEfinancier EfNoNavigation { get; set; } = null!;
}
