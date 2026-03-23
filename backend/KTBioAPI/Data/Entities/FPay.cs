using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FPay
{
    public string? PaIntitule { get; set; }

    public byte[]? CbPaIntitule { get; set; }

    public string? PaCode { get; set; }

    public string? PaCodeEdi { get; set; }

    public decimal? PaAssurance { get; set; }

    public decimal? PaTransport { get; set; }

    public string? PaCodeIso2 { get; set; }

    public short? PaSepa { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public int? PaNo { get; set; }
}
