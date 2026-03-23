using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFamcomptum
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public short? FcpType { get; set; }

    public short? FcpChamp { get; set; }

    public string? FcpComptaCptCompteG { get; set; }

    public string? FcpComptaCptCompteA { get; set; }

    public string? FcpComptaCptTaxe1 { get; set; }

    public string? FcpComptaCptTaxe2 { get; set; }

    public string? FcpComptaCptTaxe3 { get; set; }

    public short? FcpTypeFacture { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? FcpComptaCptDate1 { get; set; }

    public DateTime? FcpComptaCptDate2 { get; set; }

    public DateTime? FcpComptaCptDate3 { get; set; }

    public string? FcpComptaCptTaxeAnc1 { get; set; }

    public string? FcpComptaCptTaxeAnc2 { get; set; }

    public string? FcpComptaCptTaxeAnc3 { get; set; }

    public virtual FCompteg? FcpComptaCptCompteGNavigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxe1Navigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxe2Navigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxe3Navigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxeAnc1Navigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxeAnc2Navigation { get; set; }

    public virtual FTaxe? FcpComptaCptTaxeAnc3Navigation { get; set; }
}
