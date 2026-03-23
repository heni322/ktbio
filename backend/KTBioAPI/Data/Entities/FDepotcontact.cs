using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDepotcontact
{
    public int DeNo { get; set; }

    public string? DcNom { get; set; }

    public byte[]? CbDcNom { get; set; }

    public string? DcPrenom { get; set; }

    public byte[]? CbDcPrenom { get; set; }

    public short? NService { get; set; }

    public string? DcFonction { get; set; }

    public string? DcTelephone { get; set; }

    public string? DcTelPortable { get; set; }

    public string? DcTelecopie { get; set; }

    public string? DcEmail { get; set; }

    public short? DcCivilite { get; set; }

    public short? NContact { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public int? DcNo { get; set; }

    public string? DcFacebook { get; set; }

    public string? DcLinkedIn { get; set; }

    public string? DcSkype { get; set; }

    public virtual FDepot DeNoNavigation { get; set; } = null!;
}
