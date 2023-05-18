using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Internationalpassport
{
    public int Id { get; set; }

    public string? Series { get; set; }

    public string? Number { get; set; }

    public int ClientId { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? Organization { get; set; }
}
