namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class RecordAppointmentResponse
{
    public int id {get; set;}
    public string dateAppointment { get; set; }
    public string purposeOfAdmission { get; set; }

    public List<ClientResponse> client { get; set; }
    public List<EmployeeResponse> employee { get; set; }
}