using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEextraitlib
{
    public int ExNo { get; set; }

    public short EeLigne { get; set; }

    public short? ElLigne { get; set; }

    public short? ElType { get; set; }

    public string? ElIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEextrait FEextrait { get; set; } = null!;
}
