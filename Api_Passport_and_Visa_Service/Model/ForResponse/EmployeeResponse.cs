namespace Api_Passport_and_Visa_Service.Model.ForResponse;

public class EmployeeResponse
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? NameEmp { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? QualificationLevel { get; set; }

    public List<PostResponse> Post { get; set; }
}