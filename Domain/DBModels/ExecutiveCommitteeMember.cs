using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ExecutiveCommitteeMember
    {
        public int Id { get; set; }
        public string? MemberName { get; set; }
        public int? DiriDesignationId { get; set; }
        public int? UniversityId { get; set; }
        public int? DepartmentId { get; set; }
        public int? OccupationalDesignationId { get; set; }
        public string? ImagePath { get; set; }
        public int? Active { get; set; }
    }
}
