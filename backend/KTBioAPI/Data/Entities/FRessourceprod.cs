using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FRessourceprod
{
    public string RpCode { get; set; } = null!;

    public byte[]? CbRpCode { get; set; }

    public short? RpType { get; set; }

    public string? RpIntitule { get; set; }

    public byte[]? CbRpIntitule { get; set; }

    public string? RpComplement { get; set; }

    public string? RpCentral { get; set; }

    public byte[]? CbRpCentral { get; set; }

    public DateTime? RpVisite { get; set; }

    public decimal? RpCoutStd { get; set; }

    public string? RpTemps { get; set; }

    public short? RpSommeil { get; set; }

    public int? RpCapacite { get; set; }

    public string? RpCommentaire { get; set; }

    public DateTime? RpDateCreation { get; set; }

    public short? RpTypeRess { get; set; }

    public string? RpCodeExterne { get; set; }

    public int DeNo { get; set; }

    public string? RpAdresse { get; set; }

    public string? RpComplementAdresse { get; set; }

    public string? RpCodePostal { get; set; }

    public string? RpVille { get; set; }

    public string? RpRegion { get; set; }

    public string? RpPays { get; set; }

    public string? RpTelephone { get; set; }

    public string? RpPortable { get; set; }

    public string? RpEmail { get; set; }

    public string? ArRefDefaut { get; set; }

    public short? RpUnite { get; set; }

    public short? RpContinue { get; set; }

    public int? CalNo { get; set; }

    public string? RpHoraire0101RpPlageDebut { get; set; }

    public string? RpHoraire0101RpPlageFin { get; set; }

    public string? RpHoraire0102RpPlageDebut { get; set; }

    public string? RpHoraire0102RpPlageFin { get; set; }

    public string? RpHoraire0201RpPlageDebut { get; set; }

    public string? RpHoraire0201RpPlageFin { get; set; }

    public string? RpHoraire0202RpPlageDebut { get; set; }

    public string? RpHoraire0202RpPlageFin { get; set; }

    public string? RpHoraire0301RpPlageDebut { get; set; }

    public string? RpHoraire0301RpPlageFin { get; set; }

    public string? RpHoraire0302RpPlageDebut { get; set; }

    public string? RpHoraire0302RpPlageFin { get; set; }

    public string? RpHoraire0401RpPlageDebut { get; set; }

    public string? RpHoraire0401RpPlageFin { get; set; }

    public string? RpHoraire0402RpPlageDebut { get; set; }

    public string? RpHoraire0402RpPlageFin { get; set; }

    public string? RpHoraire0501RpPlageDebut { get; set; }

    public string? RpHoraire0501RpPlageFin { get; set; }

    public string? RpHoraire0502RpPlageDebut { get; set; }

    public string? RpHoraire0502RpPlageFin { get; set; }

    public string? RpHoraire0601RpPlageDebut { get; set; }

    public string? RpHoraire0601RpPlageFin { get; set; }

    public string? RpHoraire0602RpPlageDebut { get; set; }

    public string? RpHoraire0602RpPlageFin { get; set; }

    public string? RpHoraire0701RpPlageDebut { get; set; }

    public string? RpHoraire0701RpPlageFin { get; set; }

    public string? RpHoraire0702RpPlageDebut { get; set; }

    public string? RpHoraire0702RpPlageFin { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? RpFacebook { get; set; }

    public string? RpLinkedIn { get; set; }

    public string? RpSkype { get; set; }

    public virtual FArticle? ArRefDefautNavigation { get; set; }

    public virtual FCalendrier? CalNoNavigation { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;

    public virtual ICollection<FAboligne> FAbolignes { get; set; } = new List<FAboligne>();

    public virtual ICollection<FArtcompo> FArtcompos { get; set; } = new List<FArtcompo>();

    public virtual ICollection<FArticleressource> FArticleressources { get; set; } = new List<FArticleressource>();

    public virtual ICollection<FArticle> FArticles { get; set; } = new List<FArticle>();

    public virtual ICollection<FDocligne> FDoclignes { get; set; } = new List<FDocligne>();

    public virtual ICollection<FProjetplanning> FProjetplannings { get; set; } = new List<FProjetplanning>();

    public virtual ICollection<FResscentre> FResscentreRpCodeCentreNavigations { get; set; } = new List<FResscentre>();

    public virtual ICollection<FResscentre> FResscentreRpCodeRessourceNavigations { get; set; } = new List<FResscentre>();
}
