using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptet
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? CtIntitule { get; set; }

    public short? CtType { get; set; }

    public string? CgNumPrinc { get; set; }

    public string? CtQualite { get; set; }

    public string? CtClassement { get; set; }

    public byte[]? CbCtClassement { get; set; }

    public string? CtContact { get; set; }

    public string? CtAdresse { get; set; }

    public string? CtComplement { get; set; }

    public string? CtCodePostal { get; set; }

    public byte[]? CbCtCodePostal { get; set; }

    public string? CtVille { get; set; }

    public string? CtCodeRegion { get; set; }

    public string? CtPays { get; set; }

    public string? CtRaccourci { get; set; }

    public byte[]? CbCtRaccourci { get; set; }

    public short? BtNum { get; set; }

    public short? NDevise { get; set; }

    public string? CtApe { get; set; }

    public string? CtIdentifiant { get; set; }

    public string? CtSiret { get; set; }

    public string? CtStatistique01 { get; set; }

    public string? CtStatistique02 { get; set; }

    public string? CtStatistique03 { get; set; }

    public string? CtStatistique04 { get; set; }

    public string? CtStatistique05 { get; set; }

    public string? CtStatistique06 { get; set; }

    public string? CtStatistique07 { get; set; }

    public string? CtStatistique08 { get; set; }

    public string? CtStatistique09 { get; set; }

    public string? CtStatistique10 { get; set; }

    public string? CtCommentaire { get; set; }

    public decimal? CtEncours { get; set; }

    public decimal? CtAssurance { get; set; }

    public string? CtNumPayeur { get; set; }

    public byte[]? CbCtNumPayeur { get; set; }

    public short? NRisque { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public short? NCatTarif { get; set; }

    public decimal? CtTaux01 { get; set; }

    public decimal? CtTaux02 { get; set; }

    public decimal? CtTaux03 { get; set; }

    public decimal? CtTaux04 { get; set; }

    public short? NCatCompta { get; set; }

    public short? NPeriod { get; set; }

    public short? CtFacture { get; set; }

    public short? CtBlfact { get; set; }

    public short? CtLangue { get; set; }

    public short? NExpedition { get; set; }

    public short? NCondition { get; set; }

    public DateTime? CtDateCreate { get; set; }

    public short? CtSaut { get; set; }

    public short? CtLettrage { get; set; }

    public short? CtValidEch { get; set; }

    public short? CtSommeil { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public short? CtControlEnc { get; set; }

    public short? CtNotRappel { get; set; }

    public short? NAnalytique { get; set; }

    public short? CbNAnalytique { get; set; }

    public string? CaNum { get; set; }

    public byte[]? CbCaNum { get; set; }

    public string? CtTelephone { get; set; }

    public string? CtTelecopie { get; set; }

    public string? CtEmail { get; set; }

    public string? CtSite { get; set; }

    public string? CtCoface { get; set; }

    public short? CtSurveillance { get; set; }

    public DateTime? CtSvDateCreate { get; set; }

    public string? CtSvFormeJuri { get; set; }

    public string? CtSvEffectif { get; set; }

    public decimal? CtSvCa { get; set; }

    public decimal? CtSvResultat { get; set; }

    public short? CtSvIncident { get; set; }

    public DateTime? CtSvDateIncid { get; set; }

    public short? CtSvPrivil { get; set; }

    public string? CtSvRegul { get; set; }

    public string? CtSvCotation { get; set; }

    public DateTime? CtSvDateMaj { get; set; }

    public string? CtSvObjetMaj { get; set; }

    public DateTime? CtSvDateBilan { get; set; }

    public short? CtSvNbMoisBilan { get; set; }

    public short? NAnalytiqueIfrs { get; set; }

    public short? CbNAnalytiqueIfrs { get; set; }

    public string? CaNumIfrs { get; set; }

    public short? CtPrioriteLivr { get; set; }

    public short? CtLivrPartielle { get; set; }

    public int? MrNo { get; set; }

    public int? CbMrNo { get; set; }

    public short? CtNotPenal { get; set; }

    public int? EbNo { get; set; }

    public int? CbEbNo { get; set; }

    public string? CtNumCentrale { get; set; }

    public byte[]? CbCtNumCentrale { get; set; }

    public DateTime? CtDateFermeDebut { get; set; }

    public DateTime? CtDateFermeFin { get; set; }

    public short? CtFactureElec { get; set; }

    public short? CtTypeNif { get; set; }

    public string? CtRepresentInt { get; set; }

    public string? CtRepresentNif { get; set; }

    public short? CtEdiCodeType { get; set; }

    public string? CtEdiCode { get; set; }

    public string? CtEdiCodeSage { get; set; }

    public short? CtProfilSoc { get; set; }

    public short? CtStatutContrat { get; set; }

    public DateTime? CtDateMaj { get; set; }

    public short? CtEchangeRappro { get; set; }

    public short? CtEchangeCr { get; set; }

    public int? PiNoEchange { get; set; }

    public int? CbPiNoEchange { get; set; }

    public short? CtBonApayer { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? CtDelaiTransport { get; set; }

    public short? CtDelaiAppro { get; set; }

    public string? CtLangueIso2 { get; set; }

    public short? CtAnnulationCr { get; set; }

    public short? CtCessionCreance { get; set; }

    public string? CtFacebook { get; set; }

    public string? CtLinkedIn { get; set; }

    public short? CtExclureTrait { get; set; }

    public short? CtGdpr { get; set; }

    public short? CtProspect { get; set; }

    public byte[]? CbCgNumPrinc { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual FEbanque? CbEbNoNavigation { get; set; }

    public virtual FModeler? CbMrNoNavigation { get; set; }

    public virtual FPiece? CbPiNoEchangeNavigation { get; set; }

    public virtual FCompteg? CgNumPrincNavigation { get; set; }

    public virtual ICollection<FAboentete> FAboenteteCtNumCentraleNavigations { get; set; } = new List<FAboentete>();

    public virtual ICollection<FAboentete> FAboenteteCtNumPayeurNavigations { get; set; } = new List<FAboentete>();

    public virtual ICollection<FAbonnement> FAbonnements { get; set; } = new List<FAbonnement>();

    public virtual ICollection<FArtclient> FArtclients { get; set; } = new List<FArtclient>();

    public virtual ICollection<FArtfourniss> FArtfournisses { get; set; } = new List<FArtfourniss>();

    public virtual ICollection<FBanquet> FBanquets { get; set; } = new List<FBanquet>();

    public virtual ICollection<FCaisse> FCaisses { get; set; } = new List<FCaisse>();

    public virtual FComptea? FComptea { get; set; }

    public virtual FComptea? FCompteaNavigation { get; set; }

    public virtual ICollection<FComptetg> FComptetgs { get; set; } = new List<FComptetg>();

    public virtual ICollection<FComptetinfo> FComptetinfos { get; set; } = new List<FComptetinfo>();

    public virtual ICollection<FComptetmedium> FComptetmedia { get; set; } = new List<FComptetmedium>();

    public virtual ICollection<FComptetmodele> FComptetmodeles { get; set; } = new List<FComptetmodele>();

    public virtual ICollection<FComptetnote> FComptetnotes { get; set; } = new List<FComptetnote>();

    public virtual ICollection<FComptetrappel> FComptetrappels { get; set; } = new List<FComptetrappel>();

    public virtual ICollection<FContactt> FContactts { get; set; } = new List<FContactt>();

    public virtual ICollection<FCreglement> FCreglementCtNumPayeurNavigations { get; set; } = new List<FCreglement>();

    public virtual ICollection<FCreglement> FCreglementCtNumPayeurOrigNavigations { get; set; } = new List<FCreglement>();

    public virtual ICollection<FDocentete> FDocenteteCtNumCentraleNavigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocentete> FDocenteteCtNumPayeurNavigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDrecouvrement> FDrecouvrements { get; set; } = new List<FDrecouvrement>();

    public virtual ICollection<FEcriturec> FEcriturecs { get; set; } = new List<FEcriturec>();

    public virtual ICollection<FEfinancier> FEfinanciers { get; set; } = new List<FEfinancier>();

    public virtual ICollection<FFamclient> FFamclients { get; set; } = new List<FFamclient>();

    public virtual ICollection<FFamfourniss> FFamfournisses { get; set; } = new List<FFamfourniss>();

    public virtual ICollection<FLivraison> FLivraisons { get; set; } = new List<FLivraison>();

    public virtual ICollection<FReglementt> FReglementts { get; set; } = new List<FReglementt>();

    public virtual ICollection<FRegtaxe> FRegtaxes { get; set; } = new List<FRegtaxe>();

    public virtual ICollection<FTarif> FTarifs { get; set; } = new List<FTarif>();

    public virtual ICollection<FTicketarchive> FTicketarchives { get; set; } = new List<FTicketarchive>();
}
