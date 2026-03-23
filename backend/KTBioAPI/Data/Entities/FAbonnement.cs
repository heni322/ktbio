using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FAbonnement
{
    public int? AbNo { get; set; }

    public short? AbTypeTiers { get; set; }

    public short? AbType { get; set; }

    public string? CtNum { get; set; }

    public byte[]? CbCtNum { get; set; }

    public string? AbModele { get; set; }

    public byte[]? CbAbModele { get; set; }

    public string? AbIntitule { get; set; }

    public byte[]? CbAbIntitule { get; set; }

    public string? AbContrat { get; set; }

    public short? AbPeriodicite { get; set; }

    public short? AbTypePeriod { get; set; }

    public short? AbDuree { get; set; }

    public short? AbTypeDuree { get; set; }

    public DateTime? AbDebut { get; set; }

    public DateTime? AbFin { get; set; }

    public DateTime? AbResiliation { get; set; }

    public short? AbMotif { get; set; }

    public short? AbDelai { get; set; }

    public short? AbTypeDelai { get; set; }

    public DateTime? AbFinAbo { get; set; }

    public short? AbReconduction { get; set; }

    public short? AbPieceGen { get; set; }

    public short? AbSouche { get; set; }

    public short? AbNbJoursGen { get; set; }

    public short? AbTypeGen { get; set; }

    public short? AbJourTbGen01 { get; set; }

    public short? AbJourTbGen02 { get; set; }

    public short? AbJourTbGen03 { get; set; }

    public short? AbJourTbGen04 { get; set; }

    public short? AbJourTbGen05 { get; set; }

    public short? AbJourTbGen06 { get; set; }

    public short? AbNbJoursLivr { get; set; }

    public short? AbTypeLivr { get; set; }

    public short? AbJourTbLivr01 { get; set; }

    public short? AbJourTbLivr02 { get; set; }

    public short? AbJourTbLivr03 { get; set; }

    public short? AbJourTbLivr04 { get; set; }

    public short? AbJourTbLivr05 { get; set; }

    public short? AbJourTbLivr06 { get; set; }

    public short? AbEntete { get; set; }

    public short? AbTarif { get; set; }

    public short? AbRemise { get; set; }

    public short? AbCatCompta { get; set; }

    public short? AbRepresent { get; set; }

    public short? AbDepot { get; set; }

    public short? AbEscompte { get; set; }

    public short? AbEcheance { get; set; }

    public short? AbContact { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual FComptet? CtNumNavigation { get; set; }

    public virtual FAboentete? FAboentete { get; set; }

    public virtual ICollection<FAboperiode> FAboperiodes { get; set; } = new List<FAboperiode>();
}
