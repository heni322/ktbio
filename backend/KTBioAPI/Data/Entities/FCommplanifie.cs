using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCommplanifie
{
    public short? CpType { get; set; }

    public short? CpMoyen { get; set; }

    public string? CpIntitule { get; set; }

    public byte[]? CbCpIntitule { get; set; }

    public short? CpFrequence { get; set; }

    public short? CpJour { get; set; }

    public string? CpHeure { get; set; }

    public short? CpDemarrage { get; set; }

    public string? DeIntituleDe { get; set; }

    public string? DeIntituleA { get; set; }

    public short? CpValideArt { get; set; }

    public short? CpValideCli { get; set; }

    public short? CpValideInven { get; set; }

    public short? CpValideRglt { get; set; }

    public short? CpTypeArt { get; set; }

    public string? FaCodeFamilleDe { get; set; }

    public string? FaCodeFamilleA { get; set; }

    public string? ArRefDe { get; set; }

    public string? ArRefA { get; set; }

    public DateTime? ArDateCreationDe { get; set; }

    public DateTime? ArDateCreationA { get; set; }

    public DateTime? ArDateModifDe { get; set; }

    public DateTime? ArDateModifA { get; set; }

    public short? CpTransmission { get; set; }

    public string? CtNumDe { get; set; }

    public string? CtNumA { get; set; }

    public DateTime? CtDateCreateDe { get; set; }

    public DateTime? CtDateCreateA { get; set; }

    public DateTime? CpDateInven { get; set; }

    public short? CpTypeInven { get; set; }

    public short? CpReajusteInven { get; set; }

    public short? CpArtRecept { get; set; }

    public short? CpCliRecept { get; set; }

    public short? CpReajusteRecept { get; set; }

    public short? CpSuppRecept { get; set; }

    public short? CpTypeRglt { get; set; }

    public short? CpEtatRglt { get; set; }

    public DateTime? CpDateRgltDe { get; set; }

    public DateTime? CpDateRgltA { get; set; }

    public short? CpTransBcrglt { get; set; }

    public short? CpSuppBcrglt { get; set; }

    public short? CpCptaRglt { get; set; }

    public int? CpNo { get; set; }

    public short? CpOrigine { get; set; }

    public short? CpEtatStockInven { get; set; }

    public short? CpTypeTransmissionInven { get; set; }

    public short? CpDetEmplacementInven { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }
}
