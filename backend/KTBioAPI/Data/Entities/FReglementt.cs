using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FReglementt
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public short? NReglement { get; set; }

    public short? RtCondition { get; set; }

    public short? RtNbJour { get; set; }

    public short? RtJourTb01 { get; set; }

    public short? RtJourTb02 { get; set; }

    public short? RtJourTb03 { get; set; }

    public short? RtJourTb04 { get; set; }

    public short? RtJourTb05 { get; set; }

    public short? RtJourTb06 { get; set; }

    public short? RtTrepart { get; set; }

    public decimal? RtVrepart { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
