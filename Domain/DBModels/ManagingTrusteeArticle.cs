using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ManagingTrusteeArticle
    {
        public int Id { get; set; }
        public string? ArticleName { get; set; }
        public string? ShortDescription { get; set; }
        public string? ArticleLink { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Active { get; set; }
    }
}
