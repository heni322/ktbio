using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FTicketarchive
{
    public int CaNo { get; set; }

    public int? CoNoCaissier { get; set; }

    public int? CbCoNoCaissier { get; set; }

    public string TaPiece { get; set; } = null!;

    public DateTime? TaDate { get; set; }

    public string? TaHeure { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? DoPiece { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbTaPiece { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public virtual FCaisse CaNoNavigation { get; set; } = null!;

    public virtual FCollaborateur? CbCoNoCaissierNavigation { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual ICollection<FLignearchive> FLignearchives { get; set; } = new List<FLignearchive>();

    public virtual ICollection<FReglearchive> FReglearchives { get; set; } = new List<FReglearchive>();
}
