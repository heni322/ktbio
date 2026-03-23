using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAgendum
{
    public short? AdChamp { get; set; }

    public string? AdEvenem { get; set; }

    public short? AgDomaine { get; set; }

    public string? AgInteres { get; set; }

    public byte[]? CbAgInteres { get; set; }

    public DateTime? AgDebut { get; set; }

    public DateTime? AgFin { get; set; }

    public short? AgVeille { get; set; }

    public string? AgComment { get; set; }

    public short? AgType { get; set; }

    public short? AgConfirme { get; set; }

    public string? AgHeureDebut { get; set; }

    public string? AgHeureFin { get; set; }

    public short? AgIgnorer { get; set; }

    public short? AgContinue { get; set; }

    public int? DlNo { get; set; }

    public int? CbDlNo { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public int? PpNo { get; set; }

    public int? CbPpNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public int? AdNo { get; set; }

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual FDocligne? CbDlNoNavigation { get; set; }

    public virtual FProjetplanning? CbPpNoNavigation { get; set; }
}
