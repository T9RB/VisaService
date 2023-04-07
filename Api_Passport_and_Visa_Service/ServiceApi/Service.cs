using Api_Passport_and_Visa_Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Passport_and_Visa_Service.Service;

public class Service
{
    private VisaDbContext _dbcontext;
    
    public Service(VisaDbContext context)
    {
        _dbcontext = context;
    }
    
    public List<Client> GetAllClients()
    {
        var clients = _dbcontext.client.Include(x => x.PassportDatas).Include(c => c.Registrations).ToList();
        var clientsList = clients.Select(x => new Client()
        {
            id = x.id,
            surname = x.surname,
            nameClient = x.nameClient,
            middleName = x.middleName,
            placeOfBirth = x.placeOfBirth,
            nationaly = x.nationaly,
            Birthday = x.Birthday,
            familyStatus = x.familyStatus,
            PassportDatas = x.PassportDatas.Select(x => new PassportData(){id = x.id,series = x.series, number = x.number}).ToList(),
            Registrations = x.Registrations.Select(x => new Registration(){ID = x.ID, City = x.City,Street = x.Street, House = x.House, Flat = x.Flat}).ToList(),
            Citizenship = x.Citizenship
        }).ToList();
    
        return clientsList;
    }
    
    public List<Employee> GetAllEmployees()
    {
        var employees = _dbcontext.employees.Include(x => x.employeePost).ToList();
        var empList = employees.Select(x => new Employee()
        {
            id = x.id,
            surname = x.surname,
            nameEmp = x.nameEmp,
            middleName = x.middleName,
            birthday = x.birthday,
            gender = x.gender,
            qualificationLevel = x.qualificationLevel,
            employeePost = x.employeePost
        }).ToList();
    
        return empList;
    }

    public List<DepartureCountry> GetAllDeparture()
    {
        var depart = _dbcontext.departureCountry.Include(x => x.status).Include(c => c.client).ToList();

        var depList = depart.Select(x => new DepartureCountry()
        {
            id = x.id,
            dateDeparture = x.dateDeparture,
            client = x.client.Select(x => new Client(){id = x.id,surname = x.surname, nameClient = x.nameClient, middleName = x.middleName, placeOfBirth = x.placeOfBirth, nationaly = x.nationaly, Birthday = x.Birthday, familyStatus = x.familyStatus, PassportDatas = x.PassportDatas, Registrations = x.Registrations, Citizenship = x.Citizenship}).ToList(),
            status = x.status.Select(x => new Status(){id = x.id, nameStatus = x.nameStatus, reasonForRefusal = x.reasonForRefusal}).ToList()
        }).ToList();

        return depList;
    }

    public List<InternationalPassport> GetAllPassportsInt()
    {
        var passport = _dbcontext.internationalPassport.Include(x => x.client).ToList();

        var passpList = passport.Select(x => new InternationalPassport()
        {
            id = x.id,
            series = x.series,
            number = x.number,
            organization = x.organization,
            client = x.client.Select(r => new Client(){id = r.id, surname = r.surname, nameClient = r.nameClient, middleName = r.middleName, placeOfBirth = r.placeOfBirth, Citizenship = r.Citizenship, Birthday = r.Birthday, familyStatus = r.familyStatus, nationaly = r.nationaly}).ToList()
        }).ToList();

        return passpList;
    }

    public List<PassportData> GetAllPassports()
    {
        var passport = _dbcontext.passportData.ToList();
        
        
        
        return passport;
    }
}