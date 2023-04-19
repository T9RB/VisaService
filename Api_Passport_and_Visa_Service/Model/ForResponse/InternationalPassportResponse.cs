namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class InternationalPassportResponse
{
    public int id { get; set; }
    public string series { get; set; }
    public string number { get; set; }
    public DateOnly? dateStart { get; set; }
    public DateOnly? dateEnd { get; set; }
    public string organization { get; set; }
    
    public List<ClientResponse> clientResponse { get; set; }
}