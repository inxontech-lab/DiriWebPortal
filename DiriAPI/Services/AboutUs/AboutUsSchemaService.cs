using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.AboutUsPageRespDTO;
using Domain.RespDTO.HomepageRespDTO;

namespace DiriAPI.Services.AboutUs;

public class AboutUsSchemaService
{
    private readonly DiriWebPortalContext _context;

    public AboutUsSchemaService(DiriWebPortalContext context)
    {
        _context = context;
    }

    public AboutUsDetailsCrudRespDTO GetAllAboutUsDetails()
    {
        var response = new AboutUsDetailsCrudRespDTO();

        try
        {
            response.lstData = _context.AboutUsDetails.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public AboutUsDetailsCrudRespDTO GetAboutUsDetailById(int id)
    {
        var response = new AboutUsDetailsCrudRespDTO();

        try
        {
            response.data = _context.AboutUsDetails.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public AboutUsDetailsCrudRespDTO CreateAboutUsDetail(AboutUsDetail detail)
    {
        var response = new AboutUsDetailsCrudRespDTO();

        try
        {
            _context.AboutUsDetails.Add(detail);
            _context.SaveChanges();

            response.data = detail;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public AboutUsDetailsCrudRespDTO UpdateAboutUsDetail(int id, AboutUsDetail detail)
    {
        var response = new AboutUsDetailsCrudRespDTO();

        try
        {
            var existing = _context.AboutUsDetails.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.Heading1 = detail.Heading1;
            existing.Heading2 = detail.Heading2;
            existing.Heading3 = detail.Heading3;
            existing.Heading4 = detail.Heading4;
            existing.AboutUsDetails = detail.AboutUsDetails;
            existing.YearsOfJourney = detail.YearsOfJourney;
            existing.Active = detail.Active;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public AboutUsDetailsCrudRespDTO DeleteAboutUsDetail(int id)
    {
        var response = new AboutUsDetailsCrudRespDTO();

        try
        {
            var existing = _context.AboutUsDetails.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.AboutUsDetails.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public FounderInfoCrudRespDTO GetAllFounderInfos()
    {
        var response = new FounderInfoCrudRespDTO();

        try
        {
            response.lstData = _context.FounderInfos.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public FounderInfoCrudRespDTO GetFounderInfoById(int id)
    {
        var response = new FounderInfoCrudRespDTO();

        try
        {
            response.data = _context.FounderInfos.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public FounderInfoCrudRespDTO CreateFounderInfo(FounderInfo founderInfo)
    {
        var response = new FounderInfoCrudRespDTO();

        try
        {
            _context.FounderInfos.Add(founderInfo);
            _context.SaveChanges();

            response.data = founderInfo;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public FounderInfoCrudRespDTO UpdateFounderInfo(int id, FounderInfo founderInfo)
    {
        var response = new FounderInfoCrudRespDTO();

        try
        {
            var existing = _context.FounderInfos.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.FounderName = founderInfo.FounderName;
            existing.FounderTittle1 = founderInfo.FounderTittle1;
            existing.FounderTittle2 = founderInfo.FounderTittle2;
            existing.FounderMessage = founderInfo.FounderMessage;
            existing.AboutFounder = founderInfo.AboutFounder;
            existing.FounderImagePath = founderInfo.FounderImagePath;
            existing.Active = founderInfo.Active;
            existing.CreatedBy = founderInfo.CreatedBy;
            existing.CreatedDate = founderInfo.CreatedDate;
            existing.ModifiedBy = founderInfo.ModifiedBy;
            existing.ModifiedDate = founderInfo.ModifiedDate;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public FounderInfoCrudRespDTO DeleteFounderInfo(int id)
    {
        var response = new FounderInfoCrudRespDTO();

        try
        {
            var existing = _context.FounderInfos.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.FounderInfos.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeInfoCrudRespDTO GetAllManagingTrusteeInfos()
    {
        var response = new ManagingTrusteeInfoCrudRespDTO();

        try
        {
            response.lstData = _context.ManagingTrusteeInfos.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeInfoCrudRespDTO GetManagingTrusteeInfoById(int id)
    {
        var response = new ManagingTrusteeInfoCrudRespDTO();

        try
        {
            response.data = _context.ManagingTrusteeInfos.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeInfoCrudRespDTO CreateManagingTrusteeInfo(ManagingTrusteeInfo managingTrusteeInfo)
    {
        var response = new ManagingTrusteeInfoCrudRespDTO();

        try
        {
            _context.ManagingTrusteeInfos.Add(managingTrusteeInfo);
            _context.SaveChanges();

            response.data = managingTrusteeInfo;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeInfoCrudRespDTO UpdateManagingTrusteeInfo(int id, ManagingTrusteeInfo managingTrusteeInfo)
    {
        var response = new ManagingTrusteeInfoCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeInfos.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.ManagingTrusteeName = managingTrusteeInfo.ManagingTrusteeName;
            existing.ManagingTrusteeNameTittle1 = managingTrusteeInfo.ManagingTrusteeNameTittle1;
            existing.ManagingTrusteeNameTittle2 = managingTrusteeInfo.ManagingTrusteeNameTittle2;
            existing.ManagingTrusteeMessage = managingTrusteeInfo.ManagingTrusteeMessage;
            existing.AboutManagingTrustee = managingTrusteeInfo.AboutManagingTrustee;
            existing.ManagingTrusteeImagePath = managingTrusteeInfo.ManagingTrusteeImagePath;
            existing.Active = managingTrusteeInfo.Active;
            existing.CreatedBy = managingTrusteeInfo.CreatedBy;
            existing.CreatedDate = managingTrusteeInfo.CreatedDate;
            existing.ModifiedBy = managingTrusteeInfo.ModifiedBy;
            existing.ModifiedDate = managingTrusteeInfo.ModifiedDate;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeInfoCrudRespDTO DeleteManagingTrusteeInfo(int id)
    {
        var response = new ManagingTrusteeInfoCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeInfos.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.ManagingTrusteeInfos.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeDesignationCrudRespDTO GetAllManagingTrusteeDesignations()
    {
        var response = new ManagingTrusteeDesignationCrudRespDTO();

        try
        {
            response.lstData = _context.ManagingTrusteeDesignations.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeDesignationCrudRespDTO GetManagingTrusteeDesignationById(int id)
    {
        var response = new ManagingTrusteeDesignationCrudRespDTO();

        try
        {
            response.data = _context.ManagingTrusteeDesignations.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeDesignationCrudRespDTO CreateManagingTrusteeDesignation(ManagingTrusteeDesignation designation)
    {
        var response = new ManagingTrusteeDesignationCrudRespDTO();

        try
        {
            _context.ManagingTrusteeDesignations.Add(designation);
            _context.SaveChanges();

            response.data = designation;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeDesignationCrudRespDTO UpdateManagingTrusteeDesignation(int id, ManagingTrusteeDesignation designation)
    {
        var response = new ManagingTrusteeDesignationCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeDesignations.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.DesignationDetails = designation.DesignationDetails;
            existing.Active = designation.Active;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeDesignationCrudRespDTO DeleteManagingTrusteeDesignation(int id)
    {
        var response = new ManagingTrusteeDesignationCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeDesignations.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.ManagingTrusteeDesignations.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeArticleCrudRespDTO GetAllManagingTrusteeArticles()
    {
        var response = new ManagingTrusteeArticleCrudRespDTO();

        try
        {
            response.lstData = _context.ManagingTrusteeArticles.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeArticleCrudRespDTO GetManagingTrusteeArticleById(int id)
    {
        var response = new ManagingTrusteeArticleCrudRespDTO();

        try
        {
            response.data = _context.ManagingTrusteeArticles.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeArticleCrudRespDTO CreateManagingTrusteeArticle(ManagingTrusteeArticle article)
    {
        var response = new ManagingTrusteeArticleCrudRespDTO();

        try
        {
            _context.ManagingTrusteeArticles.Add(article);
            _context.SaveChanges();

            response.data = article;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeArticleCrudRespDTO UpdateManagingTrusteeArticle(int id, ManagingTrusteeArticle article)
    {
        var response = new ManagingTrusteeArticleCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeArticles.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.ArticleName = article.ArticleName;
            existing.ShortDescription = article.ShortDescription;
            existing.ArticleLink = article.ArticleLink;
            existing.PublishedDate = article.PublishedDate;
            existing.Active = article.Active;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteeArticleCrudRespDTO DeleteManagingTrusteeArticle(int id)
    {
        var response = new ManagingTrusteeArticleCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteeArticles.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.ManagingTrusteeArticles.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteePublicationCrudRespDTO GetAllManagingTrusteePublications()
    {
        var response = new ManagingTrusteePublicationCrudRespDTO();

        try
        {
            response.lstData = _context.ManagingTrusteePublications.OrderBy(x => x.Id).ToList();
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteePublicationCrudRespDTO GetManagingTrusteePublicationById(int id)
    {
        var response = new ManagingTrusteePublicationCrudRespDTO();

        try
        {
            response.data = _context.ManagingTrusteePublications.FirstOrDefault(x => x.Id == id);
            if (response.data == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteePublicationCrudRespDTO CreateManagingTrusteePublication(ManagingTrusteePublication publication)
    {
        var response = new ManagingTrusteePublicationCrudRespDTO();

        try
        {
            _context.ManagingTrusteePublications.Add(publication);
            _context.SaveChanges();

            response.data = publication;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteePublicationCrudRespDTO UpdateManagingTrusteePublication(int id, ManagingTrusteePublication publication)
    {
        var response = new ManagingTrusteePublicationCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteePublications.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.PublicationName = publication.PublicationName;
            existing.ShortDescription = publication.ShortDescription;
            existing.PublicationLink = publication.PublicationLink;
            existing.PublishedDate = publication.PublishedDate;
            existing.Active = publication.Active;

            _context.SaveChanges();

            response.data = existing;
            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }

    public ManagingTrusteePublicationCrudRespDTO DeleteManagingTrusteePublication(int id)
    {
        var response = new ManagingTrusteePublicationCrudRespDTO();

        try
        {
            var existing = _context.ManagingTrusteePublications.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.ManagingTrusteePublications.Remove(existing);
            _context.SaveChanges();

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.ERROR;
            response.RESPONSE_DESCRPTION = ex.Message;
        }

        return response;
    }
}
