using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDoccurrentpiece
{
    public short? DcDomaine { get; set; }

    public short? DcIdCol { get; set; }

    public short? DcSouche { get; set; }

    public string? DcPiece { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
