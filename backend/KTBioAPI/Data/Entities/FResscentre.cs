using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FResscentre
{
    public string RpCodeRessource { get; set; } = null!;

    public byte[]? CbRpCodeRessource { get; set; }

    public string RpCodeCentre { get; set; } = null!;

    public byte[]? CbRpCodeCentre { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FRessourceprod RpCodeCentreNavigation { get; set; } = null!;

    public virtual FRessourceprod RpCodeRessourceNavigation { get; set; } = null!;
}
