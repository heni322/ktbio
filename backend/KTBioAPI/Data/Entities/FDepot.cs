using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDepot
{
    public int? DeNo { get; set; }

    public string DeIntitule { get; set; } = null!;

    public byte[]? CbDeIntitule { get; set; }

    public string? DeAdresse { get; set; }

    public string? DeComplement { get; set; }

    public string? DeCodePostal { get; set; }

    public string? DeVille { get; set; }

    public string? DeContact { get; set; }

    public short? DePrincipal { get; set; }

    public short? DeCatCompta { get; set; }

    public string? DeRegion { get; set; }

    public string? DePays { get; set; }

    public string? DeEmail { get; set; }

    public string? DeCode { get; set; }

    public byte[]? CbDeCode { get; set; }

    public string? DeTelephone { get; set; }

    public string? DeTelecopie { get; set; }

    public int? DeReplication { get; set; }

    public int? DpNoDefaut { get; set; }

    public int? CbDpNoDefaut { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? DeExclure { get; set; }

    public short? DeSouche01 { get; set; }

    public short? DeSouche02 { get; set; }

    public short? DeSouche03 { get; set; }

    public virtual FDepotempl? CbDpNoDefautNavigation { get; set; }

    public virtual ICollection<FAboentete> FAboentetes { get; set; } = new List<FAboentete>();

    public virtual ICollection<FAboligne> FAbolignes { get; set; } = new List<FAboligne>();

    public virtual ICollection<FAgendum> FAgenda { get; set; } = new List<FAgendum>();

    public virtual ICollection<FArtstock> FArtstocks { get; set; } = new List<FArtstock>();

    public virtual ICollection<FCaisse> FCaisses { get; set; } = new List<FCaisse>();

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual ICollection<FDepotcontact> FDepotcontacts { get; set; } = new List<FDepotcontact>();

    public virtual ICollection<FDepotempl> FDepotempls { get; set; } = new List<FDepotempl>();

    public virtual ICollection<FDocentete> FDocentetes { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocligne> FDoclignes { get; set; } = new List<FDocligne>();

    public virtual ICollection<FGamstock> FGamstocks { get; set; } = new List<FGamstock>();

    public virtual ICollection<FLotfifo> FLotfifos { get; set; } = new List<FLotfifo>();

    public virtual ICollection<FLotserie> FLotseries { get; set; } = new List<FLotserie>();

    public virtual ICollection<FNomenclat> FNomenclats { get; set; } = new List<FNomenclat>();

    public virtual ICollection<FPrevision> FPrevisions { get; set; } = new List<FPrevision>();

    public virtual ICollection<FProjetfabrication> FProjetfabrications { get; set; } = new List<FProjetfabrication>();

    public virtual ICollection<FProjetplanning> FProjetplannings { get; set; } = new List<FProjetplanning>();

    public virtual ICollection<FRessourceprod> FRessourceprods { get; set; } = new List<FRessourceprod>();
}
