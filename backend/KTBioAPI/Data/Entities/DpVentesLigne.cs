using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpVentesLigne
{
    public string VlDocnum { get; set; } = null!;

    public short VlDoctype { get; set; }

    public int VlPk { get; set; }

    public byte[]? VlDocnumbin { get; set; }

    public byte[]? VlCliUk { get; set; }

    public byte[]? VlArtUk { get; set; }

    public string? Numeroserielot { get; set; }

    public DateTime? VlDateperemption { get; set; }

    public DateTime? VlDatefabrication { get; set; }

    public int? VlDlno { get; set; }

    public string? VlDeno { get; set; }

    public string? VlCodeaf { get; set; }

    public string? VlDlpiecebc { get; set; }

    public string? VlDlpiecebl { get; set; }

    public DateTime? VlDldatebc { get; set; }

    public DateTime? VlDatebl { get; set; }

    public string? VlDoref { get; set; }

    public string? VlDldesign { get; set; }

    public string? VlAfreffourniss { get; set; }

    public string? VlAcrefclient { get; set; }

    public string? VlEuenumere { get; set; }

    public string? VlAgno1 { get; set; }

    public string? VlAgno2 { get; set; }

    public string? VlArtNum { get; set; }

    public string? VlCtnum { get; set; }

    public string? VlRenom { get; set; }

    public int? VlReno { get; set; }

    public string? VlAffvente { get; set; }

    public string? VlDltaxe1 { get; set; }

    public string? VlDltaxe2 { get; set; }

    public string? VlDltaxe3 { get; set; }

    public DateTime? VlDodatelivr { get; set; }

    public string? VlDodatelivran { get; set; }

    public string? VDodatelivrsemestre { get; set; }

    public string? VlDodatelivrtrimestre { get; set; }

    public string? VlDodatelivrmois { get; set; }

    public string? VlDodatelivrweek { get; set; }

    public string VlDodatelivrjour { get; set; } = null!;

    public decimal? VlPourcentremise { get; set; }

    public decimal? VlCahtbrut { get; set; }

    public decimal? Cattcbrut { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public decimal Prxrevientu { get; set; }

    public decimal? Qtevendues { get; set; }

    public decimal? Qtecommande { get; set; }

    public decimal? Qtelivre { get; set; }

    public decimal? Marge { get; set; }

    public string? VlCode { get; set; }

    public DateTime? VlDocmodification { get; set; }

    public int? VlQteressource { get; set; }
}
