using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class FProtectioncptum
{
    public string ProtUser { get; set; } = null!;

    public byte[]? CbCiprotUser { get; set; }

    public string? ProtDescription { get; set; }

    public short? ProtRight { get; set; }

    public int? ProtNo { get; set; }

    public string? ProtEmail { get; set; }

    public int? ProtUserProfil { get; set; }

    public int? CbProtUserProfil { get; set; }

    public short? ProtAdministrator { get; set; }

    public DateTime? ProtDatePwd { get; set; }

    public DateTime? ProtDateCreate { get; set; }

    public DateTime? ProtLastLoginDate { get; set; }

    public string? ProtLastLoginTime { get; set; }

    public short? ProtPwdStatus { get; set; }

    public short? ProtDisabled { get; set; }

    public int? ProtApplicationRight { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public short? ProtAllowExternalAccess { get; set; }

    public Guid? ProtGuid { get; set; }

    public byte[]? ProtHash { get; set; }

    public virtual FProtectioncptum? CbProtUserProfilNavigation { get; set; }

    public virtual ICollection<FCollaborateur> FCollaborateurs { get; set; } = new List<FCollaborateur>();

    public virtual ICollection<FEprotectioncptum> FEprotectioncpta { get; set; } = new List<FEprotectioncptum>();

    public virtual ICollection<FProtectioncptum> InverseCbProtUserProfilNavigation { get; set; } = new List<FProtectioncptum>();
}
