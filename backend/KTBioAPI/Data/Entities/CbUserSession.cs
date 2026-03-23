using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbUserSession
{
    public short CbSession { get; set; }

    public string? CbType { get; set; }

    public string? CbCreator { get; set; }

    public short? CbLicence { get; set; }

    public short? CbLockBase { get; set; }

    public short? CbOldMode { get; set; }

    public byte[]? CbWorkstation { get; set; }

    public string? CbExtCreator { get; set; }

    public string? CbUserName { get; set; }

    public short? CbCurrentSynchroType { get; set; }
}
