namespace Api_Passport_and_Visa_Service.Model;

public class RecordAppointment
{
    public int id {get; set;}
    public DateOnly dateAppointment { get; set; }
    public string purposeOfAdmission { get; set; }
    
    public ICollection<Client> client { get; set; }
    public ICollection<Employee> employee { get; set; }
}