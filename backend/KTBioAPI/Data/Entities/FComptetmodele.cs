using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptetmodele
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public int? CmCreator { get; set; }

    public short? CmType { get; set; }

    public string? CmModele { get; set; }

    public short? CmNbExemplaire { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;
}
