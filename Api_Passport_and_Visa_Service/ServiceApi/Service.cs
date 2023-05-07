using Api_Passport_and_Visa_Service.ForRequest;
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
         var employee = _dbcontext.Employees.ToList();
         var clients = GetAllClients();
         var post = GetAllPosts();

         var recordsList = records.Select(x => new RecordAppointmentResponse()
         {
            id = x.Id,
            dateAppointment = x.DateAppointment,
            purposeOfAdmission = x.PurposeOfAdmission,
            client = clients.Where(c => c.id == x.ClientId).ToList(),
            employee = employee.
                Select(r => new EmployeeResponse()
                    {
                        Id = r.Id, 
                        Surname = r.Surname, 
                        NameEmp = r.NameEmp, 
                        MiddleName = r.MiddleName, 
                        Birthday = r.Birthday, 
                        Gender = r.Gender, 
                        QualificationLevel = r.QualificationLevel, 
                        Post = post.Where(j => j.Id == r.PostId).ToList()
                        
                    }).Where(k => k.Id == x.EmployeeId).ToList()
         }).ToList();

         return recordsList;
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

     public List<AnswRecordResponse> GetAllAnswerRec()
     {
         var listAnsw = _dbcontext.Answertorecords.ToList();
         var recordList = GetAllRecordAppointmentResponses();

         var response = listAnsw.Select(x => new AnswRecordResponse()
         {
             Id = x.Id,
             Number = x.Number,
             MessageToClient = x.MessageToClient,
             ApplicationStatus = x.ApplicationStatus,
             DateAnswer = x.DateAnswer,
             Record = recordList.Where(c => c.id == x.RecordsId).ToList()
         }).ToList();

         return response;
     }
     
     public List<AnswRecPassport> GetAllAnswerPassport()
     {
         var listAnsw = _dbcontext.Answertoreqpassports.ToList();
         var recordList = GetAllReqIntPassport();

         var response = listAnsw.Select(x => new AnswRecPassport()
         {
             Id = x.Id,
             Number = x.Number,
             MessageToClient = x.MessageToClient,
             ApplicationStatus = x.ApplicationStatus,
             DateAnswer = x.DateAnswer,
             Record = recordList.Where(c => c.Id == x.ReqPassportId).ToList()
         }).ToList();

         return response;
     }
     
     public List<AnswRecVisa> GetAllAnswerVisa()
     {
         var listAnsw = _dbcontext.Answertoreqvisas.ToList();
         var recordList = GetAllReqVisa();

         var response = listAnsw.Select(x => new AnswRecVisa()
         {
             Id = x.Id,
             Number = x.Number,
             MessageToClient = x.MessageToClient,
             ApplicationStatus = x.ApplicationStatus,
             DateAnswer = x.DateAnswer,
             Record = recordList.Where(c => c.Id == x.ReqVisaId).ToList()
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

     public List<PostResponse> GetAllPosts()
     {
         var postList = _dbcontext.PostLists.ToList();

         var response = postList.Select(x => new PostResponse()
         {
            Id = x.Id,
            NamePost = x.NamePost,
            Managet = x.Managet
         }).ToList();

         return response;
     }
     
     public void PostClient(ClientResponse clientResponse)
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

         _dbcontext.Clients.Add(newClient);
         _dbcontext.SaveChanges();
     }
     
     public void PostRecord(RecordAppointmentRequest recordAppointmentRequests)
     {
         var newRecord = new Recordappointment()
         {
             Id = recordAppointmentRequests.id,
             DateAppointment = recordAppointmentRequests.dateAppointment,
             PurposeOfAdmission = recordAppointmentRequests.purposeOfAdmission,
             ClientId = recordAppointmentRequests.ClientId,
             EmployeeId = recordAppointmentRequests.EmployeeId
         };

         _dbcontext.Recordappointments.Add(newRecord);
         _dbcontext.SaveChanges();
     }

     public void PostIntPassport(IntPassportRequest intPassportRequest)
     {
         if (intPassportRequest.DateStart != null && intPassportRequest.DateEnd != null)
         {
             var newIntPassport = new Internationalpassport()
             {
                 Id = intPassportRequest.Id,
                 Series = intPassportRequest.Series,
                 Number = intPassportRequest.Number,
                 ClientId = intPassportRequest.ClientId,
                 DateStart = DateOnly.Parse(intPassportRequest.DateStart),
                 DateEnd = DateOnly.Parse(intPassportRequest.DateEnd),
                 Organization = intPassportRequest.Organization
             };

             _dbcontext.Internationalpassports.Add(newIntPassport);
         }

         _dbcontext.SaveChanges();
     }

     public void PostReqIntPassport(RecordIntPassportRequest recordIntPassportRequest)
     {
         if (recordIntPassportRequest.DateReq != null)
         {
             var newRecIntPassport = new Requestonintpassport()
             {
                 Id = recordIntPassportRequest.Id,
                 Number = recordIntPassportRequest.Number,
                 DateReq = DateOnly.Parse(recordIntPassportRequest.DateReq),
                 ClientId = recordIntPassportRequest.ClientId
             };

             _dbcontext.Requestonintpassports.Add(newRecIntPassport);
         }

         _dbcontext.SaveChanges();
     }

     public void PostReqVisa(ReqVisaRequest reqVisaRequest)
     {
         if (reqVisaRequest.DateReq != null && reqVisaRequest.ReturnDate != null)
         {
             var newRecVisa = new Requestonvisa()
             {
                 Id = reqVisaRequest.Id,
                 Number = reqVisaRequest.Number,
                 DateReq = DateOnly.Parse(reqVisaRequest.DateReq),
                 ClientId = reqVisaRequest.ClientId,
                 DepartureGoals = reqVisaRequest.DepartureGoals,
                 ReturnDate = DateOnly.Parse(reqVisaRequest.ReturnDate),
                 Country = reqVisaRequest.Country
             };

             _dbcontext.Requestonvisas.Add(newRecVisa);
         }

         _dbcontext.SaveChanges();
     }

     public void PostAnswerAppointment(AnswerToRecordRequest answerToRecordRequest)
     {
         if (answerToRecordRequest.DateAnswer != null)
         {
             var newAnswer = new Answertorecord()
             {
                 Id = answerToRecordRequest.Id,
                 Number = answerToRecordRequest.Number,
                 RecordsId = answerToRecordRequest.RecordsId,
                 MessageToClient = answerToRecordRequest.MessageToClient,
                 ApplicationStatus = answerToRecordRequest.ApplicationStatus,
                 DateAnswer = DateOnly.Parse(answerToRecordRequest.DateAnswer)
             };

             _dbcontext.Answertorecords.Add(newAnswer);
         }

         _dbcontext.SaveChanges();
     }

     public void PostAnswerReqIntPassport(AnswerIntPasportRequest answerIntPasportRequest)
     {
         if (answerIntPasportRequest.DateAnswer != null)
         {
             var newAnswer = new Answertoreqpassport()
             {
                 Id = answerIntPasportRequest.Id,
                 Number = answerIntPasportRequest.Number,
                 ReqPassportId = answerIntPasportRequest.ReqPassportId,
                 MessageToClient = answerIntPasportRequest.MessageToClient,
                 ApplicationStatus = answerIntPasportRequest.ApplicationStatus,
                 DateAnswer = DateOnly.Parse(answerIntPasportRequest.DateAnswer)
             };

             _dbcontext.Answertoreqpassports.Add(newAnswer);
         }

         _dbcontext.SaveChanges();
     }

     public void PostAnswerReqVisa(AnswerToVisaRequest answerToVisaRequest)
     {
         if (answerToVisaRequest.DateAnswer != null)
         {
             var newAnswer = new Answertoreqvisa()
             {
                 Id = answerToVisaRequest.Id,
                 Number = answerToVisaRequest.Number,
                 ReqVisaId = answerToVisaRequest.ReqVisaId,
                 MessageToClient = answerToVisaRequest.MessageToClient,
                 ApplicationStatus = answerToVisaRequest.ApplicationStatus,
                 DateAnswer = DateOnly.Parse(answerToVisaRequest.DateAnswer),
             };

             _dbcontext.Answertoreqvisas.Add(newAnswer);
         }

         _dbcontext.SaveChanges();
     }

     public void PostPayment(PaymentRequest paymentRequest)
     {
         var newPayment = new Paymentinvoice()
         {
            Id = paymentRequest.Id,
            DatePayment = DateOnly.Parse(paymentRequest.DatePayment),
            ClientId = paymentRequest.ClientId,
            Price = paymentRequest.Price
         };

         _dbcontext.Paymentinvoices.Add(newPayment);
         _dbcontext.SaveChanges();
     }
}