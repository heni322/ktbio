using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FProjetfabrication
{
    public string PfNum { get; set; } = null!;

    public byte[]? CbPfNum { get; set; }

    public short? PfStatut { get; set; }

    public string? PfIntitule { get; set; }

    public byte[]? CbPfIntitule { get; set; }

    public int? DeNo { get; set; }

    public int? CbDeNo { get; set; }

    public string? CaNum { get; set; }

    public byte[]? CbCaNum { get; set; }

    public DateTime? PfDateDebut { get; set; }

    public DateTime? PfDateFin { get; set; }

    public string? DoPiece { get; set; }

    public short? PfType { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public virtual FDepot? CbDeNoNavigation { get; set; }

    public virtual ICollection<FProjethisto> FProjethistos { get; set; } = new List<FProjethisto>();

    public virtual ICollection<FProjetligne> FProjetlignes { get; set; } = new List<FProjetligne>();

    public virtual ICollection<FProjetplanning> FProjetplannings { get; set; } = new List<FProjetplanning>();
}
