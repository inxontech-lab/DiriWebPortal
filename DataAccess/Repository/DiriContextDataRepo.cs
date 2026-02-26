using Domain.DBModels;
using Domain.DTO.ConferenceSchemaDTO;
using Domain.DTO.JournalSchemaDTO;
using Domain.DTO.PublicationShemaDTO;
using Domain.RespDTO.ConferenceSchemaRespDTO;
using Domain.RespDTO.PublicationsRespDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DiriContextDataRepo : IDiriContextDataRepo
    {
        private DiriWebPortalContext _context;
        public DiriContextDataRepo(DiriWebPortalContext diriWebPortalContext)
        {
            _context = diriWebPortalContext;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        public async Task<List<PublicationsArticlesDTO>> GetPublicationArticleList()
        {
            var articles =
                    from a in _context.ArticleDetails
                     where a.Active == 1
                     select new PublicationsArticlesDTO
                     {
                         Id = a.Id,
                         ArticleNameEn = a.ArticleNameEn,
                         ArticleDetails = a.ArticleDetails,
                         FullArticle = a.FullArticle,
                         Publisher = a.Publisher,
                         DOI = a.Doi,
                         Language = a.Language,
                         PublishedDate = a.PublishedDate,
                         ArticleTypeId = a.ArticleTypeId,
                         Remarks = a.Remarks,

                         // Multiple writers for the article
                         Writers = (from aw in _context.ArticleWritters
                                    join w in _context.ArticleWritterMasters
                                        on aw.WritterId equals w.Id
                                    where aw.ArticleId == a.Id
                                          && aw.Active == 1
                                          && w.Active == 1
                                    select new WriterDto
                                    {
                                        Id = w.Id,
                                        WriterNameEn = w.WritterNameEn
                                    }).ToList(),

                         // Article type
                         ArticleTypeName = (from t in _context.ArticleTypeMasters
                                            where t.Id == a.ArticleTypeId
                                                  && t.Acive == 1
                                            select t.ArticleTypeNameEn).FirstOrDefault(),

                         // Attachments
                         Attachments = (from at in _context.ArticleAttachments
                                        where at.ArticleId == a.Id
                                              && at.Active == 1
                                        orderby at.AttachmentSerial
                                        select new ArticleAttachmentDto
                                        {
                                            Id = at.Id,
                                            AttachmentLocation = at.AttachmentLocation,
                                            AttachmentTitle = at.AttachmentTittle,
                                            AttachmentSerial = at.AttachmentSerial
                                        }).ToList()
                     };
            return await articles.ToListAsync();
        }

        public async Task<List<ConferenceDetailsDTO>> GetUpcomingConferenceDetails()
        {
            var today = DateTime.Today;
            var upcomingConferences = from c in _context.ConferenceMasters
                                      where c.HighlightSwitch == 1
                                          && c.Active == 1
                                          && c.ConfrenceFromDate >= today
                                      orderby c.ConfrenceFromDate ascending
                                      select new ConferenceDetailsDTO
                                      {
                                          Id = c.Id,
                                          ConferenceTitle = c.ConferenceTitle,
                                          Subtitle = c.Subtitle,
                                          ConferenceCode = c.ConferenceCode,
                                          ShortDescription = c.ShortDescription,
                                          ConfrenceFromDate = c.ConfrenceFromDate,
                                          ConferenceTodate = c.ConferenceTodate,
                                          MainThemeId = c.MainThemeId,
                                          Venue = c.Venue,
                                          VanueLocation = c.VanueLocation,
                                          OrganizedBy1 = c.OrganizedBy1,
                                          OrganizedBy2 = c.OrganizedBy2,
                                          OrganizedBy3 = c.OrganizedBy3,
                                          BannerImagePath = c.BannerImagePath,
                                          HeroImagePath = c.HeroImagePath,
                                          CallForPaperPath = c.CallForPaperPath,
                                          ConferenceScheduleFilePath = c.ConferenceScheduleFilePath,

                                          MainTheme = _context.MainThemeMasters
                                              .Where(mt => mt.Id == c.MainThemeId)
                                              .Select(mt => mt.Theme)
                                          .FirstOrDefault(),

                                          SubThemes = _context.SubThemes
                                              .Where(st => st.MainThemeId == c.MainThemeId && st.Active == 1)
                                              .Select(st => st.SubTheme1)
                                          .ToList(),

                                          ImportantDates = _context.ImportantDates
                                              .Where(d => d.ConferenceId == c.Id && d.Active == 1)
                                              .Select(d => new ImportantDateDTO
                                              {
                                                  ActionDescription = d.ActionDescription,
                                                  ActionDate = d.ActionDate
                                              }).ToList(),
                                          Languages = (
                                              from cl in _context.Languages
                                              join lm in _context.LanguageMasters on cl.LanguageId equals lm.Id
                                              where cl.ConferenceId == c.Id && cl.Active == 1 && lm.Active == 1
                                              select lm.LanguageName
                                          ).ToList(),
                                          Instructions = (
                                              from ci in _context.ConferenceInstructions
                                              join im in _context.InstructionMasters on ci.InstructionId equals im.Id
                                              where ci.ConferenceId == c.Id && ci.Active == 1 && im.Active == 1
                                              select new InstructionDTO
                                              {
                                                  InstructionTitle = im.InstructionTitle,
                                                  Details = _context.ConferenceInstructionDetails
                                                      .Where(cd => cd.ConferenceInstructionId == ci.Id && cd.Active == 1)
                                                      .Select(cd => cd.InstructionText)
                                                      .ToList()
                                              }
                                          ).ToList(),
                                          Organizers = (
                                            from o in _context.Organizers
                                            join om in _context.OrganizerMasters on o.OrganizerId equals om.Id
                                            where o.ConferenceId == c.Id && o.Active == 1 && om.Active == 1
                                            select new OrganizerDTO
                                            {
                                                OrganizerNameEn = om.OrganizerNameEn,
                                                OrganizerNameBn = om.OrganizerNameBn,
                                                OrganizerNameAr = om.OrganizerNameAr,
                                                AddressEn = om.AddressEn,
                                                AddressBn = om.AddressBn,
                                                AddressAr = om.AddressAr,
                                                Phone = om.Phone,
                                                Email = om.Email,
                                                Website = om.Website,
                                                Logo = om.Logo
                                            }
                                        ).ToList()
                                      };
            return await upcomingConferences.ToListAsync();
        }
    }
}
