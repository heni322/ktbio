using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FReglearchive
{
    public string TaPiece { get; set; } = null!;

    public decimal? RaMontant { get; set; }

    public short? NDevise { get; set; }

    public decimal? RaMontantDev { get; set; }

    public short? NReglement { get; set; }

    public DateTime? RaDate { get; set; }

    public int? CaNo { get; set; }

    public int? CbCaNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbTaPiece { get; set; }

    public virtual FCaisse? CbCaNoNavigation { get; set; }

    public virtual FTicketarchive TaPieceNavigation { get; set; } = null!;
}
