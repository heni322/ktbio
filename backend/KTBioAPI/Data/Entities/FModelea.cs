using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FModelea
{
    public int MaNo { get; set; }

    public string? MaIntitule { get; set; }

    public byte[]? CbMaIntitule { get; set; }

    public string JoNum { get; set; } = null!;

    public byte[]? CbJoNum { get; set; }

    public DateTime? MaDebut { get; set; }

    public DateTime? MaFin { get; set; }

    public short? MaTperiod { get; set; }

    public short? MaVperiod { get; set; }

    public int PiNo { get; set; }

    public string? MaPiece { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FEmodelea> FEmodeleas { get; set; } = new List<FEmodelea>();

    public virtual FPiece PiNoNavigation { get; set; } = null!;
}
