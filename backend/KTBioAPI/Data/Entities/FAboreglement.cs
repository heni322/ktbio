using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboreglement
{
    public int AbNo { get; set; }

    public short? NReglement { get; set; }

    public short? RaCondition { get; set; }

    public short? RaNbJour { get; set; }

    public short? RaJourTb01 { get; set; }

    public short? RaJourTb02 { get; set; }

    public short? RaJourTb03 { get; set; }

    public short? RaJourTb04 { get; set; }

    public short? RaJourTb05 { get; set; }

    public short? RaJourTb06 { get; set; }

    public short? RaTrepart { get; set; }

    public decimal? RaVrepart { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FAboentete AbNoNavigation { get; set; } = null!;
}
