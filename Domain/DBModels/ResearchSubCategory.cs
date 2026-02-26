using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ResearchSubCategory
    {
        public int Id { get; set; }
        public int? ResearchCatId { get; set; }
        public string? ResearchSubCategoryName { get; set; }
        public string? ResearchSubCategoryDesc { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
