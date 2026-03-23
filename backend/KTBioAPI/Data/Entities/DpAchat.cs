using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpAchat
{
    public string? ADocnum { get; set; }

    public short? ADoctype { get; set; }

    public int APk { get; set; }

    public byte[]? ADocnumbin { get; set; }

    public byte[]? AFourUk { get; set; }

    public string? AFournum { get; set; }

    public string? ADodevise { get; set; }

    public int? AInactivite { get; set; }

    public string? AType { get; set; }

    public string AStatut { get; set; } = null!;

    public string AEtat { get; set; } = null!;

    public string? ADoref { get; set; }

    public string? AFournumayeur { get; set; }

    public string? ADocan { get; set; }

    public string? ADocsemestre { get; set; }

    public string? ADoctrimestre { get; set; }

    public string? ADocmois { get; set; }

    public string? ADocweek { get; set; }

    public string ADocjour { get; set; } = null!;

    public DateTime? ADocdate { get; set; }

    public string? ACoord01 { get; set; }

    public string? ACoord02 { get; set; }

    public string? ACoord03 { get; set; }

    public string? ACoord04 { get; set; }

    public string? ADepot { get; set; }

    public string? ACondition { get; set; }

    public string? AExpedit { get; set; }

    public string? ACatcompt { get; set; }

    public string? ALangue { get; set; }

    public string? AAffaire { get; set; }

    public string? ACptgal { get; set; }

    public string? APayeur { get; set; }

    public decimal? ADocours { get; set; }

    public string ADocencours { get; set; } = null!;

    public string? ARenom { get; set; }

    public string? ACodeAffaire { get; set; }
}
