using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            Requests = new HashSet<Request>();
        }

        public int StatusId { get; set; }
        public string StatusDesc { get; set; } = null!;
        public int Active { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
