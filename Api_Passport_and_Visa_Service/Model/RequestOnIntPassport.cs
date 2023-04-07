namespace Api_Passport_and_Visa_Service.Model;

public class RequestOnIntPassport
{
    public int id { get; set; }
    public int number { get; set; }
    public DateOnly dateReq { get; set; }
    
    public ICollection<Client> client { get; set; }
}