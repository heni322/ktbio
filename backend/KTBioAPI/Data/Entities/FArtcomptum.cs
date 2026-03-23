using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FArtcomptum
{
    public string ArRef { get; set; } = null!;

    public byte[]? CbArRef { get; set; }

    public short? AcpType { get; set; }

    public short? AcpChamp { get; set; }

    public string? AcpComptaCptCompteG { get; set; }

    public string? AcpComptaCptCompteA { get; set; }

    public string? AcpComptaCptTaxe1 { get; set; }

    public string? AcpComptaCptTaxe2 { get; set; }

    public string? AcpComptaCptTaxe3 { get; set; }

    public short? AcpTypeFacture { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? AcpComptaCptDate1 { get; set; }

    public DateTime? AcpComptaCptDate2 { get; set; }

    public DateTime? AcpComptaCptDate3 { get; set; }

    public string? AcpComptaCptTaxeAnc1 { get; set; }

    public string? AcpComptaCptTaxeAnc2 { get; set; }

    public string? AcpComptaCptTaxeAnc3 { get; set; }

    public virtual FCompteg? AcpComptaCptCompteGNavigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxe1Navigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxe2Navigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxe3Navigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxeAnc1Navigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxeAnc2Navigation { get; set; }

    public virtual FTaxe? AcpComptaCptTaxeAnc3Navigation { get; set; }

    public virtual FArticle ArRefNavigation { get; set; } = null!;
}
