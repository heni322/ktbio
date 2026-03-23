using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FBanque
{
    public int BqNo { get; set; }

    public string? BqIntitule { get; set; }

    public byte[]? CbBqIntitule { get; set; }

    public string? BqAdresse { get; set; }

    public string? BqComplement { get; set; }

    public string? BqCodePostal { get; set; }

    public string? BqVille { get; set; }

    public string? BqCodeRegion { get; set; }

    public string? BqPays { get; set; }

    public string? BqContact { get; set; }

    public string? BqAbrege { get; set; }

    public byte[]? CbBqAbrege { get; set; }

    public short? BqModeRemise { get; set; }

    public short? BqBordRemise { get; set; }

    public DateTime? BqDaillyDateConv { get; set; }

    public string? BqDaillyNatJur { get; set; }

    public string? BqDaillyAdresse { get; set; }

    public string? BqDaillyComplement { get; set; }

    public string? BqDaillyCodePostal { get; set; }

    public string? BqDaillyVille { get; set; }

    public string? BqDaillyRcs { get; set; }

    public string? BqBic { get; set; }

    public string? BqCodeIdent { get; set; }

    public short? BqAchat { get; set; }

    public short? BqRemise { get; set; }

    public short? BqDoadresse { get; set; }

    public short? BqDoville { get; set; }

    public short? BqDocodePostal { get; set; }

    public short? BqDosiret { get; set; }

    public short? BqDocodeIdent { get; set; }

    public short? BqDoagenceVille { get; set; }

    public short? BqDoagenceCp { get; set; }

    public short? BqDotypeIdent { get; set; }

    public short? BqDocle { get; set; }

    public short? BqVtadresse { get; set; }

    public short? BqVtville { get; set; }

    public short? BqVtcodePostal { get; set; }

    public short? BqVtsiret { get; set; }

    public short? BqVtpays { get; set; }

    public short? BqVtcontrat { get; set; }

    public short? BqVtdateAchat { get; set; }

    public short? BqVttauxChange { get; set; }

    public short? BqVtinstruction { get; set; }

    public short? BqBbintitule { get; set; }

    public short? BqBbbic { get; set; }

    public short? BqBbadresse { get; set; }

    public short? BqBbville { get; set; }

    public short? BqBbcodePostal { get; set; }

    public short? BqBbcompte { get; set; }

    public short? BqBiintitule { get; set; }

    public short? BqBibic { get; set; }

    public short? BqBiadresse { get; set; }

    public short? BqBiville { get; set; }

    public short? BqBicodePostal { get; set; }

    public short? BqBipays { get; set; }

    public string? BqTelephone { get; set; }

    public string? BqTelecopie { get; set; }

    public string? BqEmail { get; set; }

    public string? BqSite { get; set; }

    public short? BqCondDecouvertCdTypePlafond { get; set; }

    public short? BqCondDecouvertCdBaseCalcul { get; set; }

    public int? BqCondDecouvertTrNo { get; set; }

    public int? CbBqCondDecouvertTrNo { get; set; }

    public decimal? BqCondDecouvertCdValeurTaux { get; set; }

    public decimal? BqCondDecouvertCdPlafond01CdValeurPlafond { get; set; }

    public decimal? BqCondDecouvertCdPlafond01CdMarge { get; set; }

    public decimal? BqCondDecouvertCdPlafond02CdValeurPlafond { get; set; }

    public decimal? BqCondDecouvertCdPlafond02CdMarge { get; set; }

    public short? BqCondInteretCiType { get; set; }

    public int? BqCondInteretTrNo { get; set; }

    public int? CbBqCondInteretTrNo { get; set; }

    public decimal? BqCondInteretCiTaux { get; set; }

    public short? BqCondInteretCiAssiette { get; set; }

    public short? BqCondInteretCiLimite { get; set; }

    public short? BqCondInteretCiBaseCalcul { get; set; }

    public short? BqCondCommissionCcType { get; set; }

    public int? BqCondCommissionCcLimite { get; set; }

    public decimal? BqCondCommissionCcTaux { get; set; }

    public decimal? BqCondFraisCfCommission { get; set; }

    public decimal? BqCondFraisCfCompte { get; set; }

    public short? BqCondFraisCfPeriodicite { get; set; }

    public decimal? BqCondFraisCfSeuilExoneration { get; set; }

    public short? BqCondFraisCfTypeExoneration { get; set; }

    public decimal? BqCondFraisCfSeuilCrediteur { get; set; }

    public short? BqCondFraisCfModePerception { get; set; }

    public decimal? BqCondFraisCfMontantVariableHt { get; set; }

    public decimal? BqCondFraisCfMinimumPercu { get; set; }

    public decimal? BqCondFraisCfMaximumPercu { get; set; }

    public short? BqCondFraisCfAssujetTvacommission { get; set; }

    public short? BqCondFraisCfAssujetTvafrais { get; set; }

    public string? BqTransEmailEnvoi { get; set; }

    public string? BqTransSite { get; set; }

    public short? BqFormatVir { get; set; }

    public short? BqFormatVirInter { get; set; }

    public short? BqDelaiHeure01DhJourTeletrans { get; set; }

    public short? BqDelaiHeure01DhJourFichier { get; set; }

    public string? BqDelaiHeure01DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure01DhHeureFichier { get; set; }

    public short? BqDelaiHeure02DhJourTeletrans { get; set; }

    public short? BqDelaiHeure02DhJourFichier { get; set; }

    public string? BqDelaiHeure02DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure02DhHeureFichier { get; set; }

    public short? BqDelaiHeure03DhJourTeletrans { get; set; }

    public short? BqDelaiHeure03DhJourFichier { get; set; }

    public string? BqDelaiHeure03DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure03DhHeureFichier { get; set; }

    public short? BqDelaiHeure04DhJourTeletrans { get; set; }

    public short? BqDelaiHeure04DhJourFichier { get; set; }

    public string? BqDelaiHeure04DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure04DhHeureFichier { get; set; }

    public short? BqDelaiHeure05DhJourTeletrans { get; set; }

    public short? BqDelaiHeure05DhJourFichier { get; set; }

    public string? BqDelaiHeure05DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure05DhHeureFichier { get; set; }

    public short? BqDelaiHeure06DhJourTeletrans { get; set; }

    public short? BqDelaiHeure06DhJourFichier { get; set; }

    public string? BqDelaiHeure06DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure06DhHeureFichier { get; set; }

    public short? BqDelaiHeure07DhJourTeletrans { get; set; }

    public short? BqDelaiHeure07DhJourFichier { get; set; }

    public string? BqDelaiHeure07DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure07DhHeureFichier { get; set; }

    public short? BqDelaiHeure08DhJourTeletrans { get; set; }

    public short? BqDelaiHeure08DhJourFichier { get; set; }

    public string? BqDelaiHeure08DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure08DhHeureFichier { get; set; }

    public short? BqDelaiHeure09DhJourTeletrans { get; set; }

    public short? BqDelaiHeure09DhJourFichier { get; set; }

    public string? BqDelaiHeure09DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure09DhHeureFichier { get; set; }

    public short? BqDelaiHeure10DhJourTeletrans { get; set; }

    public short? BqDelaiHeure10DhJourFichier { get; set; }

    public string? BqDelaiHeure10DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure10DhHeureFichier { get; set; }

    public short? BqDelaiHeure11DhJourTeletrans { get; set; }

    public short? BqDelaiHeure11DhJourFichier { get; set; }

    public string? BqDelaiHeure11DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure11DhHeureFichier { get; set; }

    public short? BqDelaiHeure12DhJourTeletrans { get; set; }

    public short? BqDelaiHeure12DhJourFichier { get; set; }

    public string? BqDelaiHeure12DhHeureTeletrans { get; set; }

    public string? BqDelaiHeure12DhHeureFichier { get; set; }

    public string? BqVtcodeService { get; set; }

    public short? BqFormatPrel { get; set; }

    public short? BqFormatPrelVersion { get; set; }

    public short? BqFormatVirVersion { get; set; }

    public string? CgNumFraisOpcvm { get; set; }

    public byte[]? CbCgNumFraisOpcvm { get; set; }

    public string? CgNumTvaopcvm { get; set; }

    public byte[]? CbCgNumTvaopcvm { get; set; }

    public string? CgNumMoinsValueOpcvm { get; set; }

    public byte[]? CbCgNumMoinsValueOpcvm { get; set; }

    public string? CgNumPlusValueOpcvm { get; set; }

    public byte[]? CbCgNumPlusValueOpcvm { get; set; }

    public short? BqVtimputation { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? BqModeleParam { get; set; }

    public virtual FCompteg? CgNumFraisOpcvmNavigation { get; set; }

    public virtual FCompteg? CgNumMoinsValueOpcvmNavigation { get; set; }

    public virtual FCompteg? CgNumPlusValueOpcvmNavigation { get; set; }

    public virtual FCompteg? CgNumTvaopcvmNavigation { get; set; }

    public virtual ICollection<FAutorisationfinbq> FAutorisationfinbqs { get; set; } = new List<FAutorisationfinbq>();

    public virtual ICollection<FBanqueafb> FBanqueafbs { get; set; } = new List<FBanqueafb>();

    public virtual ICollection<FContactb> FContactbs { get; set; } = new List<FContactb>();

    public virtual ICollection<FEbanque> FEbanques { get; set; } = new List<FEbanque>();
}
