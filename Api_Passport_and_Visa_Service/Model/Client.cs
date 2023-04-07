namespace Api_Passport_and_Visa_Service.Model;

public class Client
{
    public int id { get; set; }
    public string surname { get; set; }
    public string nameClient { get; set; }
    public string middleName { get; set; }
    public string placeOfBirth { get; set; }
    public string nationaly { get; set; }
    public DateOnly Birthday { get; set; }
    public string familyStatus { get; set; }
    public string Citizenship { get; set; }
    
    public ICollection<PassportData> PassportDatas { get; set; }
    public ICollection<Registration> Registrations { get; set; }
}