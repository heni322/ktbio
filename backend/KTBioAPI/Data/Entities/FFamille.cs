using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FFamille
{
    public string FaCodeFamille { get; set; } = null!;

    public byte[]? CbFaCodeFamille { get; set; }

    public short? FaType { get; set; }

    public string? FaIntitule { get; set; }

    public byte[]? CbFaIntitule { get; set; }

    public short? FaUniteVen { get; set; }

    public decimal? FaCoef { get; set; }

    public short? FaSuiviStock { get; set; }

    public short? FaGarantie { get; set; }

    public string? FaCentral { get; set; }

    public byte[]? CbFaCentral { get; set; }

    public string? FaStat01 { get; set; }

    public string? FaStat02 { get; set; }

    public string? FaStat03 { get; set; }

    public string? FaStat04 { get; set; }

    public string? FaStat05 { get; set; }

    public string? FaCodeFiscal { get; set; }

    public string? FaPays { get; set; }

    public short? FaUnitePoids { get; set; }

    public short? FaEscompte { get; set; }

    public short? FaDelai { get; set; }

    public short? FaHorsStat { get; set; }

    public short? FaVteDebit { get; set; }

    public short? FaNotImp { get; set; }

    public string? FaFrais01FrDenomination { get; set; }

    public decimal? FaFrais01FrRem01RemValeur { get; set; }

    public short? FaFrais01FrRem01RemType { get; set; }

    public decimal? FaFrais01FrRem02RemValeur { get; set; }

    public short? FaFrais01FrRem02RemType { get; set; }

    public decimal? FaFrais01FrRem03RemValeur { get; set; }

    public short? FaFrais01FrRem03RemType { get; set; }

    public string? FaFrais02FrDenomination { get; set; }

    public decimal? FaFrais02FrRem01RemValeur { get; set; }

    public short? FaFrais02FrRem01RemType { get; set; }

    public decimal? FaFrais02FrRem02RemValeur { get; set; }

    public short? FaFrais02FrRem02RemType { get; set; }

    public decimal? FaFrais02FrRem03RemValeur { get; set; }

    public short? FaFrais02FrRem03RemType { get; set; }

    public string? FaFrais03FrDenomination { get; set; }

    public decimal? FaFrais03FrRem01RemValeur { get; set; }

    public short? FaFrais03FrRem01RemType { get; set; }

    public decimal? FaFrais03FrRem02RemValeur { get; set; }

    public short? FaFrais03FrRem02RemType { get; set; }

    public decimal? FaFrais03FrRem03RemValeur { get; set; }

    public short? FaFrais03FrRem03RemType { get; set; }

    public short? FaContremarque { get; set; }

    public short? FaFactPoids { get; set; }

    public short? FaFactForfait { get; set; }

    public short? FaPublie { get; set; }

    public string? FaRacineRef { get; set; }

    public string? FaRacineCb { get; set; }

    public int? ClNo1 { get; set; }

    public int? CbClNo1 { get; set; }

    public int? ClNo2 { get; set; }

    public int? CbClNo2 { get; set; }

    public int? ClNo3 { get; set; }

    public int? CbClNo3 { get; set; }

    public int? ClNo4 { get; set; }

    public int? CbClNo4 { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? FaNature { get; set; }

    public short? FaNbColis { get; set; }

    public short? FaSousTraitance { get; set; }

    public short? FaFictif { get; set; }

    public short? FaCriticite { get; set; }

    public virtual FCatalogue? CbClNo1Navigation { get; set; }

    public virtual FCatalogue? CbClNo2Navigation { get; set; }

    public virtual FCatalogue? CbClNo3Navigation { get; set; }

    public virtual FCatalogue? CbClNo4Navigation { get; set; }
}
