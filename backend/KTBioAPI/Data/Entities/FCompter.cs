using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCompter
{
    public string CrNum { get; set; } = null!;

    public byte[]? CbCrNum { get; set; }

    public short? CrType { get; set; }

    public string? CrIntitule { get; set; }

    public string? CrClassement { get; set; }

    public byte[]? CbCrClassement { get; set; }

    public short? CrSaut { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FCompteg> FComptegs { get; set; } = new List<FCompteg>();
}
