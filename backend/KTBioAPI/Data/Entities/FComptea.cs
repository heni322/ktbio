using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FComptea
{
    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public string? CaIntitule { get; set; }

    public short? CaType { get; set; }

    public string? CaClassement { get; set; }

    public byte[]? CbCaClassement { get; set; }

    public string? CaRaccourci { get; set; }

    public byte[]? CbCaRaccourci { get; set; }

    public short? CaReport { get; set; }

    public short? NAnalyse { get; set; }

    public short? CaSaut { get; set; }

    public short? CaSommeil { get; set; }

    public DateTime? CaDateCreate { get; set; }

    public short? CaDomaine { get; set; }

    public decimal? CaAchat { get; set; }

    public decimal? CaVente { get; set; }

    public int? CoNo { get; set; }

    public int? CbCoNo { get; set; }

    public short? CaStatut { get; set; }

    public DateTime? CaDateCreationAffaire { get; set; }

    public DateTime? CaDateAcceptAffaire { get; set; }

    public DateTime? CaDateDebutAffaire { get; set; }

    public DateTime? CaDateFinAffaire { get; set; }

    public short? CaModeFacturation { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCollaborateur? CbCoNoNavigation { get; set; }

    public virtual FCompteabudget? FCompteabudget { get; set; }

    public virtual ICollection<FCompteamedium> FCompteamedia { get; set; } = new List<FCompteamedium>();

    public virtual ICollection<FComptega> FComptegas { get; set; } = new List<FComptega>();

    public virtual ICollection<FComptegbudgetum> FComptegbudgeta { get; set; } = new List<FComptegbudgetum>();

    public virtual ICollection<FComptet> FComptetFCompteaNavigations { get; set; } = new List<FComptet>();

    public virtual ICollection<FComptet> FComptetFCompteas { get; set; } = new List<FComptet>();

    public virtual ICollection<FContactum> FContacta { get; set; } = new List<FContactum>();

    public virtual ICollection<FEcriturea> FEcritureas { get; set; } = new List<FEcriturea>();

    public virtual ICollection<FEcriturer> FEcriturers { get; set; } = new List<FEcriturer>();

    public virtual ICollection<FEfinanciera> FEfinancieras { get; set; } = new List<FEfinanciera>();
}
