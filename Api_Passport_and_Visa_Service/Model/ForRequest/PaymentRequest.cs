namespace Api_Passport_and_Visa_Service.ForRequest;

public class PaymentRequest
{
    public int Id { get; set; }

    public string? DatePayment { get; set; }

    public int ClientId { get; set; }

    public double? Price { get; set; }
}