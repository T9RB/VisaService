namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class AnswRecPassport
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateOnly? DateAnswer { get; set; }
    
    public List<ReqIntPassportResponse> Record { get; set; }
}