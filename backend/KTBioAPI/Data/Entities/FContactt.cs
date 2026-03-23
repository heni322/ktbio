using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FContactt
{
    public string CtNum { get; set; } = null!;

    public byte[]? CbCtNum { get; set; }

    public string? CtNom { get; set; }

    public byte[]? CbCtNom { get; set; }

    public string? CtPrenom { get; set; }

    public byte[]? CbCtPrenom { get; set; }

    public short? NService { get; set; }

    public string? CtFonction { get; set; }

    public string? CtTelephone { get; set; }

    public string? CtTelPortable { get; set; }

    public string? CtTelecopie { get; set; }

    public string? CtEmail { get; set; }

    public short? CtCivilite { get; set; }

    public short? NContact { get; set; }

    public int? CtNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CtFacebook { get; set; }

    public string? CtLinkedIn { get; set; }

    public string? CtSkype { get; set; }

    public virtual FComptet CtNumNavigation { get; set; } = null!;

    public virtual ICollection<FDrecouvrement> FDrecouvrements { get; set; } = new List<FDrecouvrement>();
}
