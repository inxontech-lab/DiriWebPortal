using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.PublicationsRespDTO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace DiriJournal.Services
{
    public class PublicationsPageDataService
    {
        private ServiceClient _serviceClient;
        private PublicationTypeMasterRespDTO _publicationTypeMasterRespDTO;
        private List<PublicationTypeMaster> _publicationTypeMasters;

        private PublicationsMasterRespDTO _publicationsMasterRespDTO;
        private List<PublicationMaster> _publicationMasters;

        private BookMasterRespDTO _BookMasterRespDTO;
        private List<BookMaster> _lstBookMaster;

        private BookDetailsRespDTO _BookDetailsRespDTO;
        private List<BookDetailsDTO> _lstBookDetailsDTO;

        //private BookAttachmentDTO _BookAttachmentDTO;
        private List<BookAttachment> _lstBookAttachment;
        

        private IConfiguration _configuration;
        public PublicationsPageDataService(IConfiguration configuration, ServiceClient serviceClient)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<List<PublicationTypeMaster>> GetAllPublicationType()
        {
            _publicationTypeMasterRespDTO = new();
            _publicationTypeMasters = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Publications/GetAllPublicationType");
            _publicationTypeMasterRespDTO = JsonConvert.DeserializeObject<PublicationTypeMasterRespDTO>(retrunString);
            if (_publicationTypeMasterRespDTO.RESPONSE_CODE.Equals("000"))
            {
                _publicationTypeMasters = _publicationTypeMasterRespDTO.lstData;
            }
            return _publicationTypeMasters;
        }

        public async Task<List<BookMaster>> GetAllBooks(int PublicationTypeId)
        {
            _BookMasterRespDTO = new();
            _lstBookMaster = new();
            string retrunString = null;
            string endpoint = _configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Publications/GetAllBooks/{PublicationTypeId}";
            retrunString = await _serviceClient.clientMethod(endpoint);
            _BookMasterRespDTO = JsonConvert.DeserializeObject<BookMasterRespDTO>(retrunString);
            if (_BookMasterRespDTO.RESPONSE_CODE.Equals("000"))
            {
                _lstBookMaster = _BookMasterRespDTO.lstData;
            }
            return _lstBookMaster;
        }

        public async Task<List<BookDetailsDTO>> GetBookDetails(int BookId)
        {
            _BookDetailsRespDTO = new();
            _lstBookDetailsDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Publications/GetBookDetails/{BookId}");
            _BookDetailsRespDTO = JsonConvert.DeserializeObject<BookDetailsRespDTO>(retrunString);
            if (_BookDetailsRespDTO.RESPONSE_CODE.Equals("000"))
            {
                _lstBookDetailsDTO = _BookDetailsRespDTO.lstData;
            }
            return _lstBookDetailsDTO;
        }

        public async Task<List<PublicationMaster>> GetAllPublications()
        {
            _publicationsMasterRespDTO = new();
            _publicationMasters = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Publications/GetAllPublications");
            _publicationsMasterRespDTO = JsonConvert.DeserializeObject<PublicationsMasterRespDTO>(retrunString);
            if (_publicationsMasterRespDTO.RESPONSE_CODE.Equals("000"))
            {
                _publicationMasters = _publicationsMasterRespDTO.lstData;
            }
            return _publicationMasters;
        }
    }
}
