using DiriAPI.Services.JournalSchemaService;
using Domain.RespDTO.JournalSchemaRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.JournalSchema
{
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private JournalSchemaService _JournalSchemaService;
        public JournalsController(JournalSchemaService JournalSchemaService)
        {
            _JournalSchemaService = JournalSchemaService;
        }

        [Route("api/[controller]/GetAllJournalList")]
        [HttpGet]
        public async Task<JournalMasterRespDTO> GetAllJournalList()
        {
            return await _JournalSchemaService.GetAllJournalList();
        }

        [Route("api/[controller]/GetJournalDetailsByVolumeId/{VolumeId}")]
        [HttpGet]
        public async Task<JournalDetailsRespDTO> GetJournalDetailsByVolumeId(int VolumeId)
        {
            return await _JournalSchemaService.GetJournalDetailsByVolumeId(VolumeId);
        }
    }
}
