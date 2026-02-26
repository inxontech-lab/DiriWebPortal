using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceDayDetail
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public int DayNumber { get; set; }
        public int Sessions { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
