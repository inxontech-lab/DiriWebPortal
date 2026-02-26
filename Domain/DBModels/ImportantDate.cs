using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ImportantDate
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string? ActionDescription { get; set; }
        public DateTime? ActionDate { get; set; }
        public int? Active { get; set; }
    }
}
