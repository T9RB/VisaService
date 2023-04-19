using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Departurecountry
{
    public int Id { get; set; }

    public DateOnly? DateDeparture { get; set; }

    public int ClientId { get; set; }

    public int StatusId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
