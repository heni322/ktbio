using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpDocFabricationLigne
{
    public string? DfalDeno { get; set; }

    public short DfalDotype { get; set; }

    public string? DfalArref { get; set; }

    public string? DfalSerielot { get; set; }

    public DateTime? DfalDateperemption { get; set; }

    public DateTime? DfalDatefabrication { get; set; }

    public string? DfalAgno1 { get; set; }

    public string? DfalAgno2 { get; set; }

    public string? DfalDocan { get; set; }

    public string? DfalDocsemestre { get; set; }

    public string? DfalDoctrimestre { get; set; }

    public string? DfalDocmois { get; set; }

    public string? DfalDocweek { get; set; }

    public string DfalDocjour { get; set; } = null!;

    public DateTime? DfalDocdate { get; set; }

    public string DfalDocnum { get; set; } = null!;

    public byte[]? DfalDocnumbin { get; set; }

    public byte[]? DfalCliUk { get; set; }

    public byte[]? DfalArtUk { get; set; }

    public int? DfalDlno { get; set; }

    public string? DfalDldesign { get; set; }

    public string? DfalDoref { get; set; }

    public string? DfalEuenumere { get; set; }

    public DateTime? DfalDodatelivr { get; set; }

    public string? DfalDodatelivran { get; set; }

    public string? DfalDodatelivrsemestre { get; set; }

    public string? DfalDodatelivrtrimestre { get; set; }

    public string? DfalDodatelivrmois { get; set; }

    public string? DfalDodatelivrweek { get; set; }

    public string? DfalDodatelivrjour { get; set; }

    public int? DfalDlmvtstock { get; set; }

    public int DfalPk { get; set; }

    public decimal? DfalQte { get; set; }

    public decimal? DfalCmup { get; set; }

    public decimal? DfalPr { get; set; }

    public string? DfalDlpiecebc { get; set; }

    public DateTime? DfalDldatebc { get; set; }

    public string? DfalDlpiecebl { get; set; }

    public DateTime? DfalDldatebl { get; set; }

    public string? DfalDlpiecepl { get; set; }

    public DateTime? DfalDldatepl { get; set; }

    public string? DfalCode { get; set; }

    public int? DfalQteressource { get; set; }
}
