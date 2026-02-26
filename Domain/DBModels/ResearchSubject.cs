using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ResearchSubject
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectDescription { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
