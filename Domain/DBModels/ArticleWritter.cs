using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArticleWritter
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int WritterId { get; set; }
        public int Active { get; set; }
    }
}
