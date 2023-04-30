using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Answertoreqvisa
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int ReqVisaId { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateOnly? DateAnswer { get; set; }

    public virtual Requestonvisa ReqVisa { get; set; } = null!;
}
