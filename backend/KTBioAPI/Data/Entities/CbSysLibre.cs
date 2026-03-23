using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbSysLibre
{
    public string CbFile { get; set; } = null!;

    public string CbName { get; set; } = null!;

    public short CbPos { get; set; }

    public short CbType { get; set; }

    public short CbLen { get; set; }

    public short? CbFlag { get; set; }

    public string? CbFormule { get; set; }

    public string? CbCreator { get; set; }
}
