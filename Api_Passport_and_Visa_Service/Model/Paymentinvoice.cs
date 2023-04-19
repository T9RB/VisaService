using System;
using System.Collections.Generic;

namespace Api_Passport_and_Visa_Service;

public partial class Paymentinvoice
{
    public int Id { get; set; }

    public DateOnly? DatePayment { get; set; }

    public int ClientId { get; set; }

    public double? Price { get; set; }

    public virtual Client Client { get; set; } = null!;
}
