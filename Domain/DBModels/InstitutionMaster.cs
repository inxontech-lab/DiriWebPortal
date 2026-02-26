using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class InstitutionMaster
    {
        public int Id { get; set; }
        public string? InstitutionName { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
