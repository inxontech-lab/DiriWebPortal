using Domain.DBModels;
using Domain.DTO.JournalSchemaDTO;
using Domain.RespDTO.JournalSchemaRespDTO;
using Domain.RespDTO.PublicationsRespDTO;
using Newtonsoft.Json;

namespace DiriWebPortal.Data
{
    public class JournalsDataService
    {
        private ServiceClient serviceClient { get; set; } = new();
        private JournalMasterRespDTO? _JournalMasterRespDTO;
        private List<JournalVolumeDTO>? _lstJournal;
        private JournalDetailsRespDTO _JournalDetailsRespDTO;
        private JournalDTO _JournalDTO;

        private IConfiguration _configuration;
        public JournalsDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<JournalVolumeDTO>?> GetAllJournalList()
        {
            _JournalMasterRespDTO = new();
            _lstJournal = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Journals/GetAllJournalList/");
            _JournalMasterRespDTO = JsonConvert.DeserializeObject<JournalMasterRespDTO>(retrunString);
            if (_JournalMasterRespDTO != null)
            {
                if (_JournalMasterRespDTO.RESPONSE_CODE.Equals("000"))
                {
                    _lstJournal = _JournalMasterRespDTO.lstData;
                }
            }
            return _lstJournal;
        }

        public async Task<JournalDTO> GetJournalDetailsByVolumeId(int? VolumeId)
        {
            _JournalDetailsRespDTO = new();
            _JournalDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Journals/GetJournalDetailsByVolumeId/{VolumeId}");
            _JournalDetailsRespDTO = JsonConvert.DeserializeObject<JournalDetailsRespDTO>(retrunString);
            if (_JournalDetailsRespDTO != null)
            {
                if (_JournalDetailsRespDTO.RESPONSE_CODE.Equals("000") && _JournalDetailsRespDTO.JournalDTO != null)
                {
                    _JournalDTO = _JournalDetailsRespDTO.JournalDTO;
                }
            }
            return _JournalDTO;
        }
    }
}
