namespace Api_Passport_and_Visa_Service.ForRequest;

public class IntPassportRequest
{
    public int Id { get; set; }

    public string? Series { get; set; }

    public string? Number { get; set; }

    public int ClientId { get; set; }

    public string? DateStart { get; set; }

    public string? DateEnd { get; set; }

    public string? Organization { get; set; }
}