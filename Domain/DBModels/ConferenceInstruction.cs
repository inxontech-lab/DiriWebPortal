using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceInstruction
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public int InstructionId { get; set; }
        public int Active { get; set; }
    }
}
