using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceParticipant
    {
        public int Id { get; set; }
        public string? ParticipantName { get; set; }
        public int ConferenceId { get; set; }
        public string? ParticipantDetails { get; set; }
        public int? InstitutionId { get; set; }
        public int? DeaprtmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? ReasearchSubject { get; set; }
        public int? ReasearchcCategory { get; set; }
        public int? ReasearchcSubCategory { get; set; }
        public string? ResearchTittle { get; set; }
        public string? ResourceLocationPath { get; set; }
        public string? ParticipantsImagePath { get; set; }
        public int? AllocatedDay { get; set; }
        public int? AllocatedSession { get; set; }
        public int? GivenTimesInMinutes { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
