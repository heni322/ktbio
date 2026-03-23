using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FLignearchive
{
    public string TaPiece { get; set; } = null!;

    public string? ArRef { get; set; }

    public byte[]? CbArRef { get; set; }

    public string? LaDesign { get; set; }

    public decimal? LaPrixUnitaire { get; set; }

    public decimal? LaPuttc { get; set; }

    public short? LaTtc { get; set; }

    public decimal? LaQte { get; set; }

    public decimal? LaRemise01RemValeur { get; set; }

    public short? LaRemise01RemType { get; set; }

    public decimal? LaRemise02RemValeur { get; set; }

    public short? LaRemise02RemType { get; set; }

    public decimal? LaRemise03RemValeur { get; set; }

    public short? LaRemise03RemType { get; set; }

    public int? LaLigne { get; set; }

    public decimal? LaTaxe1 { get; set; }

    public short? LaTypeTaux1 { get; set; }

    public short? LaTypeTaxe1 { get; set; }

    public decimal? LaTaxe2 { get; set; }

    public short? LaTypeTaux2 { get; set; }

    public short? LaTypeTaxe2 { get; set; }

    public decimal? LaTaxe3 { get; set; }

    public short? LaTypeTaux3 { get; set; }

    public short? LaTypeTaxe3 { get; set; }

    public int? AgNo1 { get; set; }

    public int? AgNo2 { get; set; }

    public string? LsNoSerie { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public decimal? LaPoidsNet { get; set; }

    public short? LaTremExep { get; set; }

    public decimal? LaPrixRu { get; set; }

    public decimal? LaCmup { get; set; }

    public string? EuEnumere { get; set; }

    public decimal? EuQte { get; set; }

    public short? LaFactPoids { get; set; }

    public short? LaEscompte { get; set; }

    public short? LaValorise { get; set; }

    public string? LsComplement { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbTaPiece { get; set; }

    public virtual FArticle? ArRefNavigation { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FTicketarchive TaPieceNavigation { get; set; } = null!;
}
