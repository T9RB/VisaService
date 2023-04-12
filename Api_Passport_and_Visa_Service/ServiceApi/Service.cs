using Api_Passport_and_Visa_Service.Model;
using Api_Passport_and_Visa_Service.Model.ForResponse;
using Microsoft.EntityFrameworkCore;

namespace Api_Passport_and_Visa_Service.Service;

public class Service
{
    private VisaDbContext _dbcontext;
    
    public Service(VisaDbContext context)
    {
        _dbcontext = context;
    }
    
     public List<ClientResponse> GetAllClients()
     {
         var clients = _dbcontext.client.ToList();
         var passData = _dbcontext.passportData.ToList();
         var reg = _dbcontext.registration.ToList();
         
         var clientsList = clients.Select(x => new ClientResponse()
         {
             id = x.id,
             surname = x.surname,
             nameClient = x.nameClient,
             middleName = x.middleName,
             placeOfBirth = x.placeOfBirth,
             nationaly = x.nationaly,
             Birthday = x.Birthday,
             familyStatus = x.familyStatus,
             Citizenship = x.citizenship,
             PassportData = passData.Select(pd => new PassportDataResponse(){id = pd.id, series = pd.series ,number = pd.number}).Where(c => c.id == x.passportDataId).ToList(),
             Registration = reg.Select(rg => new RegistrationResponse(){ID = rg.ID, City = rg.City, Street = rg.Street, House = rg.House, Flat = rg.Flat}).Where(r => r.ID == x.registrationId).ToList()
         }).ToList();
     
         return clientsList;
     }
     
     // public List<Employee> GetAllEmployees()
     // {
     //     var employees = _dbcontext.employees.ToList();
     //     var empList = employees.Select(x => new Employee()
     //     {
     //         id = x.id,
     //         surname = x.surname,
     //         nameEmp = x.nameEmp,
     //         middleName = x.middleName,
     //         birthday = x.birthday,
     //         gender = x.gender,
     //         qualificationLevel = x.qualificationLevel,
     //         employeePost = x.employeePost
     //     }).ToList();
     //
     //     return empList;
     // }
     //
     public List<DepartureCountryResponse> GetAllDeparture()
     {
         var depart = _dbcontext.departureCountry.ToList();
         var clients = GetAllClients();
     
         var depList = depart.Select(x => new DepartureCountryResponse()
         {
             id = x.id,
             dateDeparture = x.dateDeparture,
             client = clients.Where(c => c.id == x.clientId).ToList()
         }).ToList();
     
         return depList;
     }
     
     public List<InternationalPassportResponse> GetAllPassportsInt()
     {
         var passport = _dbcontext.internationalPassport.ToList();
         var clients = GetAllClients();
     
         var passpList = passport.Select(x => new InternationalPassportResponse()
         {
             id = x.id,
             series = x.series,
             number = x.number,
             dateStart = x.dateStart,
             dateEnd = x.dateEnd,
             organization = x.organization,
             clientResponse = clients.Where(c => c.id == x.clientId).ToList()
         }).ToList();
     
         return passpList;
     }
     
     public List<PassportDataResponse> GetAllPassports()
     {
         var passport = _dbcontext.passportData.ToList();

         var passportDataResp = passport.Select(x => new PassportDataResponse()
         {
             id = x.id,
             series = x.series,
             number = x.number
         }).ToList();
         
         return passportDataResp;
     }

     public List<RecordAppointmentResponse> GetAllRecordAppointmentResponses()
     {
         var records = _dbcontext.recordAppointment.ToList();
         var clients = GetAllClients();

         var recordsList = records.Select(x => new RecordAppointmentResponse()
         {
            id = x.id,
            dateAppointment = x.dateAppointment,
            purposeOfAdmission = x.purposeOfAdmission,
            clientResponse = clients.Where(c => c.id == x.clientId).ToList()
         }).ToList();

         return recordsList;
     }
     
     
     
     
}