using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Userdatum
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Clientaccount> Clientaccounts { get; } = new List<Clientaccount>();

    public virtual ICollection<Employeeaccount> Employeeaccounts { get; } = new List<Employeeaccount>();
}
