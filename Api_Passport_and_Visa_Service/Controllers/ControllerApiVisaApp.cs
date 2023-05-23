using System.Runtime.InteropServices;
using Api_Passport_and_Visa_Service.Authentication;
using Api_Passport_and_Visa_Service.ForRequest;
using Api_Passport_and_Visa_Service.Model;
using Api_Passport_and_Visa_Service.Model.ForResponse;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Passport_and_Visa_Service.Controllers;

[ApiController]
[Route("api/v1/visa/")]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ControllerApiVisaApp : ControllerBase
{
    private Service.Service _service;

    public ControllerApiVisaApp(Service.Service _apiService)
    {
        _service = _apiService;
    }
    
    [HttpGet]
    [Route("clients")]
    public async Task<ActionResult<List<ClientResponse>>> GetClients()
    {
        try
        {
            return await _service.GetAllClients();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("int-passports")]
    public async Task<ActionResult<List<InternationalPassportResponse>>> GetIntPassports()
    {
        try
        {
            return await _service.GetAllPassportsInt();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("passports-data")]
    public async Task<ActionResult<List<PassportDataResponse>>> GetAllPassportDataClients()
    {
        try
        {
            return await _service.GetAllPassports();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("records-appointment")]
    public async Task<ActionResult<List<RecordAppointmentResponse>>> GetAllRecords()
    {
        try
        {
            return await _service.GetAllRecordAppointmentResponses();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("departure-country")]
    public async Task<ActionResult<List<DepartureCountryResponse>>> GetAllDepCountries()
    {
        try
        {
            return await _service.GetAllDeparture();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("payments")]
    public async Task<ActionResult<List<PaymentForResponse>>> GetAllPayments()
    {
        try
        {
            return await _service.GetAllPayments();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("visa-list")]
    public async Task<ActionResult<List<VisaResponse>>> GetAllVisas()
    {
        try
        {
            return await _service.GetAllVisa();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("req-visa")]
    public async Task<ActionResult<List<ReqVisaResponse>>> GetAllReqVisa()
    {
        try
        {
            return await _service.GetAllReqVisa();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }
    
    [HttpGet]
    [Route("req-int-passport")]
    public async Task<ActionResult<List<ReqIntPassportResponse>>> GetAllReqIntPassport()
    {
        try
        {
            return await _service.GetAllReqIntPassport();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }
    
    [HttpGet]
    [Route("rec-answ")]
    public async Task<ActionResult<List<AnswRecordResponse>>> GetAllAnswersOnRecord()
    {
        try
        {
            return await _service.GetAllAnswerRec();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }

    [HttpGet]
    [Route("check-passport-data/series={series}&number={number}")]
    public async Task<ActionResult<bool>> GetCheckPassportData(string series, string number)
    {
        try
        {
            return await _service.CheckPassportData(series, number);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("passport-answ")]
    public async Task<ActionResult<List<AnswRecPassport>>> GetAllAnswersOnRecPassport()
    {
        try
        {
            return await _service.GetAllAnswerPassport();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }
    
    [HttpGet]
    [Route("visa-answ")]
    public async Task<ActionResult<List<AnswRecVisa>>> GetAllAnswersOnRecVisa()
    {
        try
        {
            return await _service.GetAllAnswerVisa();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }
    
    [HttpGet]
    [Route("posts")]
    public async Task<ActionResult<List<PostResponse>>> GetAllPosts()
    {
        try
        {
            return await _service.GetAllPosts();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
        
    }

    [HttpGet]
    [Route("check-authorization/login={login}/password={password}")]
    public async Task<ActionResult<AuthorizationResponse>> CheckAuthorization(string login, string password)
    {
        try
        {
            return await _service.CheckAuthorization(login, password);
        }
        catch (Exception e)
        {
            return StatusCode(400);
        }

    }

    [HttpPost]
    [Route(("new-user/login={login}&password={password}"))]
    public async Task<IActionResult> PostUser(string login, string password)
    {
        try
        {
            await _service.PostUser(login, password);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("new-client/number-user={number:int}")]
    public async Task<IActionResult> PostClient([FromBody]ClientResponse clientResponse, int number)
    {
        try
        {
            await _service.PostClient(clientResponse, number);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-record-appointment")]
    public async Task<IActionResult> PostRecordAppointment([FromBody]RecordAppointmentRequest recordAppointmentRequest)
    {
        try
        {
            await _service.PostRecord(recordAppointmentRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-int-passport")]
    public async Task<IActionResult> PostIntPassport([FromBody]IntPassportRequest intPassportRequest)
    {
        try
        {
            await _service.PostIntPassport(intPassportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
       
    }
    
    [HttpPost]
    [Route("new-record-int-passport")]
    public async Task<IActionResult> PostIntPassportRec([FromBody]RecordIntPassportRequest recordIntPassportRequest)
    {
        try
        {
            await _service.PostReqIntPassport(recordIntPassportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-record-visa")]
    public async Task<IActionResult> PostRecVisa([FromBody]ReqVisaRequest reqVisaRequest)
    {
        try
        {
            await _service.PostReqVisa(reqVisaRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-answer-appointment")]
    public async Task<IActionResult> PostAnswerRec([FromBody]AnswerToRecordRequest answerToRecordRequest)
    {
        try
        {
            await _service.PostAnswerAppointment(answerToRecordRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-answer-visa")]
    public async Task<IActionResult> PostAnswerVisa([FromBody]AnswerToVisaRequest answerToRecordRequest)
    {
        try
        {
            await _service.PostAnswerReqVisa(answerToRecordRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    [Route("new-answer-passport-req")]
    public async Task<IActionResult> PostAnswerPassport([FromBody]AnswerIntPasportRequest answerIntPassportRequest)
    {
        try
        {
            await _service.PostAnswerReqIntPassport(answerIntPassportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("new-payment")]
    public async Task<IActionResult> PostPayment([FromBody]PaymentRequest paymentRequest)
    {
        try
        {
            await _service.PostPayment(paymentRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        
    }
    
    

    [HttpPut]
    [Route("put-client&id={id:int}")]
    public async Task<IActionResult> PutClient(int id, [FromBody] ClientResponse clientResponse)
    {
        try
        {
            await _service.PutClient(id, clientResponse);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-record&id={id:int}")]
    public async Task<IActionResult> PutRecord(int id, [FromBody]RecordAppointmentRequest appointmentRequest)
    {
        try
        {
            await _service.PutRecordAppointment(id, appointmentRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-int-passport&id={id:int}")]
    public async Task<IActionResult> PutIntPassport(int id, [FromBody]IntPassportRequest intPassportRequest)
    {
        try
        {
            await _service.PutIntPassport(id, intPassportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-record-int-passport&id={id:int}")]
    public async Task<IActionResult> PutRecordIntPassport(int id, [FromBody]RecordIntPassportRequest recordIntPassportRequest)
    {
        try
        {
            await _service.PutRecordIntPassport(id, recordIntPassportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-record-visa&id={id:int}")]
    public async Task<IActionResult> PutRecordVisa(int id, [FromBody]ReqVisaRequest reqVisaRequest)
    {
        try
        {
            await _service.PutRecordVisa(id, reqVisaRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-answer-appointment&id={id:int}")]
    public async Task<IActionResult> PutAnswerAppointment(int id, [FromBody]AnswerToRecordRequest answerToRecordRequest)
    {
        try
        {
            await _service.PutAnswerAppointment(id, answerToRecordRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-answer-visa&id={id:int}")]
    public async Task<IActionResult> PutAnswerVisa(int id, [FromBody]AnswerToVisaRequest answerToRecordRequest)
    {
        try
        {
            await _service.PutAnswerVisa(id, answerToRecordRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-answer-int-passport&id={id:int}")]
    public async Task<IActionResult> PutAnswerIntPassport(int id, [FromBody]AnswerIntPasportRequest answerIntPasportRequest)
    {
        try
        {
            await _service.PutAnswerIntPassport(id, answerIntPasportRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("put-payment&id={id:int}")]
    public async Task<IActionResult> PutPayment(int id, [FromBody]PaymentRequest paymentRequest)
    {
        try
        {
            await _service.PutPayment(id, paymentRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("delete-client&id={id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            await _service.DeleteClient(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-record&id={id:int}")]
    public async Task<IActionResult> DeleteRecord(int id)
    {
        try
        {
            await _service.DeleteRecordAppointment(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-int-passport&id={id:int}")]
    public async Task<IActionResult> DeleteIntPassport(int id)
    {
        try
        {
            await _service.DeleteIntPassport(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-record-passport&id={id:int}")]
    public async Task<IActionResult> DeleteRecordPassport(int id)
    {
        try
        {
            await _service.DeleteRecordIntPassport(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-record-visa&id={id:int}")]
    public async Task<IActionResult> DeleteRecordVisa(int id)
    {
        try
        {
            await _service.DeleteRecordVisa(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-answer-appointment&id={id:int}")]
    public async Task<IActionResult> DeleteAnswerAppointment(int id)
    {
        try
        {
            await _service.DeleteAnswerAppointment(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-answer-visa&id={id:int}")]
    public async Task<IActionResult> DeleteAnswerVisa(int id)
    {
        try
        {
            await _service.DeleteAnswerVisa(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-answer-passport&id={id:int}")]
    public async Task<IActionResult> DeleteAnswerPassport(int id)
    {
        try
        {
            await _service.DeleteAnswerPassport(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete-payment&id={id:int}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        try
        {
            await _service.DeletePayment(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}