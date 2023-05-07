namespace Api_Passport_and_Visa_Service.ForRequest;

public class RecordIntPassportRequest
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? DateReq { get; set; }

    public int ClientId { get; set; }
}