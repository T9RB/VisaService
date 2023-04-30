using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Recordappointment
{
    public int Id { get; set; }

    public DateOnly? DateAppointment { get; set; }

    public int ClientId { get; set; }

    public int EmployeeId { get; set; }

    public string? PurposeOfAdmission { get; set; }

    public virtual ICollection<Answertorecord> Answertorecords { get; } = new List<Answertorecord>();

    public virtual Client Client { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
