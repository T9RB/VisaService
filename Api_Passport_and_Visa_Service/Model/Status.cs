using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Status
{
    public int Id { get; set; }

    public string? NameStatus { get; set; }

    public string? Reasonforrefusal { get; set; }
}
