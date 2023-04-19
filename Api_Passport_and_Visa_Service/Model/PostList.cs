using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class PostList
{
    public int Id { get; set; }

    public string? NamePost { get; set; }

    public bool? Managet { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
