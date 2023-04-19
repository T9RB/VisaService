using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Requestonvisa
{
    public int Id { get; set; }

    public short? Number { get; set; }

    public DateOnly? DateReq { get; set; }

    public int ClientId { get; set; }

    public string? DepartureGoals { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Country { get; set; }

    public virtual Client Client { get; set; } = null!;
}
