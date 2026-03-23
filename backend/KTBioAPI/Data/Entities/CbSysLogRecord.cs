using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbSysLogRecord
{
    public short CbOperation { get; set; }

    public DateTime? CbDateOperation { get; set; }

    public string CbCreator { get; set; } = null!;

    public Guid? CbSiteOrigine { get; set; }

    public int CbReplication { get; set; }

    public byte[] CbIdentifiant { get; set; } = null!;

    public int CbMarq { get; set; }

    public string CbFile { get; set; } = null!;

    public int CbLogMarq { get; set; }
}
