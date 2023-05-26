using System;

namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class AuthorizationResponse
{
    public int accountID { get; set; }
    public int? clientID { get; set; }
    public DateTime dateAuthorization { get; set; }
    public string status { get; set; }
    public bool access { get; set; }
}