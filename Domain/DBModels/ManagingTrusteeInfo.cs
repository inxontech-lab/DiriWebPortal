using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ManagingTrusteeInfo
    {
        public int Id { get; set; }
        public string? ManagingTrusteeName { get; set; }
        public string? ManagingTrusteeNameTittle1 { get; set; }
        public string? ManagingTrusteeNameTittle2 { get; set; }
        public string? ManagingTrusteeMessage { get; set; }
        public string? AboutManagingTrustee { get; set; }
        public string? ManagingTrusteeImagePath { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
