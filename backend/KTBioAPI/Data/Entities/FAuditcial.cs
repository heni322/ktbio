using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAuditcial
{
    public int? AdtNo { get; set; }

    public DateTime? AdtDate { get; set; }

    public string? AdtTime { get; set; }

    public string? AdtUser { get; set; }

    public string? AdtDescription { get; set; }

    public short? AdtType { get; set; }

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
}
