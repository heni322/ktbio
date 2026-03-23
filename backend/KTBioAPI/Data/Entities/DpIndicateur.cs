using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpIndicateur
{
    public string? Code { get; set; }

    public string? Intitule { get; set; }

    public int? Environnement { get; set; }
}
