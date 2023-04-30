namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class PaymentForResponse
{
    public int Id { get; set; }

    public DateOnly? DatePayment { get; set; }

    public double? Price { get; set; }
    
    public List<ClientResponse> Client { get; set; }
}