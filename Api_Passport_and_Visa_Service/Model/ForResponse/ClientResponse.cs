namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class ClientResponse
{
    public int id { get; set; }
    public string surname { get; set; }
    public string nameClient { get; set; }
    public string middleName { get; set; }
    public string placeOfBirth { get; set; }
    public string nationaly { get; set; }
    public string Birthday { get; set; }
    public string familyStatus { get; set; }
    public string Citizenship { get; set; }
    
    public List<PassportDataResponse> PassportData { get; set; }
    public List<RegistrationResponse> Registration { get; set; }
}