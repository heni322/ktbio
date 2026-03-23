using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class DpEcritc
{
    public string EcCgnum { get; set; } = null!;

    public string? EcCtnum { get; set; }

    public short? EcNdevise { get; set; }

    public short? EcNreglement { get; set; }

    public int EcPk { get; set; }

    public int EcEcno { get; set; }

    public string? EcEcpiece { get; set; }

    public string EcJonum { get; set; } = null!;

    public DateTime EcJmdate { get; set; }

    public DateTime? EcEcdate { get; set; }

    public string? EcEcrefpiece { get; set; }

    public string? EcEctresopiece { get; set; }

    public string? EcEcintitule { get; set; }

    public string? EcEcpoint { get; set; }

    public string? EcEcpointage { get; set; }

    public string? EcEclettre { get; set; }

    public string? EcEclettrage { get; set; }

    public DateTime? EcEcecheance { get; set; }

    public string EcEcrtype { get; set; } = null!;

    public short? EcTypeecrit { get; set; }

    public decimal? EcEcparite { get; set; }

    public decimal? EcEcquantite { get; set; }

    public string? EcCtnumcont { get; set; }

    public string? EcTacode { get; set; }

    public string EcEcsens { get; set; } = null!;

    public short? EcEcrappel { get; set; }

    public decimal? EcEcmontant { get; set; }

    public decimal? EcEcmontantD { get; set; }

    public decimal? EcEcmontantC { get; set; }

    public decimal? EcEcdevise { get; set; }

    public DateTime? EcDateecriture { get; set; }

    public string? EcAnneecriture { get; set; }

    public string? EcSemecriture { get; set; }

    public string? EcTriecriture { get; set; }

    public string? EcMoisecriture { get; set; }

    public string EcJourecriture { get; set; } = null!;

    public string? EcWeekecriture { get; set; }

    public string? EcPerdate { get; set; }

    public string? EcSyntheecritu { get; set; }

    public string EcModregl { get; set; } = null!;

    public string EcTypeanew { get; set; } = null!;

    public string EcTypeecritu { get; set; } = null!;

    public string EcNomdevise { get; set; } = null!;

    public string? EcEcreference { get; set; }

    public string? EcNumRecouv { get; set; }
}
