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

    public virtual ICollection<Departurecountry> Departurecountries { get; } = new List<Departurecountry>();

    public virtual ICollection<Internationalpassport> Internationalpassports { get; } = new List<Internationalpassport>();

    public virtual Passportdatum PassportData { get; set; } = null!;

    public virtual ICollection<Paymentinvoice> Paymentinvoices { get; } = new List<Paymentinvoice>();

    public virtual ICollection<Recordappointment> Recordappointments { get; } = new List<Recordappointment>();

    public virtual Registration Registration { get; set; } = null!;

    public virtual ICollection<Requestonintpassport> Requestonintpassports { get; } = new List<Requestonintpassport>();

    public virtual ICollection<Requestonvisa> Requestonvisas { get; } = new List<Requestonvisa>();

    public virtual ICollection<Usersaccount> Usersaccounts { get; } = new List<Usersaccount>();

    public virtual ICollection<Visa> Visas { get; } = new List<Visa>();
}
