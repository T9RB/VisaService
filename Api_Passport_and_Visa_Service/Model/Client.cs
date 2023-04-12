namespace Api_Passport_and_Visa_Service.Model;

public class Client
{
    public int id { get; set; }
    public string surname { get; set; }
    public string nameClient { get; set; }
    public string middleName { get; set; }
    public string placeOfBirth { get; set; }
    public string nationaly { get; set; }
    public DateOnly Birthday { get; set; }
    public string familyStatus { get; set; }
    public int passportDataId { get; set; }
    public int registrationId { get; set; }
    public string citizenship { get; set; }
    
    public PassportData passportData { get; set; }
    public Registration Registration { get; set; }
    
    private ICollection<RequestOnIntPassport> requestOnIntPassport { get; set; }
    
    private ICollection<RequestOnVisa> requestOnVisa { get; set; }
    
    private ICollection<RecordAppointment> RecordAppointment { get; set; }
    
    private ICollection<DepartureCountry> departureCountry { get; set; }
    
    private ICollection<Visa> visa { get; set; }
    
    private ICollection<PaymentInvoice> paymentInvoice { get; set; }
    
    private ICollection<InternationalPassport> internationalPassport { get; set; }

}