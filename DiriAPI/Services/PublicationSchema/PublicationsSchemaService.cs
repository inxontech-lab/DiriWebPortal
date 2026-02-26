using DataAccess.Core;
using DataAccess.Repository;
using Domain.DBModels;
using Domain.DTO.PublicationShemaDTO;
using Domain.RespDTO.PublicationsRespDTO;

namespace DiriAPI.Services.PublicationSchema
{
    public class PublicationsSchemaService
    {
        private DiriWebPortalContext _diriWebPortalContext;

        private PublicationTypeMasterRespDTO _publicationTypeMasterRespDTO;
        private List<PublicationTypeMaster> _publicationTypeMasters;

        private BookMasterRespDTO _BookMasterRespDTO;
        private List<BookMaster> _lstBooks;

        private BookDetailsRespDTO _BookDetailsRespDTO;
        private List<BookDetailsDTO> _lstBookDetailsDTO;
        private PublicationArticlesRespDTO _PublicationArticlesRespDTO;
        private List<PublicationsArticlesDTO> _lstPublicationsArticles;

        private IDataRepository _dataRepository;
        private IDiriContextDataRepo _diriContextDataRepo;

        public PublicationsSchemaService(DiriWebPortalContext diriWebPortalContext, IDataRepository dataRepository, IDiriContextDataRepo diriContextDataRepo)
        {
            _diriWebPortalContext = diriWebPortalContext;
            _dataRepository = dataRepository;
            _diriContextDataRepo = diriContextDataRepo;
        }

        public async Task<PublicationArticlesRespDTO> GetPublicationArticleList()
        {
            _PublicationArticlesRespDTO = new();
            _lstPublicationsArticles = new();
            try
            {
                _lstPublicationsArticles = await _diriContextDataRepo.GetPublicationArticleList();
                if (_lstPublicationsArticles != null)
                {
                    _PublicationArticlesRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _PublicationArticlesRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _PublicationArticlesRespDTO._lstPublicationsArticles = _lstPublicationsArticles;
                }
                else
                {
                    _PublicationArticlesRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _PublicationArticlesRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _PublicationArticlesRespDTO._lstPublicationsArticles = null;
                }
            }
            catch (Exception ex)
            {
                _PublicationArticlesRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _PublicationArticlesRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                _PublicationArticlesRespDTO._lstPublicationsArticles = null;
            }
            return _PublicationArticlesRespDTO;
        }

        public PublicationTypeMasterRespDTO GetAllPublicationType()
        {
            _publicationTypeMasterRespDTO = new();
            _publicationTypeMasters = new();
            try
            {
                _publicationTypeMasters = _diriWebPortalContext.PublicationTypeMasters.Where(x => x.Active == 1).ToList();
                if (_publicationTypeMasters != null)
                {
                    _publicationTypeMasterRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _publicationTypeMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _publicationTypeMasterRespDTO.lstData = _publicationTypeMasters;
                }
                else
                {
                    _publicationTypeMasterRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _publicationTypeMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _publicationTypeMasterRespDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                _publicationTypeMasterRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _publicationTypeMasterRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                _publicationTypeMasterRespDTO.lstData = null;
            }
            return _publicationTypeMasterRespDTO;
        }

        public BookMasterRespDTO GetAllBooks(int PublicationTypeId)
        {
            _BookMasterRespDTO = new();
            _lstBooks = new();
            try
            {
                if (PublicationTypeId > 0)
                {
                    _lstBooks = _diriWebPortalContext.BookMasters.Where(x => x.Active == 1 && x.PublicationTypeId == PublicationTypeId).ToList();
                }
                else
                {
                    _lstBooks = _diriWebPortalContext.BookMasters
                                .Where(x => x.Active == 1)
                                .OrderBy(x => x.BookNameEng)
                                .Take(7)
                                .ToList();
                }

                if (_lstBooks != null)
                {
                    _BookMasterRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _BookMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _BookMasterRespDTO.lstData = _lstBooks;
                }
                else
                {
                    _BookMasterRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _BookMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _BookMasterRespDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                _BookMasterRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _BookMasterRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                _BookMasterRespDTO.lstData = null;
            }
            return _BookMasterRespDTO;
        }

        public async Task<BookDetailsRespDTO> GetBookDetails(int BookId)
        {
            _BookDetailsRespDTO = new();
            _lstBookDetailsDTO = new();
            try
            {
                _lstBookDetailsDTO = await _dataRepository.GetBookDetails(BookId);
                if (_lstBookDetailsDTO != null)
                {
                    if (_lstBookDetailsDTO.Count() > 0)
                    {
                        _BookDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                        _BookDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                        _BookDetailsRespDTO.lstData = _lstBookDetailsDTO;
                    }
                    else
                    {
                        _BookDetailsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                        _BookDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                        _BookDetailsRespDTO.lstData = null;
                    }
                }
                else
                {
                    _BookDetailsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _BookDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _BookDetailsRespDTO.lstData = null;
                }
            }
            catch (Exception ex)
            {
                _BookDetailsRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _BookDetailsRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                _BookDetailsRespDTO.lstData = null;
            }   
            return _BookDetailsRespDTO;
        }
    }
}
