using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAboentete
{
    public int AbNo { get; set; }

    public string? AeRef { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public short? AePeriod { get; set; }

    public short? AeDevise { get; set; }

    public decimal? AeCours { get; set; }

    public int DeNo { get; set; }

    public int? LiNo { get; set; }

    public int? CbLiNo { get; set; }

    public string? CtNumPayeur { get; set; }

    public byte[]? CbCtNumPayeur { get; set; }

    public short? AeExpedit { get; set; }

    public short? AeNbFacture { get; set; }

    public short? AeBlfact { get; set; }

    public decimal? AeTxEscompte { get; set; }

    public string? CaNum { get; set; }

    public byte[]? CbCaNum { get; set; }

    public string? AeCoord01 { get; set; }

    public string? AeCoord02 { get; set; }

    public string? AeCoord03 { get; set; }

    public string? AeCoord04 { get; set; }

    public short? AeCondition { get; set; }

    public short? AeTarif { get; set; }

    public short? AeColisage { get; set; }

    public short? AeTypeColis { get; set; }

    public short? AeTransaction { get; set; }

    public short? AeLangue { get; set; }

    public short? AeRegime { get; set; }

    public short? NCatCompta { get; set; }

    public short? AeBaseCalcul { get; set; }

    public short? AeGenere { get; set; }

    public string? CgNum { get; set; }

    public byte[]? CbCgNum { get; set; }

    public string? CaNumIfrs { get; set; }

    public string? CtNumCentrale { get; set; }

    public byte[]? CbCtNumCentrale { get; set; }

    public string? AeContact { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? Divers1 { get; set; }

    public string? Divers2 { get; set; }

    public string? Divers3 { get; set; }

    public string? Divers4 { get; set; }

    public string? Divers5 { get; set; }

    public string? Divers6 { get; set; }

    public string? Commercial { get; set; }

    public string? Representant { get; set; }

    public string? GratuitOuEchange { get; set; }

    public string? NatureBl { get; set; }

    public string? Type { get; set; }

    public virtual FAbonnement AbNoNavigation { get; set; } = null!;

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FLivraison? CbLiNoNavigation { get; set; }

    public virtual FCompteg? CgNumNavigation { get; set; }

    public virtual FComptet? CtNumCentraleNavigation { get; set; }

    public virtual FComptet? CtNumPayeurNavigation { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;

    public virtual ICollection<FAboenteteinfo> FAboenteteinfos { get; set; } = new List<FAboenteteinfo>();

    public virtual ICollection<FAboligne> FAbolignes { get; set; } = new List<FAboligne>();

    public virtual ICollection<FAboreglement> FAboreglements { get; set; } = new List<FAboreglement>();
}
