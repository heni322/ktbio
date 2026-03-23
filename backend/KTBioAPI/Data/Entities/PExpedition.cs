using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PExpedition
{
    public string? EIntitule { get; set; }

    public string? EMode { get; set; }

    public string? ArRef { get; set; }

    public short? ETypeFrais { get; set; }

    public decimal? EValFrais { get; set; }

    public short? ETypeLigneFrais { get; set; }

    public short? ETypeFranco { get; set; }

    public decimal? EValFranco { get; set; }

    public short? ETypeLigneFranco { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }

    public short? ETypeCalcul { get; set; }
}
