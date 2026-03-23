using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCollaborateur
{
    public int? CoNo { get; set; }

    public string? CoNom { get; set; }

    public byte[]? CbCoNom { get; set; }

    public string? CoPrenom { get; set; }

    public byte[]? CbCoPrenom { get; set; }

    public string? CoFonction { get; set; }

    public byte[]? CbCoFonction { get; set; }

    public string? CoAdresse { get; set; }

    public string? CoComplement { get; set; }

    public string? CoCodePostal { get; set; }

    public string? CoVille { get; set; }

    public string? CoCodeRegion { get; set; }

    public string? CoPays { get; set; }

    public string? CoService { get; set; }

    public short? CoVendeur { get; set; }

    public short? CoCaissier { get; set; }

    //public DateTime? CoDateCreation { get; set; }

    public short? CoAcheteur { get; set; }

    public string? CoTelephone { get; set; }

    public string? CoTelecopie { get; set; }

    public string? CoEmail { get; set; }

    public short? CoReceptionnaire { get; set; }

    public int? ProtNo { get; set; }

    public int? CbProtNo { get; set; }

    public string? CoTelPortable { get; set; }

    public short? CoChargeRecouvr { get; set; }

    public string? CoMatricule { get; set; }

    public byte[]? CbCoMatricule { get; set; }

    public short? CoFinancier { get; set; }

    public short? CoTransmission { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CoFacebook { get; set; }

    public string? CoLinkedIn { get; set; }

    public string? CoSkype { get; set; }

    public virtual FProtectioncptum? CbProtNoNavigation { get; set; }

    public virtual ICollection<FAboentete> FAboentetes { get; set; } = new List<FAboentete>();

    public virtual ICollection<FAboligne> FAbolignes { get; set; } = new List<FAboligne>();

    public virtual ICollection<FBonapayerhisto> FBonapayerhistos { get; set; } = new List<FBonapayerhisto>();

    public virtual ICollection<FCaisse> FCaisseCbCoNoCaissierNavigations { get; set; } = new List<FCaisse>();

    public virtual ICollection<FCaisse> FCaisseCbCoNoNavigations { get; set; } = new List<FCaisse>();

    public virtual ICollection<FCaissecaissier> FCaissecaissiers { get; set; } = new List<FCaissecaissier>();

    public virtual ICollection<FClavier> FClaviers { get; set; } = new List<FClavier>();

    public virtual ICollection<FComptea> FCompteas { get; set; } = new List<FComptea>();

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual ICollection<FCreglement> FCreglements { get; set; } = new List<FCreglement>();

    public virtual ICollection<FDocentete> FDocenteteCbCoNoCaissierNavigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocentete> FDocenteteCbCoNoNavigations { get; set; } = new List<FDocentete>();

    public virtual ICollection<FDocligne> FDoclignes { get; set; } = new List<FDocligne>();

    public virtual ICollection<FDrecouvrement> FDrecouvrements { get; set; } = new List<FDrecouvrement>();

    public virtual ICollection<FLignearchive> FLignearchives { get; set; } = new List<FLignearchive>();

    public virtual ICollection<FRepcom> FRepcoms { get; set; } = new List<FRepcom>();

    public virtual ICollection<FTicketarchive> FTicketarchives { get; set; } = new List<FTicketarchive>();
}
