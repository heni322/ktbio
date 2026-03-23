using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpProjetfabrication
{
    public string PfNumprojet { get; set; } = null!;

    public string? PfStatut { get; set; }

    public string? PfIntitule { get; set; }

    public string? PfNo { get; set; }

    public string? PfAffaire { get; set; }

    public string? PfDatedebutAn { get; set; }

    public string? PfDatedebutSemestre { get; set; }

    public string? PfDatedebutTrimestre { get; set; }

    public string? PfDatedebutMois { get; set; }

    public string? PfDatedebutWeek { get; set; }

    public string? PfDatedebutJour { get; set; }

    public DateTime? PfDatedebut { get; set; }

    public string? PfDatefinAn { get; set; }

    public string? PfDatefinSemestre { get; set; }

    public string? PfDatefinTrimestre { get; set; }

    public string? PfDatefinMois { get; set; }

    public string? PfDatefinWeek { get; set; }

    public string? PfDatefinJour { get; set; }

    public DateTime? PfDatefin { get; set; }

    public string? PfPiece { get; set; }

    public decimal? PfAvencQuantite { get; set; }

    public double? PfAvencDuree { get; set; }
}
