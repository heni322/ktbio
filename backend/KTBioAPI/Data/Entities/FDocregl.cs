using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FDocregl
{
    public int? DrNo { get; set; }

    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public string? DoPiece { get; set; }

    public short? DrTypeRegl { get; set; }

    public DateTime? DrDate { get; set; }

    public string? DrLibelle { get; set; }

    public decimal? DrPourcent { get; set; }

    public decimal? DrMontant { get; set; }

    public decimal? DrMontantDev { get; set; }

    public short? DrEquil { get; set; }

    public int? EcNo { get; set; }

    public int? CbEcNo { get; set; }

    public short? DrRegle { get; set; }

    public short? NReglement { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public int? CaNo { get; set; }

    public int? CbCaNo { get; set; }

    public short? DoDocType { get; set; }

    public byte[]? CbHash { get; set; }

    public short? CbHashVersion { get; set; }

    public DateTime? CbHashDate { get; set; }

    public int? CbHashOrder { get; set; }

    public byte[]? CbDoPiece { get; set; }

    public virtual ICollection<FReglech> FRegleches { get; set; } = new List<FReglech>();
}
