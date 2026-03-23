using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbSysTable
{
    public int CbCbaseVersion { get; set; }

    public int? CbDescVersion { get; set; }

    public string? CbCreator { get; set; }

    public string CbType { get; set; } = null!;

    public int? CbMono { get; set; }

    public int? CbVersion { get; set; }

    public int? CbTrigVersion { get; set; }

    public int? CbReplication { get; set; }

    public Guid? CbLocalGuid { get; set; }
}
