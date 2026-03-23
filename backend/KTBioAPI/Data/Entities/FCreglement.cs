using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCreglement
{
    public int? RgNo { get; set; }

    public string? CtNumPayeur { get; set; }

    public byte[]? CbCtNumPayeur { get; set; }

    public DateTime? RgDate { get; set; }

    public string? RgReference { get; set; }

    public string? RgLibelle { get; set; }

    public decimal? RgMontant { get; set; }

    public decimal? RgMontantDev { get; set; }

    public short? NReglement { get; set; }

    public short? RgImpute { get; set; }

    public short? RgCompta { get; set; }

    public int? EcNo { get; set; }

    public int? CbEcNo { get; set; }

    public short? RgType { get; set; }

    public decimal? RgCours { get; set; }

    public short? NDevise { get; set; }

    public string JoNum { get; set; } = null!;

    public string? CgNumCont { get; set; }

    public byte[]? CbCgNumCont { get; set; }

    public DateTime? RgImpaye { get; set; }

    public string? CgNum { get; set; }

    public byte[]? CbCgNum { get; set; }

    public short? RgTypeReg { get; set; }

    public string? RgHeure { get; set; }

    public string? RgPiece { get; set; }

    public byte[]? CbRgPiece { get; set; }

    public int? CaNo { get; set; }

    public int? CoNoCaissier { get; set; }

    public int? CbCoNoCaissier { get; set; }

    public short? RgBanque { get; set; }

    public short? RgTransfere { get; set; }

    public short RgCloture { get; set; }

    public short? RgTicket { get; set; }

    public short? RgSouche { get; set; }

    public string? CtNumPayeurOrig { get; set; }

    public byte[]? CbCtNumPayeurOrig { get; set; }

    public DateTime? RgDateEchCont { get; set; }

    public string? CgNumEcart { get; set; }

    public byte[]? CbCgNumEcart { get; set; }

    public string? JoNumEcart { get; set; }

    public decimal? RgMontantEcart { get; set; }

    public int? RgNoBonAchat { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? RgValide { get; set; }

    public decimal? RgAnterieur { get; set; }

    public byte[]? CbHash { get; set; }

    public short? CbHashVersion { get; set; }

    public DateTime? CbHashDate { get; set; }

    public int? CbHashOrder { get; set; }

    public int? CbCaNo { get; set; }

    public virtual FCaisse? CbCaNoNavigation { get; set; }

    public virtual FCollaborateur? CbCoNoCaissierNavigation { get; set; }

    public virtual FCompteg? CgNumContNavigation { get; set; }

    public virtual FCompteg? CgNumEcartNavigation { get; set; }

    public virtual FCompteg? CgNumNavigation { get; set; }

    public virtual FComptet? CtNumPayeurNavigation { get; set; }

    public virtual FComptet? CtNumPayeurOrigNavigation { get; set; }

    public virtual ICollection<FReglech> FRegleches { get; set; } = new List<FReglech>();
}
