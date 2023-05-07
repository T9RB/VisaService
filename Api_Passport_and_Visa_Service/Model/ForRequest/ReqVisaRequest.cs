namespace Api_Passport_and_Visa_Service.ForRequest;

public class ReqVisaRequest
{
    public int Id { get; set; }

    public short? Number { get; set; }

    public string? DateReq { get; set; }

    public int ClientId { get; set; }

    public string? DepartureGoals { get; set; }

    public string? ReturnDate { get; set; }

    public string? Country { get; set; }
}