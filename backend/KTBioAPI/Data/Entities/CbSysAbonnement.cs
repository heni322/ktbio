using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class CbSysAbonnement
{
    public Guid CbSiteGuid { get; set; }

    public short CbIdArticle { get; set; }

    public int CbLastReplication { get; set; }
}
