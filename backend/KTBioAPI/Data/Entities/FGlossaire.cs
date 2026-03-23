using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FGlossaire
{
    public int? GlNo { get; set; }

    public short? GlDomaine { get; set; }

    public string? GlIntitule { get; set; }

    public byte[]? CbGlIntitule { get; set; }

    public string? GlRaccourci { get; set; }

    public byte[]? CbGlRaccourci { get; set; }

    public DateTime? GlPeriodeDeb { get; set; }

    public DateTime? GlPeriodeFin { get; set; }

    public string? GlText { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? GlTextLangue1 { get; set; }

    public string? GlTextLangue2 { get; set; }

    public virtual ICollection<FArtgloss> FArtglosses { get; set; } = new List<FArtgloss>();
}
