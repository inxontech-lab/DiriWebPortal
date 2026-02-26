using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleWritterMaster
    {
        public int Id { get; set; }
        public string WritterNameEn { get; set; } = null!;
        public string? WritterNameBn { get; set; }
        public string? WritterNameAr { get; set; }
        public int? Active { get; set; }
    }
}
