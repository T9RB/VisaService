namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class VisaResponse
{
    public int Id { get; set; }

    public short? Number { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? PlaceOfIssue { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public List<ClientResponse> Client { get; set; } 
}