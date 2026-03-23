using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FProjetligne
{
    public string PfNum { get; set; } = null!;

    public byte[]? CbPfNum { get; set; }

    public int? DlNo { get; set; }

    public short? PlOrdre { get; set; }

    public short? PfType { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FDocligne? DlNoNavigation { get; set; }

    public virtual FProjetfabrication PfNumNavigation { get; set; } = null!;
}
