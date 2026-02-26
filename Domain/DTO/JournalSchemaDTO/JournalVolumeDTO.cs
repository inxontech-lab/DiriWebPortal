using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.JournalSchemaDTO
{
    public class JournalVolumeDTO
    {
        // Journal fields
        public int JournalId { get; set; }
        public int? InstituteId { get; set; }
        public string? JournalName { get; set; }
        public string? ISSN { get; set; }
        public string? PublisherName { get; set; }
        public string? Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Thumbnail { get; set; }
        public string? PdfUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        // Volume fields
        public int VolumeId { get; set; }
        public int VolumeNumber { get; set; }
        public int? IssueNumber { get; set; }
        public int? PublicationYear { get; set; }
        public string? PublicationMonth { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? VolumeDescription { get; set; }
        public string? DOI_Prefix { get; set; }
        public string? VolumePdfUrl { get; set; }
        public string? VolumeThumbnail { get; set; }
    }
}
