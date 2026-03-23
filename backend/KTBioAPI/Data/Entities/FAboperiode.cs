using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboperiode
{
    public int AbNo { get; set; }

    public DateTime? PeDebut { get; set; }

    public DateTime? PeFin { get; set; }

    public DateTime? PeGeneration { get; set; }

    public DateTime? PeLivraison { get; set; }

    public short? PeEtat { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FAbonnement AbNoNavigation { get; set; } = null!;
}
