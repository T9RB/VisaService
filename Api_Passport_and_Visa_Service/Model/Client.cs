using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Client
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? NameClient { get; set; }

    public string? MiddleName { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? Nationaly { get; set; }

    public string? Birthday { get; set; }

    public string? FamilyStatus { get; set; }

    public int PassportDataId { get; set; }

    public int RegistrationId { get; set; }

    public string? Cituzenship { get; set; }

    public virtual ICollection<Clientaccount> Clientaccounts { get; } = new List<Clientaccount>();
    public virtual Passportdatum PassportData { get; set; } = new Passportdatum();
    public virtual Registration Registration { get; set; } = new Registration();
}
