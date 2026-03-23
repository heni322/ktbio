using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpMvtStock
{
    public string? MvtstDeno { get; set; }

    public string? MvtstArref { get; set; }

    public string? MvtstNumeroserielot { get; set; }

    public string? MvtstArsuivistock { get; set; }

    public string? MvtstAgno1 { get; set; }

    public string? MvtstAgno2 { get; set; }

    public DateTime? MvtstDldatebl { get; set; }

    public string? MvtstDldatean { get; set; }

    public string? MvtstDldateblsemestre { get; set; }

    public string? MvtstDldatebltrimestre { get; set; }

    public string? Mvtstdldateblmois { get; set; }

    public string? MvtstDldateblweek { get; set; }

    public string MvtstDldatebljour { get; set; } = null!;

    public DateTime? MvtstDateperemption { get; set; }

    public DateTime? MvtstDatefabrication { get; set; }

    public int? MvtstDlmvtstock { get; set; }

    public string MvtstDopiece { get; set; } = null!;

    public int? MvtstDlno { get; set; }

    public int MvtstPk { get; set; }

    public decimal? MvtstQte { get; set; }

    public decimal? MvtstCmup { get; set; }

    public byte[]? MvtstUk { get; set; }

    public short MvtstTypeCode { get; set; }

    public string? MvtstType { get; set; }

    public int? MvtstReNo { get; set; }

    public string? MvtstReNom { get; set; }
}
