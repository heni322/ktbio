using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class ViewUpdateRefP
{
    public string? EcReference { get; set; }

    public string? Old { get; set; }

    public string? New { get; set; }

    public DateTime JmDate { get; set; }
}
