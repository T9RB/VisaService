namespace Api_Passport_and_Visa_Service.Model;

public class Visa
{
    public int id { get; set; }
    public int number { get; set; }
    public DateOnly dateStart { get; set; }
    public DateOnly dateEnd { get; set; }
    public string placeOfIssue { get; set; }
    public DateOnly dateOfIssue { get; set; }
    
    public ICollection<Client> client { get; set; }
}