using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FContactb
{
    public int BqNo { get; set; }

    public string? CbNom { get; set; }

    public byte[]? CbCbNom { get; set; }

    public string? CbPrenom { get; set; }

    public byte[]? CbCbPrenom { get; set; }

    public short? NService { get; set; }

    public string? CbFonction { get; set; }

    public string? CbTelephone { get; set; }

    public string? CbTelPortable { get; set; }

    public string? CbTelecopie { get; set; }

    public string? CbEmail { get; set; }

    public short? CbCivilite { get; set; }

    public short? NContact { get; set; }

    public int? CbNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CbFacebook { get; set; }

    public string? CbLinkedIn { get; set; }

    public string? CbSkype { get; set; }

    public virtual FBanque BqNoNavigation { get; set; } = null!;
}
