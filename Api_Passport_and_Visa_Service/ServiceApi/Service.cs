using System.Security.Cryptography;
using System.Text;
using Api_Passport_and_Visa_Service.Cryptografy;
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
    
     public async Task<List<ClientResponse>> GetAllClients()
     {
         var clients =  await _dbcontext.Clients.ToListAsync();
         var passData = await _dbcontext.Passportdata.ToListAsync();
         var reg = await _dbcontext.Registrations.ToListAsync();
         
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

         var clietnsListSorted = clientsList.OrderBy(q => q.id).ToList();
         
         return clietnsListSorted;
     }
     
     
     public async  Task<List<DepartureCountryResponse>> GetAllDeparture()
     {
         var depart = _dbcontext.Departurecountries.ToList();
         var clients = await GetAllClients();
     
         var depList = depart.Select(x => new DepartureCountryResponse()
         {
             id = x.Id,
             dateDeparture = x.DateDeparture,
             client = clients.Where(c => c.id == x.ClientId).ToList()
         }).ToList();
     
         return depList;
     }
     
     public async Task<List<InternationalPassportResponse>> GetAllPassportsInt()
     {
         var passport = _dbcontext.Internationalpassports.ToList();
         var clients = await GetAllClients();
     
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
     
     public async Task<List<PassportDataResponse>> GetAllPassports()
     {
         var passport = await _dbcontext.Passportdata.ToListAsync();

         var passportDataResp = passport.Select(x => new PassportDataResponse()
         {
             id = x.Id,
             series = x.Series,
             number = x.Number
         }).ToList();
         
         return passportDataResp;
     }

     public async Task<bool> CheckPassportData(string series, string number)
     {
         if (series.Length == 4 && number.Length == 6)
         {
             var passportData = await _dbcontext.Passportsdatafromapis
                 .FirstOrDefaultAsync(x => x.Number == number && x.Series == series);
             if (passportData != null || passportData != default)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         else
         {
             return false;
         }
     }

     public async Task<List<RecordAppointmentResponse>> GetAllRecordAppointmentResponses()
     {
         var records = await _dbcontext.Recordappointments.ToListAsync();
         var employee = await _dbcontext.Employees.ToListAsync();
         var clients = await GetAllClients();
         var post = await GetAllPosts();

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

     public async Task<List<PaymentForResponse>> GetAllPayments()
     {
         var paymentsList = await _dbcontext.Paymentinvoices.ToListAsync();
         var clients = await GetAllClients();

         var paymentsResponse = paymentsList.Select(x => new PaymentForResponse()
         {
            Id = x.Id,
            DatePayment = x.DatePayment,
            Price = x.Price,
            Client = clients.Where(q => q.id == x.ClientId).ToList()
         }).ToList();

         return paymentsResponse;
     }

     public async Task<List<VisaResponse>> GetAllVisa()
     {
         var visaList = await _dbcontext.Visas.Include(x => x.Client).ToListAsync();
         var clientsList = await GetAllClients();

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
            
     public async Task<List<ReqVisaResponse>> GetAllReqVisa()
     {
         var reqVisaList = await _dbcontext.Requestonvisas.Include(x => x.Client).ToListAsync();
         var clientsList = await GetAllClients();

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

     public async Task<List<AnswRecordResponse>> GetAllAnswerRec()
     {
         var listAnsw = await _dbcontext.Answertorecords.ToListAsync();
         var recordList = await GetAllRecordAppointmentResponses();

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
     
     public async Task<List<AnswRecPassport>> GetAllAnswerPassport()
     {
         var listAnsw = await _dbcontext.Answertoreqpassports.ToListAsync();
         var recordList = await GetAllReqIntPassport();

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
     
     public async Task<List<AnswRecVisa>> GetAllAnswerVisa()
     {
         var listAnsw = await _dbcontext.Answertoreqvisas.ToListAsync();
         var recordList = await GetAllReqVisa();

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

     public async Task<List<ReqIntPassportResponse>> GetAllReqIntPassport()
     {
         var reqIntPassportsList = await _dbcontext.Requestonintpassports.Include(x => x.Client).ToListAsync();
         var clientsList = await GetAllClients();

         var response = reqIntPassportsList.Select(x => new ReqIntPassportResponse()
         {
             Id = x.Id,
             Number = x.Number,
             DateReq = x.DateReq,
             Client = clientsList.Where(c => c.id == x.ClientId).ToList()
         }).ToList();

         return response;
     }

     public async Task<List<PostResponse>> GetAllPosts()
     {
         var postList = await _dbcontext.PostLists.ToListAsync();

         var response = postList.Select(x => new PostResponse()
         {
            Id = x.Id,
            NamePost = x.NamePost,
            Managet = x.Managet
         }).ToList();

         return response;
     }
     
     public async Task PostClient(ClientResponse clientResponse, int idAccount)
     {
         var series = clientResponse.PassportData.Select(x => x.series);
         var number = clientResponse.PassportData.Select(x => x.number);
         var checkPassportDataClient = await CheckPassportData(number.ToString(), series.ToString());
         if (checkPassportDataClient)
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

             await _dbcontext.Clients.AddAsync(newClient);
             await _dbcontext.SaveChangesAsync();
             
             
         }
         
     }
     
     public async Task PostRecord(RecordAppointmentRequest recordAppointmentRequests)
     {
         var newRecord = new Recordappointment()
         {
             Id = recordAppointmentRequests.id,
             DateAppointment = recordAppointmentRequests.dateAppointment,
             PurposeOfAdmission = recordAppointmentRequests.purposeOfAdmission,
             ClientId = recordAppointmentRequests.ClientId,
             EmployeeId = recordAppointmentRequests.EmployeeId
         };

         await _dbcontext.Recordappointments.AddAsync(newRecord);
         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostIntPassport(IntPassportRequest intPassportRequest)
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

         await _dbcontext.Internationalpassports.AddAsync(newIntPassport);

         await  _dbcontext.SaveChangesAsync();
     }

     public async Task PostReqIntPassport(RecordIntPassportRequest recordIntPassportRequest)
     {
         var newRecIntPassport = new Requestonintpassport()
         {
             Id = recordIntPassportRequest.Id,
             Number = recordIntPassportRequest.Number,
             DateReq = DateOnly.Parse(recordIntPassportRequest.DateReq),
             ClientId = recordIntPassportRequest.ClientId
         };

         await _dbcontext.Requestonintpassports.AddAsync(newRecIntPassport);

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostReqVisa(ReqVisaRequest reqVisaRequest)
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

         await _dbcontext.Requestonvisas.AddAsync(newRecVisa);

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostAnswerAppointment(AnswerToRecordRequest answerToRecordRequest)
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

         await _dbcontext.Answertorecords.AddAsync(newAnswer);
         
         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostAnswerReqIntPassport(AnswerIntPasportRequest answerIntPasportRequest)
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

         await _dbcontext.Answertoreqpassports.AddAsync(newAnswer);

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostAnswerReqVisa(AnswerToVisaRequest answerToVisaRequest)
     {
         var newAnswer = new Answertoreqvisa()
         {
             Id = answerToVisaRequest.Id,
             Number = answerToVisaRequest.Number,
             ReqVisaId = answerToVisaRequest.ReqVisaId,
             MessageToClient = answerToVisaRequest.MessageToClient,
             ApplicationStatus = answerToVisaRequest.ApplicationStatus,
             DateAnswer = DateOnly.Parse(answerToVisaRequest.DateAnswer)
         };

         await _dbcontext.Answertoreqvisas.AddAsync(newAnswer);

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PostPayment(PaymentRequest paymentRequest)
     {
         var newPayment = new Paymentinvoice()
         {
            Id = paymentRequest.Id,
            DatePayment = DateOnly.Parse(paymentRequest.DatePayment),
            ClientId = paymentRequest.ClientId,
            Price = paymentRequest.Price
         };

         await _dbcontext.Paymentinvoices.AddAsync(newPayment);
         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutClient(int id, ClientResponse clientResponse)
     {
         var findClient = await _dbcontext.Clients.FirstOrDefaultAsync(x => x.Id == id);

         findClient.Surname = clientResponse.surname;
         findClient.NameClient = clientResponse.nameClient;
         findClient.MiddleName = clientResponse.middleName;
         findClient.PlaceOfBirth = clientResponse.placeOfBirth;
         findClient.Nationaly = clientResponse.nationaly;
         findClient.Birthday = clientResponse.Birthday;
         findClient.FamilyStatus = clientResponse.familyStatus;
         
         var pData = clientResponse.PassportData
             .Select(x => new Passportdatum {Id = x.id, Series = x.series, Number = x.number}).First();
         findClient.PassportData = pData;
         var reg = clientResponse.Registration.Select(x => new Registration
             {Id = x.ID, City = x.City, Street = x.Street, House = x.House, Flat = x.Flat}).First();
         findClient.Registration = reg;
         findClient.Cituzenship = clientResponse.Citizenship;

         await _dbcontext.SaveChangesAsync();
     }


     public async Task PutRecordAppointment(int id, RecordAppointmentRequest recordAppointmentRequest)
     {
         var findRecord = await _dbcontext.Recordappointments.FirstOrDefaultAsync(x => x.Id == id);

         findRecord.DateAppointment = recordAppointmentRequest.dateAppointment;
         findRecord.PurposeOfAdmission = recordAppointmentRequest.purposeOfAdmission;
         findRecord.ClientId = recordAppointmentRequest.ClientId;
         findRecord.EmployeeId = recordAppointmentRequest.EmployeeId;

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutIntPassport(int id, IntPassportRequest intPassportRequest)
     {
         var findPassport = await _dbcontext.Internationalpassports.FirstOrDefaultAsync(x => x.Id == id);

         findPassport.Series = intPassportRequest.Series;
         findPassport.Number = intPassportRequest.Number;
         findPassport.ClientId = intPassportRequest.ClientId;
         findPassport.DateStart = DateOnly.Parse(intPassportRequest.DateStart);
         findPassport.DateEnd = DateOnly.Parse(intPassportRequest.DateEnd);
         findPassport.Organization = intPassportRequest.Organization;

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutRecordIntPassport(int id, [FromBody] RecordIntPassportRequest recordIntPassportRequest)
     {
         var findReq = await _dbcontext.Requestonintpassports.FirstOrDefaultAsync(x => x.Id == id);

         findReq.Number = recordIntPassportRequest.Number;
         findReq.DateReq = DateOnly.Parse(recordIntPassportRequest.DateReq);
         findReq.ClientId = recordIntPassportRequest.ClientId;

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutRecordVisa(int id, [FromBody]ReqVisaRequest reqVisaRequest)
     {
         var findReq = await _dbcontext.Requestonvisas.FirstOrDefaultAsync(x => x.Id == id);

         findReq.Number = reqVisaRequest.Number;
         findReq.DateReq = DateOnly.Parse(reqVisaRequest.DateReq);
         findReq.ClientId = reqVisaRequest.ClientId;
         findReq.DepartureGoals = reqVisaRequest.DepartureGoals;
         findReq.DepartureGoals = reqVisaRequest.DepartureGoals;
         findReq.ReturnDate = DateOnly.Parse(reqVisaRequest.ReturnDate);
         findReq.Country = reqVisaRequest.Country;

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutAnswerAppointment(int id, [FromBody]AnswerToRecordRequest answerToRecordRequest)
     {
         var findReq = await _dbcontext.Answertorecords.FirstOrDefaultAsync(x => x.Id == id);

         findReq.Number = answerToRecordRequest.Number;
         findReq.RecordsId = answerToRecordRequest.RecordsId;
         findReq.MessageToClient = answerToRecordRequest.MessageToClient;
         findReq.ApplicationStatus = answerToRecordRequest.ApplicationStatus;
         findReq.DateAnswer = DateOnly.Parse(answerToRecordRequest.DateAnswer);

         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task PutAnswerVisa(int id, [FromBody]AnswerToVisaRequest answerToRecordRequest)
     {
         var findReq = await _dbcontext.Answertoreqvisas.FirstOrDefaultAsync(x => x.Id == id);

         findReq.Number = answerToRecordRequest.Number;
         findReq.ReqVisaId = answerToRecordRequest.ReqVisaId;
         findReq.MessageToClient = answerToRecordRequest.MessageToClient;
         findReq.ApplicationStatus = answerToRecordRequest.ApplicationStatus;
         findReq.DateAnswer = DateOnly.Parse(answerToRecordRequest.DateAnswer);

         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task PutAnswerIntPassport(int id, [FromBody]AnswerIntPasportRequest answerToRecordRequest)
     {
         var findReq = await _dbcontext.Answertoreqpassports.FirstOrDefaultAsync(x => x.Id == id);

         findReq.Number = answerToRecordRequest.Number;
         findReq.ReqPassportId = answerToRecordRequest.ReqPassportId;
         findReq.MessageToClient = answerToRecordRequest.MessageToClient;
         findReq.ApplicationStatus = answerToRecordRequest.ApplicationStatus;
         findReq.DateAnswer = DateOnly.Parse(answerToRecordRequest.DateAnswer);

         await _dbcontext.SaveChangesAsync();
     }

     public async Task PutPayment(int id, [FromBody]PaymentRequest paymentRequest)
     {
         var findPayment = await _dbcontext.Paymentinvoices.FirstOrDefaultAsync(x => x.Id == id);
         
         findPayment.DatePayment = DateOnly.Parse(paymentRequest.DatePayment);
         findPayment.ClientId = paymentRequest.ClientId;
         findPayment.Price = paymentRequest.Price;
     }

     public async Task DeleteClient(int id)
     {
         var findObject = await _dbcontext.Clients.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Clients.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteRecordAppointment(int id)
     {
         var findObject = await _dbcontext.Recordappointments.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Recordappointments.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteIntPassport(int id)
     {
         var findObject = await _dbcontext.Internationalpassports.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Internationalpassports.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteRecordIntPassport(int id)
     {
         var findObject = await _dbcontext.Requestonintpassports.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Requestonintpassports.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteRecordVisa(int id)
     {
         var findObject = await _dbcontext.Requestonvisas.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Requestonvisas.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteAnswerAppointment(int id)
     {
         var findObject = await _dbcontext.Answertorecords.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Answertorecords.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteAnswerVisa(int id)
     {
         var findObject = await _dbcontext.Answertoreqvisas.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Answertoreqvisas.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeleteAnswerPassport(int id)
     {
         var findObject = await _dbcontext.Answertoreqpassports.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Answertoreqpassports.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }
     
     public async Task DeletePayment(int id)
     {
         var findObject = await _dbcontext.Paymentinvoices.FirstOrDefaultAsync(x => x.Id == id);

         _dbcontext.Paymentinvoices.Remove(findObject);
         await _dbcontext.SaveChangesAsync();
     }

     public async Task<AuthorizationResponse> CheckAuthorization(string login, string password)
     {
         var hashPassword = await HashPassword(password);
         var findUser = await _dbcontext.Usersdata.FirstOrDefaultAsync(x => x.Login == login && x.Password == hashPassword);
         


         if (findUser != null || findUser != default)
         {
             string status = "Success";
             AuthorizationResponse authorizationResponse = new AuthorizationResponse(){dateAuthorization = DateTime.Today, status = status, access = true, accountID = findUser.Id};
             var session = new Authorizationsession() { Dateauthorization = DateTime.Today.ToString(), Status = status, Access = true, Accountsid = findUser.Id};
             await _dbcontext.Authorizationsessions.AddAsync(session);
             await _dbcontext.SaveChangesAsync();
             return authorizationResponse;
         }
         else
         {
             string status = "Error";
             AuthorizationResponse authorizationResponse = new AuthorizationResponse(){dateAuthorization = DateTime.Now, status = status, access = false, accountID = 0};
             return authorizationResponse;
         }
     }
     
     public async Task PostUser(string login, string password)
     {
         string hashPassword = await HashPassword(password);
         string status = "Success";
         
         var newUser = new Usersdatum()
         {
             Login = login,
             Password = hashPassword
         };
         
         await _dbcontext.Usersdata.AddAsync(newUser);
         await _dbcontext.SaveChangesAsync();
         
         var findUser = _dbcontext.Usersdata.FirstOrDefaultAsync(x => x.Login == login && x.Password == hashPassword);
         if (findUser != null || findUser != default)
         {
             var session = new Authorizationsession() { Dateauthorization = DateTime.Today.ToString(), Status = status, Access = true, Accountsid = findUser.Id};
             await _dbcontext.Authorizationsessions.AddAsync(session);
             await _dbcontext.SaveChangesAsync();
         }
     }
     public async Task<string> HashPassword(string password)
     {
         MD5 md5 = MD5.Create();
         byte[] bytes = Encoding.ASCII.GetBytes(password);
             
         byte[] hash = md5.ComputeHash(bytes);
             
         StringBuilder stringBuilder = new StringBuilder();
         foreach (var hashByte in hash)
         {
             stringBuilder.Append(hashByte.ToString("X2"));
         }

         return Convert.ToString(stringBuilder);
         
         /*bool checkSecondary = await SecondaryTest(password);
         if (checkSecondary)
         {
             MD5 md5 = MD5.Create();
             byte[] bytes = Encoding.ASCII.GetBytes(password);
             
             int sizeSalt = await GenerateSizeSalt(bytes.Length);
             var salt = await GenerateSalt(sizeSalt);
             
             byte[] hash = md5.ComputeHash(bytes);


             StringBuilder stringBuilder = new StringBuilder();
             foreach (var hashByte in hash)
             {
                 stringBuilder.Append(hashByte.ToString("X2"));
             }

             return Convert.ToString(stringBuilder + salt);
         }
         else
         {
             MD5 md5 = MD5.Create();
             byte[] bytes = Encoding.ASCII.GetBytes(password);
             
             byte[] hash = md5.ComputeHash(bytes);
             
             StringBuilder stringBuilder = new StringBuilder();
             foreach (var hashByte in hash)
             {
                 stringBuilder.Append(hashByte.ToString("X2"));
             }

             return Convert.ToString(stringBuilder);
         }*/
     }
     
     /*public async Task<string> GenerateSalt(int size)
     {
         var salt = new byte[size];
         using (var rng = new RNGCryptoServiceProvider())
         {
             rng.GetBytes(salt);
         }
         
         StringBuilder stringBuilder = new StringBuilder();
         foreach (var hashByte in salt)
         {
             stringBuilder.Append(hashByte.ToString("X2"));
         }
         return Convert.ToString(stringBuilder);
     }*/

     /*public async Task<int> GenerateSizeSalt(int number)
     {
         Random rnd = new Random();
         int randomSize = rnd.Next(number);

         return randomSize;
     }

     public async Task<bool> SecondaryTest(string password)
     {
         var hashPassword = await HashPassword(password);

         var findPassword =  _dbcontext.Usersdata.Where(x => x.Password == hashPassword).ToList();

         if (findPassword.Count > 1)
         {
             return true;
         }
         else
         {
             return false;
         }
     }*/
}