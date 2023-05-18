using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Answertoreqpassport
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int ReqPassportId { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateOnly? DateAnswer { get; set; }
}
