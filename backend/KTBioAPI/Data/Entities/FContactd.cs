using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FContactd
{
    public string? CdNom { get; set; }

    public byte[]? CbCdNom { get; set; }

    public string? CdPrenom { get; set; }

    public byte[]? CbCdPrenom { get; set; }

    public short? NService { get; set; }

    public string? CdFonction { get; set; }

    public string? CdTelephone { get; set; }

    public string? CdTelPortable { get; set; }

    public string? CdTelecopie { get; set; }

    public string? CdEmail { get; set; }

    public short? CdCivilite { get; set; }

    public short? NContact { get; set; }

    public string? CdAdresse { get; set; }

    public string? CdComplement { get; set; }

    public string? CdCodePostal { get; set; }

    public string? CdVille { get; set; }

    public int? CdNo { get; set; }

    public string? CdCodeRegion { get; set; }

    public string? CdPays { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CdFacebook { get; set; }

    public string? CdLinkedIn { get; set; }

    public string? CdSkype { get; set; }
}
