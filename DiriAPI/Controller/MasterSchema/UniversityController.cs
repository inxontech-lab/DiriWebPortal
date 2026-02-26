using DiriAPI.Services.MasterSchemaServices;
using Domain.DBModels;
using Domain.RespDTO.MasterSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.MasterSchema
{    
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private UniversityInstituteServices _service;
        public UniversityController(UniversityInstituteServices services)
        {
            _service = services;
        }

        [Route("api/[controller]/GetAllUniversityInstitute")]
        [HttpGet]
        public UniversityInstituteRespDTO GetAllUniversityInstitute()
        {
            return _service.GetAllUniversityInstitute();
        }

        [Route("api/[controller]/GetAllUniversityByCountry/{country}")]
        [HttpGet]
        public UniversityInstituteRespDTO GetAllUniversityByCountry(string country)
        {
            return _service.GetAllUniversityByCountry(country);
        }
    }
}
