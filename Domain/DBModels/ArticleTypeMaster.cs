using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleTypeMaster
    {
        public int Id { get; set; }
        public string? ArticleTypeNameEn { get; set; }
        public string? ArticleTypeNameBn { get; set; }
        public string? ArticleTypeNameAr { get; set; }
        public int Acive { get; set; }
    }
}
