using DiriAPI.Services.AboutUs;
using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.AboutUsSchema;

[ApiController]
[Route("api/[controller]")]
public class AboutUsSchemaController : ControllerBase
{
    private readonly AboutUsSchemaService _service;

    public AboutUsSchemaController(AboutUsSchemaService service)
    {
        _service = service;
    }

    [HttpGet("details")]
    public AboutUsDetailsCrudRespDTO GetAboutUsDetails() => _service.GetAllAboutUsDetails();

    [HttpGet("details/{id:int}")]
    public AboutUsDetailsCrudRespDTO GetAboutUsDetail(int id) => _service.GetAboutUsDetailById(id);

    [HttpPost("details")]
    public AboutUsDetailsCrudRespDTO CreateAboutUsDetail([FromBody] AboutUsDetail detail) => _service.CreateAboutUsDetail(detail);

    [HttpPut("details/{id:int}")]
    public AboutUsDetailsCrudRespDTO UpdateAboutUsDetail(int id, [FromBody] AboutUsDetail detail) => _service.UpdateAboutUsDetail(id, detail);

    [HttpDelete("details/{id:int}")]
    public AboutUsDetailsCrudRespDTO DeleteAboutUsDetail(int id) => _service.DeleteAboutUsDetail(id);

    [HttpGet("founderinfo")]
    public FounderInfoCrudRespDTO GetFounderInfos() => _service.GetAllFounderInfos();

    [HttpGet("founderinfo/{id:int}")]
    public FounderInfoCrudRespDTO GetFounderInfo(int id) => _service.GetFounderInfoById(id);

    [HttpPost("founderinfo")]
    public FounderInfoCrudRespDTO CreateFounderInfo([FromBody] FounderInfo founderInfo) => _service.CreateFounderInfo(founderInfo);

    [HttpPut("founderinfo/{id:int}")]
    public FounderInfoCrudRespDTO UpdateFounderInfo(int id, [FromBody] FounderInfo founderInfo) => _service.UpdateFounderInfo(id, founderInfo);

    [HttpDelete("founderinfo/{id:int}")]
    public FounderInfoCrudRespDTO DeleteFounderInfo(int id) => _service.DeleteFounderInfo(id);

    [HttpGet("managingtrusteeinfo")]
    public ManagingTrusteeInfoCrudRespDTO GetManagingTrusteeInfos() => _service.GetAllManagingTrusteeInfos();

    [HttpGet("managingtrusteeinfo/{id:int}")]
    public ManagingTrusteeInfoCrudRespDTO GetManagingTrusteeInfo(int id) => _service.GetManagingTrusteeInfoById(id);

    [HttpPost("managingtrusteeinfo")]
    public ManagingTrusteeInfoCrudRespDTO CreateManagingTrusteeInfo([FromBody] ManagingTrusteeInfo managingTrusteeInfo) => _service.CreateManagingTrusteeInfo(managingTrusteeInfo);

    [HttpPut("managingtrusteeinfo/{id:int}")]
    public ManagingTrusteeInfoCrudRespDTO UpdateManagingTrusteeInfo(int id, [FromBody] ManagingTrusteeInfo managingTrusteeInfo) => _service.UpdateManagingTrusteeInfo(id, managingTrusteeInfo);

    [HttpDelete("managingtrusteeinfo/{id:int}")]
    public ManagingTrusteeInfoCrudRespDTO DeleteManagingTrusteeInfo(int id) => _service.DeleteManagingTrusteeInfo(id);

    [HttpGet("designations")]
    public ManagingTrusteeDesignationCrudRespDTO GetManagingTrusteeDesignations() => _service.GetAllManagingTrusteeDesignations();

    [HttpGet("designations/{id:int}")]
    public ManagingTrusteeDesignationCrudRespDTO GetManagingTrusteeDesignation(int id) => _service.GetManagingTrusteeDesignationById(id);

    [HttpPost("designations")]
    public ManagingTrusteeDesignationCrudRespDTO CreateManagingTrusteeDesignation([FromBody] ManagingTrusteeDesignation designation) => _service.CreateManagingTrusteeDesignation(designation);

    [HttpPut("designations/{id:int}")]
    public ManagingTrusteeDesignationCrudRespDTO UpdateManagingTrusteeDesignation(int id, [FromBody] ManagingTrusteeDesignation designation) => _service.UpdateManagingTrusteeDesignation(id, designation);

    [HttpDelete("designations/{id:int}")]
    public ManagingTrusteeDesignationCrudRespDTO DeleteManagingTrusteeDesignation(int id) => _service.DeleteManagingTrusteeDesignation(id);

    [HttpGet("articles")]
    public ManagingTrusteeArticleCrudRespDTO GetManagingTrusteeArticles() => _service.GetAllManagingTrusteeArticles();

    [HttpGet("articles/{id:int}")]
    public ManagingTrusteeArticleCrudRespDTO GetManagingTrusteeArticle(int id) => _service.GetManagingTrusteeArticleById(id);

    [HttpPost("articles")]
    public ManagingTrusteeArticleCrudRespDTO CreateManagingTrusteeArticle([FromBody] ManagingTrusteeArticle article) => _service.CreateManagingTrusteeArticle(article);

    [HttpPut("articles/{id:int}")]
    public ManagingTrusteeArticleCrudRespDTO UpdateManagingTrusteeArticle(int id, [FromBody] ManagingTrusteeArticle article) => _service.UpdateManagingTrusteeArticle(id, article);

    [HttpDelete("articles/{id:int}")]
    public ManagingTrusteeArticleCrudRespDTO DeleteManagingTrusteeArticle(int id) => _service.DeleteManagingTrusteeArticle(id);

    [HttpGet("publications")]
    public ManagingTrusteePublicationCrudRespDTO GetManagingTrusteePublications() => _service.GetAllManagingTrusteePublications();

    [HttpGet("publications/{id:int}")]
    public ManagingTrusteePublicationCrudRespDTO GetManagingTrusteePublication(int id) => _service.GetManagingTrusteePublicationById(id);

    [HttpPost("publications")]
    public ManagingTrusteePublicationCrudRespDTO CreateManagingTrusteePublication([FromBody] ManagingTrusteePublication publication) => _service.CreateManagingTrusteePublication(publication);

    [HttpPut("publications/{id:int}")]
    public ManagingTrusteePublicationCrudRespDTO UpdateManagingTrusteePublication(int id, [FromBody] ManagingTrusteePublication publication) => _service.UpdateManagingTrusteePublication(id, publication);

    [HttpDelete("publications/{id:int}")]
    public ManagingTrusteePublicationCrudRespDTO DeleteManagingTrusteePublication(int id) => _service.DeleteManagingTrusteePublication(id);
}
