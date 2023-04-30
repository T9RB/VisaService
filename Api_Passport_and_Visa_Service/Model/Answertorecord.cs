using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Answertorecord
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int RecordsId { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateOnly? DateAnswer { get; set; }

    public virtual Recordappointment Records { get; set; } = null!;
}
