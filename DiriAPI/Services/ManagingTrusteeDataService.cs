using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;
using System.Diagnostics.Contracts;

namespace DiriAPI.Services
{
    public class ManagingTrusteeDataService
    {
        private DiriWebPortalContext _diriWebPortalContext;

        private ManagingTusteeDesigRespDTO designationRespDTO;
        private List<ManagingTrusteeDesignation> designation;
        private ManagingTrusteeArticlesRespDTO articlesRespDTO;
        private List<ManagingTrusteeArticle> articles;
        private ManagingTrusteePubRespDTO managingTrusteePubRespDTO;
        private List<ManagingTrusteePublication> lstManagingTrusteePublications;

        public ManagingTrusteeDataService(DiriWebPortalContext diriWebPortalContext)
        {
            _diriWebPortalContext = diriWebPortalContext;
        }

        public ManagingTusteeDesigRespDTO GetManagingTrusteeDesignation()
        {
            designationRespDTO = new();
            designation = new();
            try
            {
                designation = _diriWebPortalContext.ManagingTrusteeDesignations.Where(x => x.Active == 1).ToList();
                if (designation != null)
                {
                    designationRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    designationRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    designationRespDTO.ManagingTrusteeDesignation = designation;
                }
                else
                {
                    designationRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    designationRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    designationRespDTO.ManagingTrusteeDesignation = null;
                }
            }
            catch (Exception ex)
            {
                designationRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                designationRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                designationRespDTO.ManagingTrusteeDesignation = null;
            }
            return designationRespDTO;
        }

        public ManagingTrusteeArticlesRespDTO GetManagingTrusteeArticles()
        {
            articlesRespDTO = new();
            articles = new();
            try
            {
                articles = _diriWebPortalContext.ManagingTrusteeArticles.Where(x => x.Active == 1).ToList();
                if (articles != null)
                {
                    articlesRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    articlesRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    articlesRespDTO.managingTrusteeArticle = articles;
                }
                else
                {
                    articlesRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    articlesRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    articlesRespDTO.managingTrusteeArticle = null;
                }
            }
            catch (Exception ex)
            {
                articlesRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                articlesRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                articlesRespDTO.managingTrusteeArticle = null;
            }
            return articlesRespDTO;
        }

        public ManagingTrusteePubRespDTO GetManagingTrusteePublications()
        {
            managingTrusteePubRespDTO = new();
            lstManagingTrusteePublications = new();
            try
            {
                lstManagingTrusteePublications = _diriWebPortalContext.ManagingTrusteePublications.Where(x => x.Active == 1).ToList();
                if (lstManagingTrusteePublications != null)
                {
                    managingTrusteePubRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    managingTrusteePubRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    managingTrusteePubRespDTO.managingTrusteePublications = lstManagingTrusteePublications;
                }
                else
                {
                    managingTrusteePubRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    managingTrusteePubRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    managingTrusteePubRespDTO.managingTrusteePublications = null;
                }
            }
            catch (Exception ex)
            {
                managingTrusteePubRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                managingTrusteePubRespDTO.RESPONSE_DESCRPTION = ex.ToString();
                managingTrusteePubRespDTO.managingTrusteePublications = null;
            }
            return managingTrusteePubRespDTO;
        }
    }
}
