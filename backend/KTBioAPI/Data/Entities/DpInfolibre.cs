using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpInfolibre
{
    public string CbName { get; set; } = null!;

    public short CbPos { get; set; }

    public short CbType { get; set; }
}
