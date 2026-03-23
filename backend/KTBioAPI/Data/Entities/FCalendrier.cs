using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FCalendrier
{
    public string CalIntitule { get; set; } = null!;

    public byte[]? CbCalIntitule { get; set; }

    public int? CalNo { get; set; }

    public short? CalFirstWeekDay { get; set; }

    public short? CalFirstWeek { get; set; }

    public short? CalOuvre01 { get; set; }

    public short? CalOuvre02 { get; set; }

    public short? CalOuvre03 { get; set; }

    public short? CalOuvre04 { get; set; }

    public short? CalOuvre05 { get; set; }

    public short? CalOuvre06 { get; set; }

    public short? CalOuvre07 { get; set; }

    public string? CalHoraire0101CalPlageDebut { get; set; }

    public string? CalHoraire0101CalPlageFin { get; set; }

    public string? CalHoraire0102CalPlageDebut { get; set; }

    public string? CalHoraire0102CalPlageFin { get; set; }

    public string? CalHoraire0201CalPlageDebut { get; set; }

    public string? CalHoraire0201CalPlageFin { get; set; }

    public string? CalHoraire0202CalPlageDebut { get; set; }

    public string? CalHoraire0202CalPlageFin { get; set; }

    public string? CalHoraire0301CalPlageDebut { get; set; }

    public string? CalHoraire0301CalPlageFin { get; set; }

    public string? CalHoraire0302CalPlageDebut { get; set; }

    public string? CalHoraire0302CalPlageFin { get; set; }

    public string? CalHoraire0401CalPlageDebut { get; set; }

    public string? CalHoraire0401CalPlageFin { get; set; }

    public string? CalHoraire0402CalPlageDebut { get; set; }

    public string? CalHoraire0402CalPlageFin { get; set; }

    public string? CalHoraire0501CalPlageDebut { get; set; }

    public string? CalHoraire0501CalPlageFin { get; set; }

    public string? CalHoraire0502CalPlageDebut { get; set; }

    public string? CalHoraire0502CalPlageFin { get; set; }

    public string? CalHoraire0601CalPlageDebut { get; set; }

    public string? CalHoraire0601CalPlageFin { get; set; }

    public string? CalHoraire0602CalPlageDebut { get; set; }

    public string? CalHoraire0602CalPlageFin { get; set; }

    public string? CalHoraire0701CalPlageDebut { get; set; }

    public string? CalHoraire0701CalPlageFin { get; set; }

    public string? CalHoraire0702CalPlageDebut { get; set; }

    public string? CalHoraire0702CalPlageFin { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public virtual ICollection<FEcalendrier> FEcalendriers { get; set; } = new List<FEcalendrier>();

    public virtual ICollection<FRessourceprod> FRessourceprods { get; set; } = new List<FRessourceprod>();
}
