using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboenteteinfo
{
    public int AbNo { get; set; }

    public string AiCode { get; set; } = null!;

    public byte[]? CbAiCode { get; set; }

    public string AiIntitule { get; set; } = null!;

    public byte[]? CbAiIntitule { get; set; }

    public short? AiType { get; set; }

    public string? AiValeur { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FAboentete AbNoNavigation { get; set; } = null!;
}
