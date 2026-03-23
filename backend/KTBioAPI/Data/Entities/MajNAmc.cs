using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class MajNAmc
{
    public string ArRef { get; set; } = null!;

    public string? NPièce { get; set; }

    public string? Amc { get; set; }

    public DateTime? LsFabrication { get; set; }

    public DateTime? LsPeremption { get; set; }

    public string? ArDesign { get; set; }

    public string? FaIntitule { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public int DeNo { get; set; }

    public string DeIntitule { get; set; } = null!;

    public string? LsNoSerie { get; set; }
}
