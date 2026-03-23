using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFinancier
{
    public int FiNo { get; set; }

    public DateTime? FiDate { get; set; }

    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public string? FiExtrait { get; set; }

    public decimal? FiSoldeInitial { get; set; }

    public decimal? FiSoldeFinal { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FEfinancier> FEfinanciers { get; set; } = new List<FEfinancier>();
}
