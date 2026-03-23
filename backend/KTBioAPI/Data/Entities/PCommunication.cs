using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PCommunication
{
    public short? NCatTarif { get; set; }

    public short? NCatCompta { get; set; }

    public short? CoSoucheSite { get; set; }

    public int? DeNo { get; set; }

    public string? ArRefAttente { get; set; }

    public string? CoCdeLast { get; set; }

    public string? CoModele { get; set; }

    public short? CoAccuse { get; set; }

    public string? CoNomSite { get; set; }

    public string? CoMotPasseSite { get; set; }

    public short? NCondition { get; set; }

    public short? NExpedition { get; set; }

    public short? NPeriod { get; set; }

    public short? CoStatut { get; set; }

    public short? CoRegime { get; set; }

    public short? CoTransaction { get; set; }

    public short? CoNbFacture { get; set; }

    public short? CoColisage { get; set; }

    public short? CoTypeColis { get; set; }

    public int CbMarq { get; set; }
}
