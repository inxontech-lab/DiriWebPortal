using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Journal
    {
        public Journal()
        {
            Volumes = new HashSet<Volume>();
        }

        public int JournalId { get; set; }
        public int? InstituteId { get; set; }
        public string JournalName { get; set; } = null!;
        public string? Issn { get; set; }
        public string? PublisherName { get; set; }
        public string? Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Thumbnail { get; set; }
        public string? PdfUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? IsActive { get; set; }

        public virtual Institute? Institute { get; set; }
        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
