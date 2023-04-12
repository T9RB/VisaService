namespace Api_Passport_and_Visa_Service.Model;

public class DepartureCountry
{
    public int id { get; set; }
    public DateOnly dateDeparture { get; set; }
    public int clientId { get; set; }
    
    public Client client { get; set; }
}