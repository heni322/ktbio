using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FModele
{
    public int? MoNo { get; set; }

    public string? MoIntitule { get; set; }

    public byte[]? CbMoIntitule { get; set; }

    public string? MoCalcul { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FArtmodele> FArtmodeles { get; set; } = new List<FArtmodele>();

    public virtual ICollection<FFammodele> FFammodeles { get; set; } = new List<FFammodele>();
}
