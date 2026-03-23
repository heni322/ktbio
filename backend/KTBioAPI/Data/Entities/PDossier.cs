using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PDossier
{
    public string? DRaisonSoc { get; set; }

    public string? DProfession { get; set; }

    public string? DAdresse { get; set; }

    public string? DComplement { get; set; }

    public string? DCodePostal { get; set; }

    public string? DVille { get; set; }

    public string? DCodeRegion { get; set; }

    public string? DPays { get; set; }

    public string? DCommentaire { get; set; }

    public string? DSiret { get; set; }

    public string? DApe { get; set; }

    public string? DIdentifiant { get; set; }

    public DateTime? DDebutExo01 { get; set; }

    public DateTime? DDebutExo02 { get; set; }

    public DateTime? DDebutExo03 { get; set; }

    public DateTime? DDebutExo04 { get; set; }

    public DateTime? DDebutExo05 { get; set; }

    public DateTime? DFinExo01 { get; set; }

    public DateTime? DFinExo02 { get; set; }

    public DateTime? DFinExo03 { get; set; }

    public DateTime? DFinExo04 { get; set; }

    public DateTime? DFinExo05 { get; set; }

    public short? DLgCg { get; set; }

    public short? DLgAn { get; set; }

    public string? DFormatQtes { get; set; }

    public short? DCodeTrait { get; set; }

    public short? DConfSupp { get; set; }

    public short? DAnalyseGl01 { get; set; }

    public short? DAnalyseGl02 { get; set; }

    public short? DAnalyseGl03 { get; set; }

    public short? DDelai { get; set; }

    public short? DOuvCompte { get; set; }

    public short? DBudget { get; set; }

    public short? DSuppEc { get; set; }

    public short? DRegTaxe { get; set; }

    public short? DVentil { get; set; }

    public short? DEdi { get; set; }

    public short? DArchivage01 { get; set; }

    public short? DArchivage02 { get; set; }

    public short? DArchivage03 { get; set; }

    public short? DArchivage04 { get; set; }

    public short? DArchivage05 { get; set; }

    public short? DRbsupp { get; set; }

    public short? DMajImport { get; set; }

    public short? DSaisCab { get; set; }

    public short? DTypeValid { get; set; }

    public short? DImpressZero { get; set; }

    public short? NDeviseCompte { get; set; }

    public short? NDeviseEquival { get; set; }

    public short? DAnsais { get; set; }

    public string? JoNumAn { get; set; }

    public string? CgNumAnouv { get; set; }

    public string? CgNumAnbenef { get; set; }

    public string? CgNumAnperte { get; set; }

    public short? DTvaencReg { get; set; }

    public short? DTvaencAffect { get; set; }

    public short? DDeviseEq { get; set; }

    public short? DAnAffect { get; set; }

    public short? DReglPiece { get; set; }

    public short? DExtNeg { get; set; }

    public short? DRapproDevise { get; set; }

    public short? DImportEqJo { get; set; }

    public short? DImportEqAn { get; set; }

    public string? CgNumImportDebit { get; set; }

    public string? CgNumImportCredit { get; set; }

    public short? NAnalytique { get; set; }

    public string? DNumDoss { get; set; }

    public string? DEmail { get; set; }

    public string? DEmailExpert { get; set; }

    public string? DExpert { get; set; }

    public string? DTelephone { get; set; }

    public string? DTelecopie { get; set; }

    public string? DEmailSoc { get; set; }

    public string? DSite { get; set; }

    public short? DAppelTiers { get; set; }

    public short? DAppelSection { get; set; }

    public short? DProtPiece { get; set; }

    public short? DNumCont { get; set; }

    public DateTime? DDateClot { get; set; }

    public short? DCompteGtotal { get; set; }

    public short? DRapproRecherche { get; set; }

    public decimal? DRapproEcart { get; set; }

    public string? CgNumRappro { get; set; }

    public short? DRapproContrepartie { get; set; }

    public short? DComSens { get; set; }

    public short? DComType { get; set; }

    public short? DComMoyen { get; set; }

    public short? DComSoft { get; set; }

    public string? DComCodeExpert { get; set; }

    public DateTime? DComDateSynchro { get; set; }

    public Guid? DComGuid { get; set; }

    public short? DRapproTypeEcart { get; set; }

    public short? DRapproReport { get; set; }

    public string? JoNumRapproEscCl { get; set; }

    public int? PiNoRapproEscCl { get; set; }

    public string? JoNumRapproEscFr { get; set; }

    public int? PiNoRapproEscFr { get; set; }

    public short? DGestionIfrs { get; set; }

    public short? DSaisieIfrs { get; set; }

    public short? NAnalytiqueIfrs { get; set; }

    public string? JaNumAn { get; set; }

    public string? JoNumAnifrs { get; set; }

    public string? JaNumAnifrs { get; set; }

    public decimal? DRappelSoldeMin { get; set; }

    public short? DImportVentil { get; set; }

    public decimal? DPenalTaux { get; set; }

    public short? DPenalImputation { get; set; }

    public string? JoNumPenal { get; set; }

    public int? PiNoPenal { get; set; }

    public string? JoNumImpayes { get; set; }

    public int? PiNoImpayes { get; set; }

    public short? DImpressFactRef { get; set; }

    public decimal? DSeuilTva { get; set; }

    public short? DNotSaisieSommeil { get; set; }

    public DateTime? DArchivePeriod { get; set; }

    public int? DEcnoCloture01 { get; set; }

    public int? DEcnoCloture02 { get; set; }

    public int? DEcnoCloture03 { get; set; }

    public int? DEcnoCloture04 { get; set; }

    public int? DEcnoCloture05 { get; set; }

    public DateTime? DCloturePeriod { get; set; }

    public short? DMaterialPiece { get; set; }

    public short? DBudgetAn { get; set; }

    public decimal? DCapital { get; set; }

    public string? DFormeJuridique { get; set; }

    public int CbMarq { get; set; }

    public decimal? DForfaitImpayes { get; set; }

    public string? DCodeOctave { get; set; }

    public short? DFinexKap { get; set; }

    public string? JoNumFinexKap { get; set; }

    public int? PiNoFinexKap { get; set; }

    public string? DFacebook { get; set; }

    public string? DLinkedIn { get; set; }

    public short? DUpdateDevise { get; set; }

    public short? DUpdateDeviseSaisie { get; set; }
}
