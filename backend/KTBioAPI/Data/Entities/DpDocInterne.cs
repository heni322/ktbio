using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpDocInterne
{
    public string? DiDocnum { get; set; }

    public short? DiDoctype { get; set; }

    public string? DiIntitule { get; set; }

    public decimal? DiDocours { get; set; }

    public int DiPk { get; set; }

    public byte[]? DiDocnumbin { get; set; }

    public byte[]? DiCliUk { get; set; }

    public string? DiClinum { get; set; }

    public string DiDodevise { get; set; } = null!;

    public short? DiType { get; set; }

    public string? DiStatut { get; set; }

    public string? DiDoref { get; set; }

    public string? DiClinumayeur { get; set; }

    public byte[]? DiClicbtnumpayeur { get; set; }

    public string? DiDocan { get; set; }

    public string? DiDocsemestre { get; set; }

    public string? DiDoctrimestre { get; set; }

    public string? DiDocmois { get; set; }

    public string? DiDocweek { get; set; }

    public string DiDocjour { get; set; } = null!;

    public DateTime? DiDocdate { get; set; }

    public int? DiLino { get; set; }

    public string? DiCoord01 { get; set; }

    public string? DiCoord02 { get; set; }

    public string? DiCoord03 { get; set; }

    public string? DiCoord04 { get; set; }

    public string? DiDepot { get; set; }

    public string? DiExpedit { get; set; }

    public string? DiCondition { get; set; }

    public string? DiPeriodicite { get; set; }

    public string? DiTarif { get; set; }

    public short? DiCatcompt { get; set; }

    public string? DiLangue { get; set; }

    public string? DiBlfact { get; set; }

    public short? DiNbfact { get; set; }

    public string? DiCodeaf { get; set; }

    public string? DiCptgal { get; set; }

    public string? DiPayeur { get; set; }

    public string? DiRenom { get; set; }

    public int? DiReno { get; set; }
}
