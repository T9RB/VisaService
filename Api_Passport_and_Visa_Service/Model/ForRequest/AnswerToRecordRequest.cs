namespace Api_Passport_and_Visa_Service.ForRequest;

public class AnswerToRecordRequest
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int RecordsId { get; set; }

    public string? MessageToClient { get; set; }

    public string? ApplicationStatus { get; set; }

    public string? DateAnswer { get; set; }
}