using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Shared.WebClientService
{
    public class ManagingTrusteeDataService
    {

        private ServiceClient serviceClient { get; set; } = new();
        private ManagingTusteeDesigRespDTO designationRespDTO;
        private List<ManagingTrusteeDesignation>? designation;

        private ManagingTrusteeArticlesRespDTO articlesRespDTO;
        private List<ManagingTrusteeArticle> articles;

        private ManagingTrusteePubRespDTO publicationRespDTO;
        private List<ManagingTrusteePublication> publications;

        private IConfiguration _configuration;

        public ManagingTrusteeDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ManagingTrusteeDesignation>> GetManagingTrusteeDesignation()
        {
            designation = new();
            designationRespDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"ManagingTrustee/GetManagingTrusteeDesignation");
            designationRespDTO = JsonConvert.DeserializeObject<ManagingTusteeDesigRespDTO>(retrunString);
            if (designationRespDTO.RESPONSE_CODE.Equals("000"))
            {
                designation = designationRespDTO.ManagingTrusteeDesignation;
            }
            return designation;
        }

        public async Task<List<ManagingTrusteeArticle>> GetManagingTrusteeArticles()
        {
            articles = new();
            articlesRespDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"ManagingTrustee/GetManagingTrusteeArticles");
            articlesRespDTO = JsonConvert.DeserializeObject<ManagingTrusteeArticlesRespDTO>(retrunString);
            if (articlesRespDTO.RESPONSE_CODE.Equals("000"))
            {
                articles = articlesRespDTO.managingTrusteeArticle;
            }
            return articles;
        }

        public async Task<List<ManagingTrusteePublication>> GetManagingTrusteePublications()
        {
            publications = new();
            publicationRespDTO = new();
            string retrunString = null;
            retrunString = await serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"ManagingTrustee/GetManagingTrusteePublications");
            publicationRespDTO = JsonConvert.DeserializeObject<ManagingTrusteePubRespDTO>(retrunString);
            if (publicationRespDTO.RESPONSE_CODE.Equals("000"))
            {
                publications = publicationRespDTO.managingTrusteePublications;
            }
            return publications;
        }
    }
}
