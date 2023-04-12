namespace Api_Passport_and_Visa_Service.Model;

public class PaymentInvoice
{
    public int id { get; set; }
    public DateOnly date_Payment { get; set; }
    public double price { get; set; }
    public int clientId { get; set; }
    
    public Client client { get; set; }
}