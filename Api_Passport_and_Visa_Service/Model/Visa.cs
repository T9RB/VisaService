using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Visa
{
    public int Id { get; set; }

    public short? Number { get; set; }

    public int ClientId { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? PlaceOfIssue { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public virtual Client Client { get; set; } = null!;
}
