using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Usersaccount
{
    public int Id { get; set; }

    public int? Accountsid { get; set; }

    public int? Clientid { get; set; }

    public virtual Usersdatum? Accounts { get; set; }

    public virtual Client? Client { get; set; }
}
