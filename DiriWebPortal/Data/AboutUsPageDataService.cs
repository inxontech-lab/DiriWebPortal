using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;
using Newtonsoft.Json;

namespace DiriWebPortal.Data
{
    public class AboutUsPageDataService
    {
        private ServiceClient serviceClient { get; set; } = new();
        private AboutUsDetailsRespDTO aboutUsDetailsRespDTO;
        private AboutUsDetail aboutUsDetails;

        private IConfiguration _configuration;
        public AboutUsPageDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AboutUsDetail> GetAboutUsDetails()
        {
            aboutUsDetails = new();
            aboutUsDetailsRespDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"AboutUs/GetAboutUsDetails");
            aboutUsDetailsRespDTO = JsonConvert.DeserializeObject<AboutUsDetailsRespDTO>(retrunString);
            if (aboutUsDetailsRespDTO.RESPONSE_CODE.Equals("000"))
            {
                aboutUsDetails = aboutUsDetailsRespDTO.AboutUsDetails;
            }
            return aboutUsDetails;
        }
    }
}
