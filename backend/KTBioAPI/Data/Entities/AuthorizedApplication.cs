using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class AuthorizedApplication
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Token { get; set; } = null!;
}
