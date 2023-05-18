using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Clientaccount
{
    public int Id { get; set; }

    public int? Accountid { get; set; }

    public int? Clientid { get; set; }

    public virtual Userdatum? Account { get; set; }

    public virtual Client? Client { get; set; }
}
