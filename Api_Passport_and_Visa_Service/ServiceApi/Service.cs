using Api_Passport_and_Visa_Service.Model;
using Api_Passport_and_Visa_Service.Model.ForResponse;
using Microsoft.AspNetCore.Mvc;
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
         var clients = _dbcontext.Clients.ToList();
         var passData = _dbcontext.Passportdata.ToList();
         var reg = _dbcontext.Registrations.ToList();
         
         var clientsList = clients.Select(x => new ClientResponse()
         {
             id = x.Id,
             surname = x.Surname,
             nameClient = x.NameClient,
             middleName = x.MiddleName,
             placeOfBirth = x.PlaceOfBirth,
             nationaly = x.Nationaly,
             Birthday = x.Birthday,
             familyStatus = x.FamilyStatus,
             Citizenship = x.Cituzenship,
             PassportData = passData.Select(pd => new PassportDataResponse(){id = pd.Id, series = pd.Series ,number = pd.Number}).Where(c => c.id == x.PassportDataId).ToList(),
             Registration = reg.Select(rg => new RegistrationResponse(){ID = rg.Id, City = rg.City, Street = rg.Street, House = rg.House, Flat = rg.Flat}).Where(r => r.ID == x.RegistrationId).ToList()
         }).ToList();
     
         return clientsList;
     }
     
     
     public List<DepartureCountryResponse> GetAllDeparture()
     {
         var depart = _dbcontext.Departurecountries.ToList();
         var clients = GetAllClients();
     
         var depList = depart.Select(x => new DepartureCountryResponse()
         {
             id = x.Id,
             dateDeparture = x.DateDeparture,
             client = clients.Where(c => c.id == x.ClientId).ToList()
         }).ToList();
     
         return depList;
     }
     
     public List<InternationalPassportResponse> GetAllPassportsInt()
     {
         var passport = _dbcontext.Internationalpassports.ToList();
         var clients = GetAllClients();
     
         var passpList = passport.Select(x => new InternationalPassportResponse()
         {
             id = x.Id,
             series = x.Series,
             number = x.Number,
             dateStart = x.DateStart,
             dateEnd = x.DateStart,
             organization = x.Organization,
             clientResponse = clients.Where(c => c.id == x.ClientId).ToList()
         }).ToList();
     
         return passpList;
     }
     
     public List<PassportDataResponse> GetAllPassports()
     {
         var passport = _dbcontext.Passportdata.ToList();

         var passportDataResp = passport.Select(x => new PassportDataResponse()
         {
             id = x.Id,
             series = x.Series,
             number = x.Number
         }).ToList();
         
         return passportDataResp;
     }

     public List<RecordAppointmentResponse> GetAllRecordAppointmentResponses()
     {
         var records = _dbcontext.Recordappointments.ToList();
         var clients = GetAllClients();

         var recordsList = records.Select(x => new RecordAppointmentResponse()
         {
            id = x.Id,
            dateAppointment = x.DateAppointment,
            purposeOfAdmission = x.PurposeOfAdmission,
            clientResponse = clients.Where(c => c.id == x.ClientId).ToList()
         }).ToList();

         return recordsList;
     }
     public ClientResponse PostClient(ClientResponse clientResponse)
     {
         var newClient = new Client()
         {
             Id = clientResponse.id,
             Surname = clientResponse.surname,
             NameClient = clientResponse.nameClient,
             MiddleName = clientResponse.middleName,
             PlaceOfBirth = clientResponse.placeOfBirth,
             Nationaly = clientResponse.nationaly,
             Birthday = clientResponse.Birthday,
             FamilyStatus = clientResponse.familyStatus,
             PassportData = clientResponse.PassportData.Select(x => new Passportdatum{Id = x.id, Series = x.series, Number = x.number}).First(),
             Registration = clientResponse.Registration.Select(x => new Registration{Id = x.ID, City = x.City, Street = x.Street, House = x.House, Flat = x.Flat}).First(),
             Cituzenship = clientResponse.Citizenship
         };

         var response = new ClientResponse()
         {
            id = newClient.Id,
            surname = newClient.Surname,
            nameClient = newClient.NameClient,
            middleName = newClient.MiddleName,
            placeOfBirth = newClient.PlaceOfBirth,
            nationaly = newClient.Nationaly,
            Birthday = newClient.Birthday,
            familyStatus = newClient.FamilyStatus,
            PassportData = new List<PassportDataResponse>(){new PassportDataResponse(){id = newClient.PassportData.Id, series = newClient.PassportData.Series, number = newClient.PassportData.Number}},
            Registration = new List<RegistrationResponse>(){new RegistrationResponse(){ID = newClient.Registration.Id, City = newClient.Registration.City, Street = newClient.Registration.Street, House = newClient.Registration.House, Flat = newClient.Registration.Flat}},
            Citizenship = newClient.Cituzenship
         };

         _dbcontext.Clients.Add(newClient);
         _dbcontext.SaveChanges();

         return response;
     }

     public List<PaymentForResponse> GetAllPayments()
     {
         var paymentsList = _dbcontext.Paymentinvoices.ToList();
         var clients = GetAllClients();

         var paymentsResponse = paymentsList.Select(x => new PaymentForResponse()
         {
            Id = x.Id,
            DatePayment = x.DatePayment,
            Price = x.Price,
            Client = clients.Where(q => q.id == x.ClientId).ToList()
         }).ToList();

         return paymentsResponse;
     }

     public List<VisaResponse> GetAllVisa()
     {
         var visaList = _dbcontext.Visas.Include(x => x.Client).ToList();
         var clientsList = GetAllClients();

         var visaResponse = visaList.Select(x => new VisaResponse()
         {
            Id = x.Id,
            Number = x.Number,
            DateStart = x.DateStart,
            DateEnd = x.DateEnd,
            PlaceOfIssue = x.PlaceOfIssue,
            DateOfIssue = x.DateOfIssue,
            Client = clientsList.Where(c => c.id == x.ClientId).ToList()
         }).ToList();

         return visaResponse;
     }
            
     public List<ReqVisaResponse> GetAllReqVisa()
     {
         var reqVisaList = _dbcontext.Requestonvisas.Include(x => x.Client).ToList();
         var clientsList = GetAllClients();

         var response = reqVisaList.Select(x => new ReqVisaResponse()
         {
            Id = x.Id,
            Number = x.Number,
            DateReq = x.DateReq,
            DepartureGoals = x.DepartureGoals,
            ReturnDate = x.ReturnDate,
            Country = x.Country,
            client = clientsList.Where(c => c.id == x.ClientId).ToList()
         }).ToList();

         return response;
     }
     
     public List<ReqIntPassportResponse> GetAllReqIntPassport()
     {
         var reqIntPassportsList = _dbcontext.Requestonintpassports.Include(x => x.Client).ToList();
         var clientsList = GetAllClients();

         var response = reqIntPassportsList.Select(x => new ReqIntPassportResponse()
         {
             Id = x.Id,
             Number = x.Number,
             DateReq = x.DateReq,
             Client = clientsList.Where(c => c.id == x.ClientId).ToList()
         }).ToList();

         return response;
     }
     

}