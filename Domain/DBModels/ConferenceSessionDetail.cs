using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceSessionDetail
    {
        public int Id { get; set; }
        public int? DayId { get; set; }
        public string? SessionName { get; set; }
        public string? SessionTiming { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
