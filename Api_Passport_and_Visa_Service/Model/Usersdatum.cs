using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Usersdatum
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual Client? User { get; set; }
}
