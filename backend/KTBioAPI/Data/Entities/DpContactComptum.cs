using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpContactComptum
{
    public string? DcrNumdossier { get; set; }

    public string? DcrCodetiers { get; set; }

    public string? DcrNom { get; set; }

    public string? DcrPrenom { get; set; }

    public string? DcrContact { get; set; }

    public short? DcrCodeservice { get; set; }

    public string? DcrLibservice { get; set; }

    public string? DcrFonction { get; set; }

    public string? DcrTelephone { get; set; }

    public string? DcrTelportable { get; set; }

    public string? DcrTelecopie { get; set; }

    public string? DcrEmail { get; set; }

    public string? DcrCivilite { get; set; }

    public string? DcrTypecontact { get; set; }

    public string? DcrAdresse { get; set; }

    public string? DcrComplementadresse { get; set; }

    public string? DcrCodepostal { get; set; }

    public string? DcrVille { get; set; }

    public int? DcrNo { get; set; }

    public int DcrTypeinterlocuteur { get; set; }

    public string DcrLibtypeinterlocuteur { get; set; } = null!;
}
