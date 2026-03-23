using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpVente
{
    public decimal? VDocours { get; set; }

    public string? VDocnum { get; set; }

    public short? VDoctype { get; set; }

    public int VPk { get; set; }

    public byte[]? VDocnumbin { get; set; }

    public byte[]? VCliUk { get; set; }

    public string? VClinum { get; set; }

    public string VDodevise { get; set; } = null!;

    public int? VInactivite { get; set; }

    public string? VType { get; set; }

    public string VStatut { get; set; } = null!;

    public string VEtat { get; set; } = null!;

    public string? VDoref { get; set; }

    public string? VClinumayeur { get; set; }

    public byte[]? VClicbtnumpayeur { get; set; }

    public string? VDocan { get; set; }

    public string? VDocsemestre { get; set; }

    public string? VDoctrimestre { get; set; }

    public string? VDocmois { get; set; }

    public string? VDocweek { get; set; }

    public string VDocjour { get; set; } = null!;

    public DateTime? VDocdate { get; set; }

    public int? VLino { get; set; }

    public string? VCoord01 { get; set; }

    public string? VCoord02 { get; set; }

    public string? VCoord03 { get; set; }

    public string? VCoord04 { get; set; }

    public string? VDepot { get; set; }

    public string? VExpedit { get; set; }

    public string? VCondition { get; set; }

    public string? VPeriodicite { get; set; }

    public string? VTarif { get; set; }

    public string? VCatcompt { get; set; }

    public string? VLangue { get; set; }

    public string? VBlfact { get; set; }

    public short? VNbfact { get; set; }

    public string? VCodeaf { get; set; }

    public string? VCptgal { get; set; }

    public string? VPayeur { get; set; }

    public string? VRenom { get; set; }

    public string VDocencours { get; set; } = null!;

    public int? VReno { get; set; }

    public string? VColisage { get; set; }

    public string? VCentralachatNum { get; set; }

    public string? VCentralachatLibelle { get; set; }

    public string? VCodeAffaire { get; set; }
}
