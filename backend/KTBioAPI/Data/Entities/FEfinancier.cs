using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEfinancier
{
    public int FiNo { get; set; }

    public int EfNo { get; set; }

    public int? EfNoLink { get; set; }

    public DateTime? EfJour { get; set; }

    public DateTime? EfDate { get; set; }

    public string? EfPiece { get; set; }

    public string? EfRefPiece { get; set; }

    public string? EfTresoPiece { get; set; }

    public string? CgNum { get; set; }

    public string? CgNumCont { get; set; }

    public string? CtNum { get; set; }

    public string? CtNumCont { get; set; }

    public string? TaCode { get; set; }

    public string? EfIntitule { get; set; }

    public short? NReglement { get; set; }

    public DateTime? EfEcheance { get; set; }

    public short? NDevise { get; set; }

    public decimal? EfParite { get; set; }

    public decimal? EfDevise { get; set; }

    public decimal? EfQuantite { get; set; }

    public short? EfSens { get; set; }

    public decimal? EfMontant { get; set; }

    public string? EfAfb { get; set; }

    public short? EfNorme { get; set; }

    public short? TaProvenance { get; set; }

    public string? EfReference { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FCompteg? CgNumNavigation { get; set; }

    public virtual FComptet? CtNumNavigation { get; set; }

    public virtual ICollection<FEfinanciera> FEfinancieras { get; set; } = new List<FEfinanciera>();

    public virtual ICollection<FEfinancierec> FEfinancierecs { get; set; } = new List<FEfinancierec>();

    public virtual FFinancier FiNoNavigation { get; set; } = null!;

    public virtual FTaxe? TaCodeNavigation { get; set; }
}
