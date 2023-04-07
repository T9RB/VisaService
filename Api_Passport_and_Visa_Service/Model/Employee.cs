namespace Api_Passport_and_Visa_Service.Model;

public class Employee
{
    public int id { get; set; }
    public string surname { get; set; }
    public string nameEmp { get; set; }
    public string middleName { get; set; }
    public DateOnly birthday { get; set; }
    public string gender { get; set; }
    public string qualificationLevel { get; set; }
    
    public ICollection<Post_List> employeePost { get; set; }
}