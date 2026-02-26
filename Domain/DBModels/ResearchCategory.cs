using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ResearchCategory
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
