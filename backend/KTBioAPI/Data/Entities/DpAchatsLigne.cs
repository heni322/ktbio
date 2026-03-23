using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpAchatsLigne
{
    public string AlDocnum { get; set; } = null!;

    public short AlDoctype { get; set; }

    public int AlPk { get; set; }

    public byte[]? AlDocnumbin { get; set; }

    public byte[]? AlFourUk { get; set; }

    public byte[]? AlArtUk { get; set; }

    public int? AlDlno { get; set; }

    public string? AlDeno { get; set; }

    public string? AlCanum { get; set; }

    public string? AlDoref { get; set; }

    public string? AlDldesign { get; set; }

    public string? AlAfreffourniss { get; set; }

    public string? AlEuenumere { get; set; }

    public string? AlAgno1 { get; set; }

    public string? AlAgno2 { get; set; }

    public DateTime? AlDodatelivr { get; set; }

    public string? AlDodatelivran { get; set; }

    public string? AlDodatelivrsemestre { get; set; }

    public string? AlDodatelivrtrimestre { get; set; }

    public string? AlDodatelivrmois { get; set; }

    public string? AlDodatelivrweek { get; set; }

    public string AlDodatelivrjour { get; set; } = null!;

    public string? AlArtNum { get; set; }

    public string? Numeroserielot { get; set; }

    public DateTime? AlDateperemption { get; set; }

    public DateTime? AlDatefabrication { get; set; }

    public string? AlCtnum { get; set; }

    public string? AlDlpiecebc { get; set; }

    public string? AlDlpiecebl { get; set; }

    public DateTime? AlDldatebc { get; set; }

    public DateTime? AlDldatebl { get; set; }

    public string? AlDltaxe1 { get; set; }

    public string? AlDltaxe2 { get; set; }

    public string? AlDltaxe3 { get; set; }

    public decimal? AlPourcentremise { get; set; }

    public decimal? AlCahtbrut { get; set; }

    public decimal? Cattcbrut { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public decimal? Qtevendues { get; set; }

    public decimal? Qtecommande { get; set; }

    public decimal? Qtelivre { get; set; }

    public string? AlReNom { get; set; }
}
