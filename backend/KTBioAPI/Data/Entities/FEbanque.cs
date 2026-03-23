using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEbanque
{
    public int BqNo { get; set; }

    public string? EbBanque { get; set; }

    public byte[]? CbEbBanque { get; set; }

    public string? EbGuichet { get; set; }

    public byte[]? CbEbGuichet { get; set; }

    public string? EbCompte { get; set; }

    public byte[]? CbEbCompte { get; set; }

    public string? EbCle { get; set; }

    public string? EbCommentaire { get; set; }

    public string? JoNum { get; set; }

    public byte[]? CbJoNum { get; set; }

    public short? EbStruct { get; set; }

    public short? NDevise { get; set; }

    public int? EbNo { get; set; }

    public string? EbAbrege { get; set; }

    public byte[]? CbEbAbrege { get; set; }

    public string? EbEmetteur01 { get; set; }

    public string? EbEmetteur02 { get; set; }

    public string? EbEmetteur03 { get; set; }

    public string? EbAdresse { get; set; }

    public string? EbComplement { get; set; }

    public string? EbCodePostal { get; set; }

    public string? EbVille { get; set; }

    public string? EbPays { get; set; }

    public string? EbBic { get; set; }

    public string? EbIban { get; set; }

    public short? EbCalculIban { get; set; }

    public string? EbNomAgence { get; set; }

    public string? JoNumEscompte { get; set; }

    public byte[]? CbJoNumEscompte { get; set; }

    public string? JoNumEncaiss { get; set; }

    public byte[]? CbJoNumEncaiss { get; set; }

    public short? EbIntraGroupe { get; set; }

    public string? EbRaisonSocBenef { get; set; }

    public string? EbAdresseBenef { get; set; }

    public string? EbComplementBenef { get; set; }

    public string? EbCodePostalBenef { get; set; }

    public string? EbVilleBenef { get; set; }

    public string? EbPaysBenef { get; set; }

    public string? EbSiretBenef { get; set; }

    public string? EbCodeRegionBenef { get; set; }

    public string? EbCodeRegion { get; set; }

    public string? EbPaysAgence { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? EbFileExtrait { get; set; }

    public short? EbTresoPublic { get; set; }

    public short? EbBanqueDeFrance { get; set; }

    public string? EbTpserviceDepot { get; set; }

    public short? EbTptypeService { get; set; }

    public string? EbTpcodique { get; set; }

    public string? EbTpiban { get; set; }

    public string? EbTpbic { get; set; }

    public short? EbTpremise51 { get; set; }

    public string? EbTpidentifiant51 { get; set; }

    public string? EbBdfcodeRemettant { get; set; }

    public virtual FBanque BqNoNavigation { get; set; } = null!;

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual FEbanquecond? FEbanquecond { get; set; }

    public virtual ICollection<FExtrait> FExtraits { get; set; } = new List<FExtrait>();
}
