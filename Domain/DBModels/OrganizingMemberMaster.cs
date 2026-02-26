using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class OrganizingMemberMaster
    {
        public int Id { get; set; }
        public string? MemberNameEng { get; set; }
        public string? MemberNameBn { get; set; }
        public string? MemberNameAr { get; set; }
        public string? DesignationEn { get; set; }
        public string? DesignationBn { get; set; }
        public string? DesignationAr { get; set; }
        public string? MemberPhoto { get; set; }
        public int? Active { get; set; }
    }
}
