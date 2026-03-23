using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FEbanquecond
{
    public int EbNo { get; set; }

    public short? EbCondDecouvertCdTypePlafond { get; set; }

    public short? EbCondDecouvertCdBaseCalcul { get; set; }

    public int? EbCondDecouvertTrNo { get; set; }

    public int? CbEbCondDecouvertTrNo { get; set; }

    public decimal? EbCondDecouvertCdValeurTaux { get; set; }

    public decimal? EbCondDecouvertCdPlafond01CdValeurPlafond { get; set; }

    public decimal? EbCondDecouvertCdPlafond01CdMarge { get; set; }

    public decimal? EbCondDecouvertCdPlafond02CdValeurPlafond { get; set; }

    public decimal? EbCondDecouvertCdPlafond02CdMarge { get; set; }

    public short? EbCondInteretCiType { get; set; }

    public int? EbCondInteretTrNo { get; set; }

    public int? CbEbCondInteretTrNo { get; set; }

    public decimal? EbCondInteretCiTaux { get; set; }

    public short? EbCondInteretCiAssiette { get; set; }

    public short? EbCondInteretCiLimite { get; set; }

    public short? EbCondInteretCiBaseCalcul { get; set; }

    public short? EbCondCommissionCcType { get; set; }

    public int? EbCondCommissionCcLimite { get; set; }

    public decimal? EbCondCommissionCcTaux { get; set; }

    public decimal? EbCondFraisCfCommission { get; set; }

    public decimal? EbCondFraisCfCompte { get; set; }

    public short? EbCondFraisCfPeriodicite { get; set; }

    public decimal? EbCondFraisCfSeuilExoneration { get; set; }

    public short? EbCondFraisCfTypeExoneration { get; set; }

    public decimal? EbCondFraisCfSeuilCrediteur { get; set; }

    public short? EbCondFraisCfModePerception { get; set; }

    public decimal? EbCondFraisCfMontantVariableHt { get; set; }

    public decimal? EbCondFraisCfMinimumPercu { get; set; }

    public decimal? EbCondFraisCfMaximumPercu { get; set; }

    public short? EbCondFraisCfAssujetTvacommission { get; set; }

    public short? EbCondFraisCfAssujetTvafrais { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FEbanque EbNoNavigation { get; set; } = null!;
}
