using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLivraison
{
    public int LiNo { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? LiIntitule { get; set; }

    public byte[]? CbLiIntitule { get; set; }

    public string? LiAdresse { get; set; }

    public string? LiComplement { get; set; }

    public string? LiCodePostal { get; set; }

    public string? LiVille { get; set; }

    public string? LiCodeRegion { get; set; }

    public string? LiPays { get; set; }

    public string? LiContact { get; set; }

    public short? NExpedition { get; set; }

    public short? NCondition { get; set; }

    public short? LiPrincipal { get; set; }

    public string? LiTelephone { get; set; }

    public string? LiTelecopie { get; set; }

    public string? LiEmail { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual ICollection<FAboentete> FAboentetes { get; set; } = new List<FAboentete>();

    public virtual ICollection<FDocentete> FDocentetes { get; set; } = new List<FDocentete>();
}
