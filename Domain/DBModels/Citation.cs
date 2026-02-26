using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Citation
    {
        public int CitationId { get; set; }
        public int CitingArticleId { get; set; }
        public int CitedArticleId { get; set; }
        public string? CitationText { get; set; }
        public string? CitedDoi { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
