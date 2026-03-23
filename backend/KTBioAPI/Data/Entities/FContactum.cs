using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FContactum
{
    public short NAnalytique { get; set; }

    public string CaNum { get; set; } = null!;

    public byte[]? CbCaNum { get; set; }

    public string? CaNom { get; set; }

    public byte[]? CbCaNom { get; set; }

    public string? CaPrenom { get; set; }

    public byte[]? CbCaPrenom { get; set; }

    public short? NService { get; set; }

    public string? CaFonction { get; set; }

    public string? CaTelephone { get; set; }

    public string? CaTelPortable { get; set; }

    public string? CaTelecopie { get; set; }

    public string? CaEmail { get; set; }

    public short? CaCivilite { get; set; }

    public short? NContact { get; set; }

    public int? CaNo { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public string? CaFacebook { get; set; }

    public string? CaLinkedIn { get; set; }

    public string? CaSkype { get; set; }

    public virtual FComptea FComptea { get; set; } = null!;
}
