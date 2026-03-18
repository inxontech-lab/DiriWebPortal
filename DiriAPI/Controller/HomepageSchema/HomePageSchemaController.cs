using DiriAPI.Services.Homepage;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.AspNetCore.Mvc;

namespace DiriAPI.Controller.HomepageSchema;

[ApiController]
[Route("api/[controller]")]
public class HomePageSchemaController : ControllerBase
{
    private readonly HomePageSchemaService _service;

    public HomePageSchemaController(HomePageSchemaService service)
    {
        _service = service;
    }

    [HttpGet("bannertexts")]
    public BannerTextCrudRespDTO GetBannerTexts() => _service.GetAllBannerTexts();

    [HttpGet("bannertexts/{id:int}")]
    public BannerTextCrudRespDTO GetBannerText(int id) => _service.GetBannerTextById(id);

    [HttpPost("bannertexts")]
    public BannerTextCrudRespDTO CreateBannerText([FromBody] BannerText bannerText) => _service.CreateBannerText(bannerText);

    [HttpPut("bannertexts/{id:int}")]
    public BannerTextCrudRespDTO UpdateBannerText(int id, [FromBody] BannerText bannerText) => _service.UpdateBannerText(id, bannerText);

    [HttpDelete("bannertexts/{id:int}")]
    public BannerTextCrudRespDTO DeleteBannerText(int id) => _service.DeleteBannerText(id);

    [HttpGet("numericdashboards")]
    public NumericDashboardCrudRespDTO GetNumericDashboards() => _service.GetAllNumericDashboards();

    [HttpGet("numericdashboards/{id:int}")]
    public NumericDashboardCrudRespDTO GetNumericDashboard(int id) => _service.GetNumericDashboardById(id);

    [HttpPost("numericdashboards")]
    public NumericDashboardCrudRespDTO CreateNumericDashboard([FromBody] NumericDashboard dashboard) => _service.CreateNumericDashboard(dashboard);

    [HttpPut("numericdashboards/{id:int}")]
    public NumericDashboardCrudRespDTO UpdateNumericDashboard(int id, [FromBody] NumericDashboard dashboard) => _service.UpdateNumericDashboard(id, dashboard);

    [HttpDelete("numericdashboards/{id:int}")]
    public NumericDashboardCrudRespDTO DeleteNumericDashboard(int id) => _service.DeleteNumericDashboard(id);

    [HttpGet("aboutus")]
    public AboutUsCrudRespDTO GetAboutUs() => _service.GetAllAboutUs();

    [HttpGet("aboutus/{id:int}")]
    public AboutUsCrudRespDTO GetAboutUs(int id) => _service.GetAboutUsById(id);

    [HttpPost("aboutus")]
    public AboutUsCrudRespDTO CreateAboutUs([FromBody] AboutU aboutUs) => _service.CreateAboutUs(aboutUs);

    [HttpPut("aboutus/{id:int}")]
    public AboutUsCrudRespDTO UpdateAboutUs(int id, [FromBody] AboutU aboutUs) => _service.UpdateAboutUs(id, aboutUs);

    [HttpDelete("aboutus/{id:int}")]
    public AboutUsCrudRespDTO DeleteAboutUs(int id) => _service.DeleteAboutUs(id);

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
}
