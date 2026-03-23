using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCatalogue
{
    public int? ClNo { get; set; }

    public string ClIntitule { get; set; } = null!;

    public byte[]? CbClIntitule { get; set; }

    public string? ClCode { get; set; }

    public short? ClStock { get; set; }

    public int? ClNoParent { get; set; }

    public int? CbClNoParent { get; set; }

    public short? ClNiveau { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCatalogue? CbClNoParentNavigation { get; set; }

    public virtual ICollection<FArticle> FArticleCbClNo1Navigations { get; set; } = new List<FArticle>();

    public virtual ICollection<FArticle> FArticleCbClNo2Navigations { get; set; } = new List<FArticle>();

    public virtual ICollection<FArticle> FArticleCbClNo3Navigations { get; set; } = new List<FArticle>();

    public virtual ICollection<FArticle> FArticleCbClNo4Navigations { get; set; } = new List<FArticle>();

    public virtual ICollection<FFamille> FFamilleCbClNo1Navigations { get; set; } = new List<FFamille>();

    public virtual ICollection<FFamille> FFamilleCbClNo2Navigations { get; set; } = new List<FFamille>();

    public virtual ICollection<FFamille> FFamilleCbClNo3Navigations { get; set; } = new List<FFamille>();

    public virtual ICollection<FFamille> FFamilleCbClNo4Navigations { get; set; } = new List<FFamille>();

    public virtual ICollection<FCatalogue> InverseCbClNoParentNavigation { get; set; } = new List<FCatalogue>();
}
