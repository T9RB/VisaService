using Api_Passport_and_Visa_Service.Model;
using Api_Passport_and_Visa_Service.Model.ForResponse;
using Microsoft.AspNetCore.Mvc;

namespace Api_Passport_and_Visa_Service.Controllers;

[ApiController]
[Route("api/v1/visa/")]
public class ControllerApiVisaApp
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

    [HttpPost]
    [Route("new-client")]
    public ActionResult<ClientResponse> PostClient([FromBody]ClientResponse clientResponse)
    {
        return _service.PostClient(clientResponse);
    }
    
    
}