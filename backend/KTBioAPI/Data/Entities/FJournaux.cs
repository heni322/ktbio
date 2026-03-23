using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FJournaux
{
    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public string? JoIntitule { get; set; }

    public byte[]? CbJoIntitule { get; set; }

    public string? CgNum { get; set; }

    public byte[]? CbCgNum { get; set; }

    public short? JoType { get; set; }

    public short? JoNumPiece { get; set; }

    public short? JoContrepartie { get; set; }

    public short? JoSaisAnal { get; set; }

    public short? JoNotCalcTot { get; set; }

    public short? JoRappro { get; set; }

    public short? JoSommeil { get; set; }

    public short? JoIfrs { get; set; }

    public short? JoReglement { get; set; }

    public short? JoSuiviTreso { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? JoLettrageSaisie { get; set; }

    public virtual FCompteg? CgNumNavigation { get; set; }
}
