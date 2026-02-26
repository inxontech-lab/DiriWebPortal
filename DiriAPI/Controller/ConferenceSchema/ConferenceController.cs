using DiriAPI.Services.ConferenceSchemaService;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.ConferenceSchema
{   
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private ConferenceMasterService _service;
        public ConferenceController(ConferenceMasterService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetAllConferenceList")]
        [HttpGet]
        public ConferenceMasterRespDTO GetAllConferenceList()
        {
            return _service.GetAllConferenceList();    
        }

        [Route("api/[controller]/GetUpcomingConferenceDetails")]
        [HttpGet]
        public async Task<UpcomingConferenceRespDTO> GetUpcomingConferenceDetails()
        {
            return await _service.GetUpcomingConferenceDetails();
        }
    }
}
