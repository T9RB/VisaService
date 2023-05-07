using Api_Passport_and_Visa_Service.Model.ForResponse;

namespace Api_Passport_and_Visa_Service.ForRequest;

public class RecordAppointmentRequest
{
    public int id {get; set;}
    public string dateAppointment { get; set; }
    public string purposeOfAdmission { get; set; }

    public int ClientId { get; set; }

    public int EmployeeId { get; set; }
}