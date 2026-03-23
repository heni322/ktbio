using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptetinfo
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string CiCode { get; set; } = null!;

    public byte[]? CbCiCode { get; set; }

    public string CiIntitule { get; set; } = null!;

    public byte[]? CbCiIntitule { get; set; }

    public short? CiDomaine { get; set; }

    public short? CiType { get; set; }

    public string? CiValeur { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
