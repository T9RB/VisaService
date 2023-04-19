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
    [Route("intpassports")]
    public ActionResult<List<InternationalPassportResponse>> GetIntPassports()
    {
        return _service.GetAllPassportsInt();
    }
    
    [HttpGet]
    [Route("passportsdata")]
    public ActionResult<List<PassportDataResponse>> GetAllPassportDataClients()
    {
        return _service.GetAllPassports();
    }
    
    [HttpGet]
    [Route("recordsappointment")]
    public ActionResult<List<RecordAppointmentResponse>> GetAllRecords()
    {
        return _service.GetAllRecordAppointmentResponses();
    }
    
    [HttpGet]
    [Route("departurecountry")]
    public ActionResult<List<DepartureCountryResponse>> GetAllDepCountries()
    {
        return _service.GetAllDeparture();
    }
    
    [HttpPost]
    [Route("newclient")]
    public ActionResult<ClientResponse> PostClient([FromBody]ClientResponse clientResponse)
    {
        return _service.PostClient(clientResponse);
    }
    
}