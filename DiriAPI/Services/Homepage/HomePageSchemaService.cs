using DataAccess.Core;
using Domain.DBModels;
using Domain.RespDTO.HomepageRespDTO;
using Microsoft.EntityFrameworkCore;

namespace DiriAPI.Services.Homepage;

public class HomePageSchemaService
{
    private readonly DiriWebPortalContext _context;

    public HomePageSchemaService(DiriWebPortalContext context)
    {
        _context = context;
    }

    public BannerTextCrudRespDTO GetAllBannerTexts()
    {
        var response = new BannerTextCrudRespDTO();

        try
        {
            response.lstData = _context.BannerTexts.OrderBy(x => x.Id).ToList();
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

    public BannerTextCrudRespDTO GetBannerTextById(int id)
    {
        var response = new BannerTextCrudRespDTO();

        try
        {
            response.data = _context.BannerTexts.FirstOrDefault(x => x.Id == id);
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

    public BannerTextCrudRespDTO CreateBannerText(BannerText bannerText)
    {
        var response = new BannerTextCrudRespDTO();

        try
        {
            _context.BannerTexts.Add(bannerText);
            _context.SaveChanges();

            response.data = bannerText;
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

    public BannerTextCrudRespDTO UpdateBannerText(int id, BannerText bannerText)
    {
        var response = new BannerTextCrudRespDTO();

        try
        {
            var existing = _context.BannerTexts.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.BannerImageLocation = bannerText.BannerImageLocation;
            existing.TitleText = bannerText.TitleText;
            existing.Subtitle = bannerText.Subtitle;
            existing.Active = bannerText.Active;

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

    public BannerTextCrudRespDTO DeleteBannerText(int id)
    {
        var response = new BannerTextCrudRespDTO();

        try
        {
            var existing = _context.BannerTexts.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.BannerTexts.Remove(existing);
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

    public NumericDashboardCrudRespDTO GetAllNumericDashboards()
    {
        var response = new NumericDashboardCrudRespDTO();

        try
        {
            response.lstData = _context.NumericDashboards.OrderBy(x => x.Id).ToList();
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

    public NumericDashboardCrudRespDTO GetNumericDashboardById(int id)
    {
        var response = new NumericDashboardCrudRespDTO();

        try
        {
            response.data = _context.NumericDashboards.FirstOrDefault(x => x.Id == id);
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

    public NumericDashboardCrudRespDTO CreateNumericDashboard(NumericDashboard dashboard)
    {
        var response = new NumericDashboardCrudRespDTO();

        try
        {
            _context.NumericDashboards.Add(dashboard);
            _context.SaveChanges();

            response.data = dashboard;
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

    public NumericDashboardCrudRespDTO UpdateNumericDashboard(int id, NumericDashboard dashboard)
    {
        var response = new NumericDashboardCrudRespDTO();

        try
        {
            var existing = _context.NumericDashboards.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.TotalJournal = dashboard.TotalJournal;
            existing.ResearchTittle = dashboard.ResearchTittle;
            existing.UniversityInvolved = dashboard.UniversityInvolved;
            existing.Conference = dashboard.Conference;
            existing.Active = dashboard.Active;

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

    public NumericDashboardCrudRespDTO DeleteNumericDashboard(int id)
    {
        var response = new NumericDashboardCrudRespDTO();

        try
        {
            var existing = _context.NumericDashboards.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.NumericDashboards.Remove(existing);
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

    public AboutUsCrudRespDTO GetAllAboutUs()
    {
        var response = new AboutUsCrudRespDTO();

        try
        {
            response.lstData = _context.AboutUs.OrderBy(x => x.Id).ToList();
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

    public AboutUsCrudRespDTO GetAboutUsById(int id)
    {
        var response = new AboutUsCrudRespDTO();

        try
        {
            response.data = _context.AboutUs.FirstOrDefault(x => x.Id == id);
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

    public AboutUsCrudRespDTO CreateAboutUs(AboutU aboutUs)
    {
        var response = new AboutUsCrudRespDTO();

        try
        {
            _context.AboutUs.Add(aboutUs);
            _context.SaveChanges();

            response.data = aboutUs;
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

    public AboutUsCrudRespDTO UpdateAboutUs(int id, AboutU aboutUs)
    {
        var response = new AboutUsCrudRespDTO();

        try
        {
            var existing = _context.AboutUs.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            existing.AboutUsTitle = aboutUs.AboutUsTitle;
            existing.AbouUsText = aboutUs.AbouUsText;
            existing.Active = aboutUs.Active;

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

    public AboutUsCrudRespDTO DeleteAboutUs(int id)
    {
        var response = new AboutUsCrudRespDTO();

        try
        {
            var existing = _context.AboutUs.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                response.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                response.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                return response;
            }

            _context.AboutUs.Remove(existing);
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
            founderInfo.CreatedDate ??= DateTime.Now;
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
            existing.ModifiedBy = founderInfo.ModifiedBy;
            existing.ModifiedDate = DateTime.Now;

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
            managingTrusteeInfo.CreatedDate ??= DateTime.Now;
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
            existing.ModifiedBy = managingTrusteeInfo.ModifiedBy;
            existing.ModifiedDate = DateTime.Now;

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
}
