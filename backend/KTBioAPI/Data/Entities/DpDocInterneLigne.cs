using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpDocInterneLigne
{
    public string? DilDeno { get; set; }

    public string? DilArref { get; set; }

    public string? DilSerielot { get; set; }

    public DateTime? DilDateperemption { get; set; }

    public DateTime? DilDatefabrication { get; set; }

    public string? DilAgno1 { get; set; }

    public string? DilAgno2 { get; set; }

    public DateTime? DilDldatebl { get; set; }

    public string DilDocnum { get; set; } = null!;

    public short DilDoctype { get; set; }

    public int DilPk { get; set; }

    public byte[]? DilDocnumbin { get; set; }

    public byte[]? DilCliUk { get; set; }

    public byte[]? DilArtUk { get; set; }

    public int? DilDlno { get; set; }

    public string? DilCodeaf { get; set; }

    public string? DilDoref { get; set; }

    public string? DilDldesign { get; set; }

    public string? DilAfreffourniss { get; set; }

    public string? DilAcrefclient { get; set; }

    public string? DilEuenumere { get; set; }

    public string? DilArtNum { get; set; }

    public string? DilCtnum { get; set; }

    public string? DilRenom { get; set; }

    public int? DilReno { get; set; }

    public string? DilAffvente { get; set; }

    public DateTime? DilDodatelivr { get; set; }

    public string? DilDodatelivran { get; set; }

    public string? DilDodatelivrsemestre { get; set; }

    public string? DilDodatelivrtrimestre { get; set; }

    public string? DilDodatelivrmois { get; set; }

    public string? DilDodatelivrweek { get; set; }

    public string DilDodatelivrjour { get; set; } = null!;

    public int? DilDlmvtstock { get; set; }

    public string DilDopiece { get; set; } = null!;

    public decimal? DilQte { get; set; }

    public decimal? DilCmup { get; set; }

    public decimal? DilPr { get; set; }

    public string? DilCode { get; set; }

    public int? DilQteressource { get; set; }
}
