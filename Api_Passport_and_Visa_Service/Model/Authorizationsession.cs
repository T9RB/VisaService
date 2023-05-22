using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Authorizationsession
{
    public int Id { get; set; }

    public int? Accountsid { get; set; }

    public string Dateauthorization { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool Access { get; set; }

    public virtual Usersdatum? Accounts { get; set; }
}
