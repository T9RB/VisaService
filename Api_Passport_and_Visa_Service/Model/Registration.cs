using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Registration
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public string? Flat { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
