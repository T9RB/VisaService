namespace Api_Passport_and_Visa_Service.Model;

public class RequestOnVisa
{
    public int id { get; set; }
    public int number { get; set; }
    public DateOnly dateReq { get; set; }
    public string departureGoals { get; set; }
    public DateOnly returnDate { get; set; }
    public string Country { get; set; }
    public int clientId { get; set; }
    
    public Client client { get; set; }
}