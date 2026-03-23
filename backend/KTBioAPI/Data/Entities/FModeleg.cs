using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FModeleg
{
    public int MgNo { get; set; }

    public short? MgType { get; set; }

    public string? MgIntitule { get; set; }

    public byte[]? CbMgIntitule { get; set; }

    public string? MgRaccourci { get; set; }

    public byte[]? CbMgRaccourci { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FEmodeleg> FEmodelegs { get; set; } = new List<FEmodeleg>();
}
