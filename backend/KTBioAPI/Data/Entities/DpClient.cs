using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpClient
{
    public string CliNum { get; set; } = null!;

    public byte[]? CliUk { get; set; }

    public int CliPk { get; set; }

    public string? CliAfnom { get; set; }

    public string? CliAfcode { get; set; }

    public string? CliReNom { get; set; }

    public string? CliNPeriod { get; set; }

    public string CliNDevise { get; set; } = null!;

    public string? CliNCatarif { get; set; }

    public string CliDeNo { get; set; } = null!;

    public byte[]? CliCbtnumpayeur { get; set; }

    public string? CliIntitule { get; set; }

    public string? CliClassement { get; set; }

    public string CliSommeil { get; set; } = null!;

    public string? CliNumprinc { get; set; }

    public string? CliQualite { get; set; }

    public string? CliContact { get; set; }

    public string? CliAdresse { get; set; }

    public string? CliComplement { get; set; }

    public string? CliCodepostal { get; set; }

    public string? CliVille { get; set; }

    public string? CliCoderegion { get; set; }

    public string? CliPays { get; set; }

    public string? CliSiret { get; set; }

    public string? CliIdentifiant { get; set; }

    public string? CliNaf { get; set; }

    public string? CliTelephone { get; set; }

    public string? CliTelecopie { get; set; }

    public string? CliEmail { get; set; }

    public string? CliSite { get; set; }

    public string CliLangue { get; set; } = null!;

    public string? CliCodeaffaire { get; set; }

    public string? CliNumpayeur { get; set; }

    public int? CliReno { get; set; }

    public string? CliCp { get; set; }

    public string? CliCatcompt { get; set; }

    public string? CliBan { get; set; }

    public string? CliCodban { get; set; }

    public string? CliCodguich { get; set; }

    public string? CliNcom { get; set; }

    public string? CliCle { get; set; }

    public string? CliRib { get; set; }

    public decimal? CliTaux01 { get; set; }

    public decimal? CliTaux02 { get; set; }

    public decimal? CliTaux03 { get; set; }

    public decimal? CliTaux04 { get; set; }

    public string? CliLibstat01 { get; set; }

    public string? CliLibstat02 { get; set; }

    public string? CliLibstat03 { get; set; }

    public string? CliLibstat04 { get; set; }

    public string? CliLibstat05 { get; set; }

    public string? CliLibstat06 { get; set; }

    public string? CliLibstat07 { get; set; }

    public string? CliLibstat08 { get; set; }

    public string? CliLibstat09 { get; set; }

    public string? CliLibstat10 { get; set; }

    public string? CliStat01 { get; set; }

    public string? CliStat02 { get; set; }

    public string? CliStat03 { get; set; }

    public string? CliStat04 { get; set; }

    public string? CliStat05 { get; set; }

    public string? CliStat06 { get; set; }

    public string? CliStat07 { get; set; }

    public string? CliStat08 { get; set; }

    public string? CliStat09 { get; set; }

    public string? CliStat10 { get; set; }

    public string? CliAnnecreate { get; set; }

    public string? CliSemcreate { get; set; }

    public string? CliTricreate { get; set; }

    public string? CliMoiscreate { get; set; }

    public string CliJourcreate { get; set; } = null!;

    public string? CliWeekcreate { get; set; }

    public DateTime? CliDate { get; set; }

    public string? CliEstCentraleAchat { get; set; }

    public string? CliEstRattacheAUneCentraleAchat { get; set; }

    public string? CliCentralachatNum { get; set; }

    public string? CliCentralachatLibelle { get; set; }

    public string? CliCodeAffaire1 { get; set; }

    public short? NCararif { get; set; }
}
