using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Passportdatum
{
    public int Id { get; set; }

    public string? Series { get; set; }

    public string? Number { get; set; }

    public virtual Client? Client { get; set; }
}
