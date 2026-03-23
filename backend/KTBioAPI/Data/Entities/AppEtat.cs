using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class AppEtat
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string FamillesJson { get; set; } = null!;

    public string UtilisateursJson { get; set; } = null!;

    public string DepotsJson { get; set; } = null!;
}
