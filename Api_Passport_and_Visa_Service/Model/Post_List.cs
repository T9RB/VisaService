namespace Api_Passport_and_Visa_Service.Model;

public class Post_List
{
    public int id { get; set; }
    public string namePost { get; set; }
    public bool managet { get; set; }
    
    public ICollection<Employee> employee { get; set; }
}