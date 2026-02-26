using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class RequestType
    {
        public int RequestTypeId { get; set; }
        public string? RequestTypeDesc { get; set; }
        public int Active { get; set; }
    }
}
