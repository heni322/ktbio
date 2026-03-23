using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FMandat
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public short BtNum { get; set; }

    public int MdNo { get; set; }

    public string? MdReference { get; set; }

    public byte[]? CbMdReference { get; set; }

    public string? MdIntitule { get; set; }

    public DateTime? MdDate { get; set; }

    public short? MdTypePaiement { get; set; }

    public short? MdStatut { get; set; }

    public short? MdRevoque { get; set; }

    public short? MdB2b { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FBanquet FBanquet { get; set; } = null!;

    public virtual ICollection<FBanquet> FBanquets { get; set; } = new List<FBanquet>();
}
