using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Requestonintpassport
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateOnly? DateReq { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
