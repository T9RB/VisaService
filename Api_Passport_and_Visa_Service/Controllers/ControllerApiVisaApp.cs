using Api_Passport_and_Visa_Service.Model;
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
    public ActionResult<List<Client>> GetClient()
    {
        return _service.GetAllClients();
    }
    
    [HttpGet]
    [Route("employees")]
    public ActionResult<List<Employee>> GetEmployee()
    {
        return _service.GetAllEmployees();
    }
    
    [HttpGet]
    [Route("departures")]
    public ActionResult<List<DepartureCountry>> GetDepart()
    {
        return _service.GetAllDeparture();
    }
    
    [HttpGet]
    [Route("intpassports")]
    public ActionResult<List<InternationalPassport>> GetIntPassports()
    {
        return _service.GetAllPassportsInt();
    }
    
}