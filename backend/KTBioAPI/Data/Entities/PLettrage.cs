using System;
using System.Collections.Generic;

namespace KTBioAPI.Data.Entities;

public partial class PLettrage
{
    public string? JoNum { get; set; }

    public int? PiNoDebit { get; set; }

    public int? PiNoCredit { get; set; }

    public decimal? LMaxDebit { get; set; }

    public decimal? LMaxCredit { get; set; }

    public short? LConv { get; set; }

    public string? JoNumConv { get; set; }

    public int? PiNoDebitConv { get; set; }

    public int? PiNoCreditConv { get; set; }

    public decimal? LSeuilConv { get; set; }

    public string? JoNumChange { get; set; }

    public int? PiNoDebitChange { get; set; }

    public int? PiNoCreditChange { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}
