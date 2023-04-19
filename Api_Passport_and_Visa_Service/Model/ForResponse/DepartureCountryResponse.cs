namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class DepartureCountryResponse
{
    public int id { get; set; }
    public DateOnly? dateDeparture { get; set; }
    
    public List<ClientResponse> client { get; set; }
}