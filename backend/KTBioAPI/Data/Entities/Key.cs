using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class Key
{
    public short Version { get; set; }

    public string CbType { get; set; } = null!;

    public byte[] SKey { get; set; } = null!;
}
