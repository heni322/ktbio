using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FBanquet
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public short BtNum { get; set; }

    public string? BtIntitule { get; set; }

    public byte[]? CbBtIntitule { get; set; }

    public string? BtBanque { get; set; }

    public string? BtGuichet { get; set; }

    public string? BtCompte { get; set; }

    public string? BtCle { get; set; }

    public string? BtCommentaire { get; set; }

    public short? BtStruct { get; set; }

    public short? NDevise { get; set; }

    public string? BtAdresse { get; set; }

    public string? BtComplement { get; set; }

    public string? BtCodePostal { get; set; }

    public string? BtVille { get; set; }

    public string? BtPays { get; set; }

    public string? BtBic { get; set; }

    public string? BtIban { get; set; }

    public short? BtCalculIban { get; set; }

    public string? BtNomAgence { get; set; }

    public string? BtCodeRegion { get; set; }

    public string? BtPaysAgence { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public int? MdNo { get; set; }

    public int? CbMdNo { get; set; }

    public virtual FMandat? CbMdNoNavigation { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual ICollection<FMandat> FMandats { get; set; } = new List<FMandat>();
}
