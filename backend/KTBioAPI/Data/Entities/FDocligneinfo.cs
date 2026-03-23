using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocligneinfo
{
    public int DlNo { get; set; }

    public string DcCode { get; set; } = null!;

    public byte[]? CbDcCode { get; set; }

    public string DcIntitule { get; set; } = null!;

    public byte[]? CbDcIntitule { get; set; }

    public short? DcType { get; set; }

    public string? DcValeur { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FDocligne DlNoNavigation { get; set; } = null!;
}
