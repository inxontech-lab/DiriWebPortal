using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceInstructionDetail
    {
        public int Id { get; set; }
        public int? ConferenceInstructionId { get; set; }
        public string? InstructionText { get; set; }
        public int? Active { get; set; }
    }
}
