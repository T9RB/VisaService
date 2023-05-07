namespace Api_Passport_and_Visa_Service.ForRequest;

public class AnswerToVisaRequest
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int ReqVisaId { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public string? DateAnswer { get; set; }
}