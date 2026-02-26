using DiriAPI.Services.MasterSchemaServices;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{    
    [ApiController]
    public class CountryController : ControllerBase        
    {
        private CountryServices _service;
        public CountryController(CountryServices service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetAllCountryList")]
        [HttpGet]
        public CountryRespDTO GetAllCountryList()
        {
            return _service.GetAllCountryList();
        }
    }
}
