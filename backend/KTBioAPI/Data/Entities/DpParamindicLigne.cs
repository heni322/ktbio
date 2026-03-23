using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpParamindicLigne
{
    public string CodeDomaine { get; set; } = null!;

    public string NumLigne { get; set; } = null!;

    public string CodeIndic { get; set; } = null!;

    public int? Racine { get; set; }

    public int? Coche { get; set; }
}
