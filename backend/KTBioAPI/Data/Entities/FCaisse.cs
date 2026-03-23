using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCaisse
{
    public int? CaNo { get; set; }

    public string? CaIntitule { get; set; }

    public byte[]? CbCaIntitule { get; set; }

    public int DeNo { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public int? CoNoCaissier { get; set; }

    public int? CbCoNoCaissier { get; set; }

    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string JoNum { get; set; } = null!;

    public short? CaIdentifCaissier { get; set; }

    public DateTime? CaDateCreation { get; set; }

    public short? NComptoir { get; set; }

    public short? NClavier { get; set; }

    public short? CaLignesAfficheur { get; set; }

    public short? CaColonnesAfficheur { get; set; }

    public short? CaImpTicket { get; set; }

    public short? CaSaisieVendeur { get; set; }

    public short? CaSouche { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCollaborateur? CbCoNoCaissierNavigation { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual FDepot DeNoNavigation { get; set; } = null!;

    public virtual ICollection<FAfficheurcaisse> FAfficheurcaisses { get; set; } = new List<FAfficheurcaisse>();

    public virtual ICollection<FCaissecaissier> FCaissecaissiers { get; set; } = new List<FCaissecaissier>();

    public virtual ICollection<FCaissetotal> FCaissetotals { get; set; } = new List<FCaissetotal>();

    public virtual ICollection<FCreglement> FCreglements { get; set; } = new List<FCreglement>();

    public virtual ICollection<FDocentete> FDocentetes { get; set; } = new List<FDocentete>();

    public virtual ICollection<FReglearchive> FReglearchives { get; set; } = new List<FReglearchive>();

    public virtual ICollection<FTicketarchive> FTicketarchives { get; set; } = new List<FTicketarchive>();
}
