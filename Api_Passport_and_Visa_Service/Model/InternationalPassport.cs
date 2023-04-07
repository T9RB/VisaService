namespace Api_Passport_and_Visa_Service.Model;

public class InternationalPassport
{
    public int id { get; set; }
    public string series { get; set; }
    public string number { get; set; }
    public DateOnly dateStart { get; set; }
    public DateOnly dateEnd { get; set; }
    public string organization { get; set; }
    
    public ICollection<Client> client { get; set; }
}