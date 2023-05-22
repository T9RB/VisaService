using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Employeeaccount
{
    public int Id { get; set; }

    public int? Accountsid { get; set; }

    public int? Emloyeeid { get; set; }

    public virtual Usersdatum? Accounts { get; set; }

    public virtual Employee? Emloyee { get; set; }
}
