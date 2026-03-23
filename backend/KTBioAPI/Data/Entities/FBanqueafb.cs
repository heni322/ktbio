using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FBanqueafb
{
    public int BqNo { get; set; }

    public string IbAfb { get; set; } = null!;

    public byte[]? CbIbAfb { get; set; }

    public short IbSens { get; set; }

    public short? BaNbJoursValeur { get; set; }

    public short? BaJourType { get; set; }

    public short? BaEchReport { get; set; }

    public short? BaExoCommission { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FBanque BqNoNavigation { get; set; } = null!;

    public virtual FInterbancaire FInterbancaire { get; set; } = null!;
}
