using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleDetail
    {
        public int Id { get; set; }
        public string? ArticleNameEn { get; set; }
        public string? ArticleDetails { get; set; }
        public string? FullArticle { get; set; }
        public string? Publisher { get; set; }
        public string? Doi { get; set; }
        public string? Language { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? ArticleTypeId { get; set; }
        public string? Remarks { get; set; }
        public int? Active { get; set; }
    }
}
