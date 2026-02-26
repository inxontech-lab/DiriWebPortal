using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Exemption
    {
        public int ExemptionId { get; set; }
        public string? RequestedCpr { get; set; }
        public int? PreviousBlock { get; set; }
        public string? Mobile { get; set; }
        public int RequestId { get; set; }
        public int? ExemptionRequestTypeId { get; set; }
        public string? PreviousCardNumber { get; set; }
        public string? SecondContactNumber { get; set; }
        public string? Email { get; set; }
        public int? NationalityId { get; set; }
        public string? Gender { get; set; }
        public int? MaritalStatusId { get; set; }
        public string? Occupation { get; set; }
        public int? SpouseNationalityId { get; set; }
        public string? Note { get; set; }
        public int? Active { get; set; }
        public string? CprFile { get; set; }
        public string? ResidencePermit { get; set; }
        public string? MarriageCertificate { get; set; }
        public string? DivorceCertificate { get; set; }
        public string? DeathCertificate { get; set; }
        public string? BirthCertificate { get; set; }
        public string? MedicalReport { get; set; }

        public virtual Request Request { get; set; } = null!;
    }
}
