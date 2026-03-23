using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpTier
{
    public string TiNum { get; set; } = null!;

    public byte[]? TiUk { get; set; }

    public int TiPk { get; set; }

    public short? TiBtnum { get; set; }

    public string? TiCanum { get; set; }

    public int? TiReno { get; set; }

    public int? TiDeno { get; set; }

    public short? TiNdevise { get; set; }

    public string TiCgnumprinc { get; set; } = null!;

    public short? TiNrisque { get; set; }

    public string? TiLibstat01 { get; set; }

    public string? TiLibstat02 { get; set; }

    public string? TiLibstat03 { get; set; }

    public string? TiLibstat04 { get; set; }

    public string? TiLibstat05 { get; set; }

    public string? TiLibstat06 { get; set; }

    public string? TiLibstat07 { get; set; }

    public string? TiLibstat08 { get; set; }

    public string? TiLibstat09 { get; set; }

    public string? TiLibstat10 { get; set; }

    public string TiNomdevise { get; set; } = null!;

    public string? TiBanintitu { get; set; }

    public string? TiBancode { get; set; }

    public string? TiBanguich { get; set; }

    public string? TiBancpte { get; set; }

    public string? TiBancle { get; set; }

    public string? TiBanrib { get; set; }

    public string TiStructure { get; set; } = null!;

    public string? TiNomdevisebanque { get; set; }

    public string? TiCoderisque { get; set; }

    public string? TiStat01 { get; set; }

    public string? TiStat02 { get; set; }

    public string? TiStat03 { get; set; }

    public string? TiStat04 { get; set; }

    public string? TiStat05 { get; set; }

    public string? TiStat06 { get; set; }

    public string? TiStat07 { get; set; }

    public string? TiStat08 { get; set; }

    public string? TiStat09 { get; set; }

    public string? TiStat10 { get; set; }

    public string TiCttype { get; set; } = null!;

    public string? TiIntitule { get; set; }

    public string? TiClass { get; set; }

    public string? TiCtqualite { get; set; }

    public string? TiContact { get; set; }

    public string? TiCtadresse { get; set; }

    public string? TiCtcomplement { get; set; }

    public string? TiCtcodepostal { get; set; }

    public string? TiCtville { get; set; }

    public string? TiCtcoderegion { get; set; }

    public string? TiCtpays { get; set; }

    public string? TiCtsiret { get; set; }

    public string? TiCtidentifiant { get; set; }

    public string? TiCttelephone { get; set; }

    public string? TiCttelecopie { get; set; }

    public string? TiCtemail { get; set; }

    public string? TiCtsite { get; set; }

    public string TiCtlangue { get; set; } = null!;

    public string TiLettrage { get; set; } = null!;

    public string TiCtvalidech { get; set; } = null!;

    public string TiCtnotrappel { get; set; } = null!;

    public string TiCtsommeil { get; set; } = null!;

    public string? TiCtcommentaire { get; set; }

    public string TiCtcontrolenc { get; set; } = null!;

    public string TiCtsurveillance { get; set; } = null!;

    public decimal? TiCtencours { get; set; }

    public decimal? TiCtassurance { get; set; }

    public string? TiCp { get; set; }

    public DateTime? TiSvdatecreationsoc { get; set; }

    public string? TiSvformejuridique { get; set; }

    public string? TiSveffectif { get; set; }

    public decimal? TiSvca { get; set; }

    public decimal? TiSvresultat { get; set; }

    public short? TiSvincidentcode { get; set; }

    public string TiSvincidentintitule { get; set; } = null!;

    public DateTime? TiSvdateincident { get; set; }

    public short? TiSvprivilcode { get; set; }

    public string TiSvprivilintitule { get; set; } = null!;

    public string? TiSvregul { get; set; }

    public string? TiSvcotation { get; set; }

    public DateTime? TiSvdatemaj { get; set; }

    public string? TiSvobjetmaj { get; set; }

    public DateTime? TiSvdatebilan { get; set; }

    public short? TiSvnbmoisbilan { get; set; }
}
