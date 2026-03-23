using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FContactr
{
    public string DrNum { get; set; } = null!;

    public byte[]? CbDrNum { get; set; }

    public string? CrNom { get; set; }

    public byte[]? CbCrNom { get; set; }

    public string? CrPrenom { get; set; }

    public byte[]? CbCrPrenom { get; set; }

    public short? NService { get; set; }

    public string? CrFonction { get; set; }

    public string? CrTelephone { get; set; }

    public string? CrTelPortable { get; set; }

    public string? CrTelecopie { get; set; }

    public string? CrEmail { get; set; }

    public short? CrCivilite { get; set; }

    public short? NContact { get; set; }

    public string? CrAdresse { get; set; }

    public string? CrComplement { get; set; }

    public string? CrCodePostal { get; set; }

    public string? CrVille { get; set; }

    public int? CrNo { get; set; }

    public string? CrCodeRegion { get; set; }

    public string? CrPays { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CrFacebook { get; set; }

    public string? CrLinkedIn { get; set; }

    public string? CrSkype { get; set; }

    public virtual FDrecouvrement DrNumNavigation { get; set; } = null!;
}
