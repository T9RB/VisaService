using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Usersdatum
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Authorizationsession> Authorizationsessions { get; } = new List<Authorizationsession>();

    public virtual ICollection<Employeeaccount> Employeeaccounts { get; } = new List<Employeeaccount>();

    public virtual ICollection<Usersaccount> Usersaccounts { get; } = new List<Usersaccount>();
}
