using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Request
    {
        public Request()
        {
            ChangeAddresses = new HashSet<ChangeAddress>();
            ChangeHcForms = new HashSet<ChangeHcForm>();
            Exemptions = new HashSet<Exemption>();
            MedicationRefillForms = new HashSet<MedicationRefillForm>();
            MobileUnitForms = new HashSet<MobileUnitForm>();
            RadiologyRequests = new HashSet<RadiologyRequest>();
            SehatiCardRequests = new HashSet<SehatiCardRequest>();
        }

        public int RequestId { get; set; }
        public int RequesterId { get; set; }
        public string? RefNumber { get; set; }
        public int StatusId { get; set; }
        public string? Note { get; set; }
        public int? RequestTypeId { get; set; }
        public int Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Requester Requester { get; set; } = null!;
        public virtual RequestStatus Status { get; set; } = null!;
        public virtual ICollection<ChangeAddress> ChangeAddresses { get; set; }
        public virtual ICollection<ChangeHcForm> ChangeHcForms { get; set; }
        public virtual ICollection<Exemption> Exemptions { get; set; }
        public virtual ICollection<MedicationRefillForm> MedicationRefillForms { get; set; }
        public virtual ICollection<MobileUnitForm> MobileUnitForms { get; set; }
        public virtual ICollection<RadiologyRequest> RadiologyRequests { get; set; }
        public virtual ICollection<SehatiCardRequest> SehatiCardRequests { get; set; }
    }
}
