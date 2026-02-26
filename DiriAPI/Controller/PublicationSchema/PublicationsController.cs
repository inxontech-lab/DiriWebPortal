using DiriAPI.Services.PublicationSchema;
using Domain.RespDTO.PublicationsRespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.PublicationSchema
{    
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private PublicationsSchemaService _service;
        public PublicationsController(PublicationsSchemaService service)
        {
            _service = service;
        }

        [Route("api/[controller]/GetPublicationArticleList")]
        [HttpGet]
        public async Task<PublicationArticlesRespDTO> GetPublicationArticleList()
        {
            return await _service.GetPublicationArticleList();
        }

        [Route("api/[controller]/GetAllPublicationType")]
        [HttpGet]
        public PublicationTypeMasterRespDTO GetAllPublicationType()
        {
            return _service.GetAllPublicationType();
        }

        [Route("api/[controller]/GetAllBooks/{PublicationTypeId}")]
        [HttpGet]
        public BookMasterRespDTO GetAllBooks(int PublicationTypeId)
        {
            return _service.GetAllBooks(PublicationTypeId);
        }

        [Route("api/[controller]/GetBookDetails/{BookId}")]
        [HttpGet]
        public async Task<BookDetailsRespDTO> GetBookDetails(int BookId)
        {
            return await _service.GetBookDetails(BookId);
        }
    }
}
