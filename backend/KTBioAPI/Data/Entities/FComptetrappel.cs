using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptetrappel
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public DateTime? CrDate { get; set; }

    public short? CrTrait { get; set; }

    public decimal? CrImpayes { get; set; }

    public decimal? CrPenal { get; set; }

    public DateTime? CrEcheance { get; set; }

    public short? NReglement { get; set; }

    public short? CrComptabilisation { get; set; }

    public decimal? CrSoldeRelance { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
