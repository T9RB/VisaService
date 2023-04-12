namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class RecordAppointmentResponse
{
    public int id {get; set;}
    public DateOnly dateAppointment { get; set; }
    public string purposeOfAdmission { get; set; }

    public List<ClientResponse> clientResponse { get; set; }
}