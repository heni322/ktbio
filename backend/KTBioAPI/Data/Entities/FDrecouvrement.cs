using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDrecouvrement
{
    public string DrNum { get; set; } = null!;

    public byte[]? CbDrNum { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public decimal? DrPerteProbable { get; set; }

    public short? DrStatut { get; set; }

    public short? DrPriorite { get; set; }

    public DateTime? DrDateDebut { get; set; }

    public short? NLitige { get; set; }

    public string? DrResume { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public int? CtNo { get; set; }

    public int? CbCtNo { get; set; }

    public string? DrCommentaire { get; set; }

    public DateTime? DrDateFin { get; set; }

    public short? NResolution { get; set; }

    public short? DrResultat { get; set; }

    public decimal? DrProvision { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FContactt? CbCtNoNavigation { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual ICollection<FContactr> FContactrs { get; set; } = new List<FContactr>();

    public virtual ICollection<FDrecouvrementec> FDrecouvrementecs { get; set; } = new List<FDrecouvrementec>();

    public virtual ICollection<FDrecouvrementiv> FDrecouvrementivs { get; set; } = new List<FDrecouvrementiv>();
}
