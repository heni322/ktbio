using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PSecuritystrategycial
{
    public short? SecurPwdRenouv { get; set; }

    public short? SecurPwdComplex { get; set; }

    public short? SecurPwdChain { get; set; }

    public short? SecurPwdRequired { get; set; }

    public int CbMarq { get; set; }

    public short? SecurPwdStrong { get; set; }
}
