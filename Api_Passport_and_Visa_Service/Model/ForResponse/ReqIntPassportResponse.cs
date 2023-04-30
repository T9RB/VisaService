namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class ReqIntPassportResponse
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateOnly? DateReq { get; set; }
    
    public List<ClientResponse> Client { get; set; }
}