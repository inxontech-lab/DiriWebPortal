using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class UniversityDepartmentMap
    {
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
        public int Acive { get; set; }
    }
}
