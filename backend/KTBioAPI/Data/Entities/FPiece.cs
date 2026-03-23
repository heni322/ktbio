using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FPiece
{
    public int PiNo { get; set; }

    public string? PiIntitule { get; set; }

    public byte[]? CbPiIntitule { get; set; }

    public string? PiRaccourci { get; set; }

    public byte[]? CbPiRaccourci { get; set; }

    public short? JoType { get; set; }

    public string? JoNum { get; set; }

    public byte[]? CbJoNum { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual ICollection<FEfinancierec> FEfinancierecs { get; set; } = new List<FEfinancierec>();

    public virtual ICollection<FModelea> FModeleas { get; set; } = new List<FModelea>();

    public virtual ICollection<FPieceg> FPiecegs { get; set; } = new List<FPieceg>();
}
