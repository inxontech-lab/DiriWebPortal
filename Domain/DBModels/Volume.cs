using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Volume
    {
        public Volume()
        {
            Articles = new HashSet<Article>();
        }

        public int VolumeId { get; set; }
        public int JournalId { get; set; }
        public int VolumeNumber { get; set; }
        public int? IssueNumber { get; set; }
        public int? PublicationYear { get; set; }
        public string? PublicationMonth { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Description { get; set; }
        public string? EditorialBoard { get; set; }
        public string? Editorial { get; set; }
        public string? DoiPrefix { get; set; }
        public string? PdfUrl { get; set; }
        public string? Thumbnail { get; set; }
        public int? IsPublished { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Journal Journal { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
