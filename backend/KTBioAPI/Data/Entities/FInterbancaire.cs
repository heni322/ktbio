using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FInterbancaire
{
    public string IbAfb { get; set; } = null!;

    public byte[]? CbIbAfb { get; set; }

    public string? IbNature { get; set; }

    public string? IbIntitule { get; set; }

    public short IbSens { get; set; }

    public short? NReglement01 { get; set; }

    public short? NReglement02 { get; set; }

    public short? NReglement03 { get; set; }

    public short? NReglement04 { get; set; }

    public short? NReglement05 { get; set; }

    public short? NReglement06 { get; set; }

    public short? NReglement07 { get; set; }

    public short? NReglement08 { get; set; }

    public short? NReglement09 { get; set; }

    public short? NReglement10 { get; set; }

    public short? NReglement11 { get; set; }

    public short? NReglement12 { get; set; }

    public short? NReglement13 { get; set; }

    public short? NReglement14 { get; set; }

    public short? NReglement15 { get; set; }

    public short? NReglement16 { get; set; }

    public short? NReglement17 { get; set; }

    public short? NReglement18 { get; set; }

    public short? NReglement19 { get; set; }

    public short? NReglement20 { get; set; }

    public short? NReglement21 { get; set; }

    public short? NReglement22 { get; set; }

    public short? NReglement23 { get; set; }

    public short? NReglement24 { get; set; }

    public short? NReglement25 { get; set; }

    public short? NReglement26 { get; set; }

    public short? NReglement27 { get; set; }

    public short? NReglement28 { get; set; }

    public short? NReglement29 { get; set; }

    public short? NReglement30 { get; set; }

    public short? IbNbJoursValeur { get; set; }

    public short? IbJourType { get; set; }

    public short? IbEchReport { get; set; }

    public short? IbExoCommission { get; set; }

    public short? IbNbJoursEcheance { get; set; }

    public short? IbJourTypeEcheance { get; set; }

    public int? IbNatureTreso { get; set; }

    public short? NReglementPrinc { get; set; }

    public short? IbRapproMode { get; set; }

    public string? IbRapproAfb { get; set; }

    public byte[]? CbIbRapproAfb { get; set; }

    public short? IbRapproPuissanceEc { get; set; }

    public short? IbRapproPuissanceEx { get; set; }

    public short? IbRapproDelaiEc { get; set; }

    public short? IbRapproDelaiEcNbJours { get; set; }

    public short? IbRapproDelaiEx { get; set; }

    public short? IbRapproDelaiExNbJours { get; set; }

    public short? IbRapproDelaiEcEx { get; set; }

    public short? IbRapproDelaiEcExNbJours { get; set; }

    public short? IbRapproComp { get; set; }

    public short? IbRapproCompNbCar { get; set; }

    public short? IbRapproCompEcZone { get; set; }

    public short? IbRapproCompEcPos { get; set; }

    public short? IbRapproCompExZone { get; set; }

    public short? IbRapproCompExPos { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FBanqueafb> FBanqueafbs { get; set; } = new List<FBanqueafb>();
}
