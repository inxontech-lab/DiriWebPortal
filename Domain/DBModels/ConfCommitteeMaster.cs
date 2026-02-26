using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConfCommitteeMaster
    {
        public int Id { get; set; }
        public int? ConferenceId { get; set; }
        public string? CommitteeName { get; set; }
        public int? Active { get; set; }
    }
}
