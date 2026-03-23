using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCyclecon
{
    public string? CyNum { get; set; }

    public byte[]? CbCyNum { get; set; }

    public short? CcExercice { get; set; }

    public string? CoNum { get; set; }

    public byte[]? CbCoNum { get; set; }

    public string? CcReviseur { get; set; }

    public DateTime? CcDateRevis { get; set; }

    public string? CcControleur { get; set; }

    public DateTime? CcDateControl { get; set; }

    public string? CcCommentaire { get; set; }

    public short? CcAnnexe { get; set; }

    public short? CcReponse { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
