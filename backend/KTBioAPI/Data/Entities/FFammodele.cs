using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFammodele
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public int MoNo { get; set; }

    public short? FmDomaine { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FModele MoNoNavigation { get; set; } = null!;
}
