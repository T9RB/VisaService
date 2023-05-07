using System.Runtime.InteropServices;
using Api_Passport_and_Visa_Service.ForRequest;
using Api_Passport_and_Visa_Service.Model;
using Api_Passport_and_Visa_Service.Model.ForResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Passport_and_Visa_Service.Controllers;

[ApiController]
[Route("api/v1/visa/")]
public class ControllerApiVisaApp : ControllerBase
{
    private Service.Service _service;

    public ControllerApiVisaApp(Service.Service _apiService)
    {
        _service = _apiService;
    }
    
    [HttpGet]
    [Route("clients")]
    public ActionResult<List<ClientResponse>> GetClient()
    {
        return _service.GetAllClients();
    }
    
    [HttpGet]
    [Route("int-passports")]
    public ActionResult<List<InternationalPassportResponse>> GetIntPassports()
    {
        return _service.GetAllPassportsInt();
    }
    
    [HttpGet]
    [Route("passports-data")]
    public ActionResult<List<PassportDataResponse>> GetAllPassportDataClients()
    {
        return _service.GetAllPassports();
    }
    
    [HttpGet]
    [Route("records-appointment")]
    public ActionResult<List<RecordAppointmentResponse>> GetAllRecords()
    {
        return _service.GetAllRecordAppointmentResponses();
    }
    
    [HttpGet]
    [Route("departure-country")]
    public ActionResult<List<DepartureCountryResponse>> GetAllDepCountries()
    {
        return _service.GetAllDeparture();
    }
    
    [HttpGet]
    [Route("payments")]
    public ActionResult<List<PaymentForResponse>> GetAllPayments()
    {
        return _service.GetAllPayments();
    }
    
    [HttpGet]
    [Route("visa-list")]
    public ActionResult<List<VisaResponse>> GetAllVisas()
    {
        return _service.GetAllVisa();
    }
    
    [HttpGet]
    [Route("req-visa")]
    public ActionResult<List<ReqVisaResponse>> GetAllReqVisa()
    {
        return _service.GetAllReqVisa();
    }
    
    [HttpGet]
    [Route("req-int-passport")]
    public ActionResult<List<ReqIntPassportResponse>> GetAllReqIntPassport()
    {
        return _service.GetAllReqIntPassport();
    }
    
    [HttpGet]
    [Route("rec-answ")]
    public ActionResult<List<AnswRecordResponse>> GetAllAnswersOnRecord()
    {
        return _service.GetAllAnswerRec();
    }
    
    [HttpGet]
    [Route("passport-answ")]
    public ActionResult<List<AnswRecPassport>> GetAllAnswersOnRecPassport()
    {
        return _service.GetAllAnswerPassport();
    }
    
    [HttpGet]
    [Route("visa-answ")]
    public ActionResult<List<AnswRecVisa>> GetAllAnswersOnRecVisa()
    {
        return _service.GetAllAnswerVisa();
    }
    
    [HttpGet]
    [Route("posts")]
    public ActionResult<List<PostResponse>> GetAllPosts()
    {
        return _service.GetAllPosts();
    }

    [HttpPost]
    [Route("new-client")]
    public IActionResult PostClient([FromBody]ClientResponse clientResponse)
    {
        _service.PostClient(clientResponse);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-record-appointment")]
    public IActionResult PostRecordAppointment([FromBody]RecordAppointmentRequest recordAppointmentRequest)
    {
        _service.PostRecord(recordAppointmentRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-int-passport")]
    public IActionResult PostIntPassport([FromBody]IntPassportRequest intPassportRequest)
    {
        _service.PostIntPassport(intPassportRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-record-int-passport")]
    public IActionResult PostIntPassportRec([FromBody]RecordIntPassportRequest recordIntPassportRequest)
    {
        _service.PostReqIntPassport(recordIntPassportRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-record-visa")]
    public IActionResult PostRecVisa([FromBody]ReqVisaRequest reqVisaRequest)
    {
        _service.PostReqVisa(reqVisaRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-answer-appointment")]
    public IActionResult PostAnswerRec([FromBody]AnswerToRecordRequest answerToRecordRequest)
    {
        _service.PostAnswerAppointment(answerToRecordRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-answer-visa")]
    public IActionResult PostAnswerVisa([FromBody]AnswerToVisaRequest answerToRecordRequest)
    {
        _service.PostAnswerReqVisa(answerToRecordRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-answer-appointment")]
    public IActionResult PostAnswerPassport([FromBody]AnswerIntPasportRequest answerIntPasportRequest)
    {
        _service.PostAnswerReqIntPassport(answerIntPasportRequest);
        return Ok();
    }
    
    [HttpPost]
    [Route("new-payment")]
    public IActionResult PostPayment([FromBody]PaymentRequest paymentRequest)
    {   
        _service.PostPayment(paymentRequest);
        return Ok();
    }
    
    
}