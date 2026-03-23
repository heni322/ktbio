using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptetmedium
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? MeCommentaire { get; set; }

    public string? MeFichier { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? MeTypeMime { get; set; }

    public string? MeOrigine { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
