namespace Api_Passport_and_Visa_Service.Model;

public class Status
{
    public int id { get; set; }
    public string nameStatus { get; set; }
    public string reasonForRefusal { get; set; }
    
    public ICollection<DepartureCountry> departureCountry { get; set; }
}