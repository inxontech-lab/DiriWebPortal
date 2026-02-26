using DataAccess.Core;
using Domain.DBModels;
using Domain.DTO.JournalSchemaDTO;
using Domain.RespDTO.JournalSchemaRespDTO;
using Microsoft.EntityFrameworkCore;

namespace DiriAPI.Services.JournalSchemaService
{
    public class JournalSchemaService
    {
        private JournalMasterRespDTO _JournalMasterRespDTO;
        private List<Journal> _lstJournal;

        private JournalDetailsRespDTO _JournalDetailsRespDTO;
        public List<JournalDTO>? _lstJournalDTO;

        private DiriWebPortalContext _DiriWebPortalContext;

        public JournalSchemaService(DiriWebPortalContext DiriWebPortalContext)
        {
            _DiriWebPortalContext = DiriWebPortalContext;
        }

        public async Task<JournalMasterRespDTO> GetAllJournalList()
        {
            _JournalMasterRespDTO = new();
            _lstJournal = new();
            try
            {
                var journalVolumes = await _DiriWebPortalContext.Journals
                                            .Join(_DiriWebPortalContext.Volumes,
                                                  j => j.JournalId,
                                                  v => v.JournalId,
                                                  (j, v) => new { j, v })
                                            .Where(x => x.j.IsActive == 1 && x.v.IsPublished == 1)
                                            .Select(x => new JournalVolumeDTO
                                            {
                                                JournalId = x.j.JournalId,
                                                InstituteId = x.j.InstituteId,
                                                JournalName = x.j.JournalName,
                                                ISSN = x.j.Issn,
                                                PublisherName = x.j.PublisherName,
                                                Description = x.j.Description,
                                                WebsiteUrl = x.j.WebsiteUrl,
                                                Thumbnail = x.j.Thumbnail,
                                                PdfUrl = x.j.PdfUrl,
                                                CreatedDate = x.j.CreatedDate, 

                                                VolumeId = x.v.VolumeId,
                                                VolumeNumber = x.v.VolumeNumber,
                                                IssueNumber = x.v.IssueNumber,
                                                PublicationYear = x.v.PublicationYear,
                                                PublicationMonth = x.v.PublicationMonth,
                                                PublishedDate = x.v.PublishedDate,
                                                VolumeDescription = x.v.Description,
                                                DOI_Prefix = x.v.DoiPrefix,
                                                VolumePdfUrl = x.v.PdfUrl,
                                                VolumeThumbnail = x.v.Thumbnail
                                            })
                                            .ToListAsync();
                if (_lstJournal != null)
                {
                    _JournalMasterRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _JournalMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _JournalMasterRespDTO.lstData = journalVolumes;
                }
                else
                {
                    _JournalMasterRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _JournalMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND;
                    _JournalMasterRespDTO.lstData = null;
                }
            }
            catch(Exception ex)
            {
                _JournalMasterRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _JournalMasterRespDTO.RESPONSE_DESCRPTION = ConfigClass.ERROR_MESSAFGE;
                _JournalMasterRespDTO.lstData = null;
            }
            return _JournalMasterRespDTO;
        }

        public async Task<JournalDetailsRespDTO> GetJournalDetailsByVolumeId(int VolumeId)
        {
            _JournalDetailsRespDTO = new();
            _lstJournalDTO = new();
            try
            {
                var journalData = await (
                from j in _DiriWebPortalContext.Journals
                join v in _DiriWebPortalContext.Volumes on j.JournalId equals v.JournalId
                where v.VolumeId == VolumeId && j.IsActive == 1 && v.IsPublished == 1
                select new JournalDTO
                {
                    JournalId = j.JournalId,
                    InstituteId = j.InstituteId,
                    JournalName = j.JournalName,
                    ISSN = j.Issn,
                    PublisherName = j.PublisherName,
                    Description = j.Description,
                    WebsiteUrl = j.WebsiteUrl,
                    Thumbnail = j.Thumbnail,
                    PdfUrl = j.PdfUrl,
                    CreatedDate = j.CreatedDate,

                    Volume = new VolumeDTO
                    {
                        VolumeId = v.VolumeId,
                        JournalId = v.JournalId,
                        VolumeNumber = v.VolumeNumber,
                        IssueNumber = v.IssueNumber,
                        PublicationYear = v.PublicationYear,
                        PublicationMonth = v.PublicationMonth,
                        PublishedDate = v.PublishedDate,
                        Description = v.Description,
                        EditorialBoard = v.EditorialBoard,
                        Editorial = v.Editorial,
                        DOI_Prefix = v.DoiPrefix,
                        PdfUrl = v.PdfUrl,
                        Thumbnail = v.Thumbnail,

                        Articles = (
                            from a in _DiriWebPortalContext.Articles
                            where a.VolumeId == v.VolumeId
                            select new ArticleDTO
                            {
                                ArticleId = a.ArticleId,
                                VolumeId = a.VolumeId,
                                Title = a.Title,
                                Abstract = a.Abstract,
                                DOI = a.Doi,
                                PDFUrl = a.Pdfurl,
                                Keywords = a.Keywords,
                                Pages = a.Pages,
                                Language = a.Language,
                                Status = a.Status,
                                CreatedDate = a.CreatedDate,
                                PublishedDate = a.PublishedDate,

                                Authors = (
                                    from aa in _DiriWebPortalContext.ArticleAuthors
                                    join r in _DiriWebPortalContext.Researchers
                                        on aa.ResearcherId equals r.ResearcherId
                                    where aa.ArticleId == a.ArticleId
                                    orderby aa.AuthorOrder
                                    select new ResearcherDTO
                                    {
                                        ResearcherId = r.ResearcherId,
                                        FullName = r.FullName,
                                        Email = r.Email,
                                        Affiliation = r.Affiliation,
                                        ORCID = r.Orcid,
                                        Website = r.Website,
                                        Country = r.Country,
                                        Biography = r.Biography,
                                        PhotoUrl = r.PhotoUrl,
                                        CreatedDate = r.CreatedDate,
                                        AuthorOrder = aa.AuthorOrder,
                                        IsCorrespondingAuthor = aa.IsCorrespondingAuthor
                                    }).ToList()
                            }).ToList()
                    }
                }).FirstOrDefaultAsync();

                if (journalData != null)
                {
                    _JournalDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _JournalDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _JournalDetailsRespDTO.JournalDTO = journalData;
                }
                else
                {
                    _JournalDetailsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _JournalDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _JournalDetailsRespDTO.JournalDTO = null;
                }
            }
            catch(Exception ex)
            {
                _JournalDetailsRespDTO.RESPONSE_CODE = ConfigClass.ERROR;
                _JournalDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.ERROR_MESSAFGE;
                _JournalDetailsRespDTO.JournalDTO = null;
            }

            return _JournalDetailsRespDTO;
        }
    }
}
