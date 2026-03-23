using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCaissetotal
{
    public int CaNo { get; set; }

    public int? CatNo { get; set; }

    public DateTime? CatDateCloture { get; set; }

    public string? CatHeureCloture { get; set; }

    public decimal? CatTotal { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbHash { get; set; }

    public short? CbHashVersion { get; set; }

    public DateTime? CbHashDate { get; set; }

    public int? CbHashOrder { get; set; }

    public virtual FCaisse CaNoNavigation { get; set; } = null!;
}
