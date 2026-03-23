using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEcriturecmedium
{
    public int EcNo { get; set; }

    public string? EmFichier { get; set; }

    public string? EmCommentaire { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? EmTypeMime { get; set; }

    public string? EmOrigine { get; set; }

    public virtual FEcriturec EcNoNavigation { get; set; } = null!;
}
