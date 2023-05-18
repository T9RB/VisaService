using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Employeeaccount
{
    public int Id { get; set; }

    public int? Accountid { get; set; }

    public int? Employeeid { get; set; }

    public virtual Userdatum? Account { get; set; }

    public virtual Employee? Employee { get; set; }
}
