namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class AnswRecVisa
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateOnly? DateAnswer { get; set; }
    
    public List<ReqVisaResponse> Record { get; set; }
}