namespace Api_Passport_and_Visa_Service.Model;

public class DepartureCountry
{
    public int id { get; set; }
    public DateOnly dateDeparture { get; set; }
    
    public ICollection<Client> client { get; set; }
    public ICollection<Status> status { get; set; }
}