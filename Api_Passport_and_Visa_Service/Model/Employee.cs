﻿using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Employee
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? NameEmp { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? QualificationLevel { get; set; }

    public int PostId { get; set; }

    public virtual Employeeaccount? Employeeaccount { get; set; }
}
