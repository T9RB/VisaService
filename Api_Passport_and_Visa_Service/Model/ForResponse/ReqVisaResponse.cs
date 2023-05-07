namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class ReqVisaResponse
{
    public int Id { get; set; }

    public short? Number { get; set; }

    public DateOnly? DateReq { get; set; }

    public string? DepartureGoals { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Country { get; set; }
    
    public List<ClientResponse> client { get; set; }
}