using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.PublicationShemaDTO
{
    public class PublicationsArticlesDTO
    {
        public int Id { get; set; }
        public string? ArticleNameEn { get; set; }
        public string? ArticleDetails { get; set; }
        public string? FullArticle { get; set; }
        public string? Publisher { get; set; }
        public string? DOI { get; set; }
        public string? Language { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? ArticleTypeId { get; set; }
        public string? ArticleTypeName { get; set; }
        public string? Remarks { get; set; }

        public List<WriterDto>? Writers { get; set; }
        public List<ArticleAttachmentDto>? Attachments { get; set; }
    }

    public class WriterDto
    {
        public int Id { get; set; }
        public string? WriterNameEn { get; set; }
    }

    public class ArticleAttachmentDto
    {
        public int Id { get; set; }
        public string? AttachmentLocation { get; set; }
        public string? AttachmentTitle { get; set; }
        public int? AttachmentSerial { get; set; }
    }

}
