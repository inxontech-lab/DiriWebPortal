using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConfCommitteeMember
    {
        public int Id { get; set; }
        public int? CommitteeId { get; set; }
        public int? MemberId { get; set; }
        public int? ConfDesignationId { get; set; }
        public int? SeniorityOrder { get; set; }
        public int? Active { get; set; }
    }
}
