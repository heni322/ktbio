using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpRessourceprod
{
    public string CcpCode { get; set; } = null!;

    public short? CcpTyperess { get; set; }

    public string? CcpLibTyperess { get; set; }

    public string? CcpType { get; set; }

    public string? CcpIntitule { get; set; }

    public string? CcpComplement { get; set; }

    public string? CcpCodeexterne { get; set; }

    public string? CcpCentral { get; set; }

    public DateTime? CcpProchaineVisite { get; set; }

    public string? CcpTemps { get; set; }

    public string? CcpSommeil { get; set; }

    public string? CcpDepot { get; set; }

    public string? CcpCommentaire { get; set; }

    public int? CcpCapacite { get; set; }

    public decimal? CcpCoutstd { get; set; }

    public string? CcpTypecapacite { get; set; }

    public string? CcpUnites { get; set; }
}
