using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FClavier
{
    public short? NClavier { get; set; }

    public short? ClFonction { get; set; }

    public short? ClInteresse { get; set; }

    public string? ArRef { get; set; }

    public byte[]? CbArRef { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public short? ClRaccourci { get; set; }

    public short? ClFlag { get; set; }

    public short? ClAffiche { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FArticle? ArRefNavigation { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }
}
