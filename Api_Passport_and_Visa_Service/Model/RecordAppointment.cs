namespace Api_Passport_and_Visa_Service.Model;

public class RecordAppointment
{
    public int id {get; set;}
    public DateOnly dateAppointment { get; set; }
    public string purposeOfAdmission { get; set; }
    public int clientId { get; set; }
    
    public Client client { get; set; }
}