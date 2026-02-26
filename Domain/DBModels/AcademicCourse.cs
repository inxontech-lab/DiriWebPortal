using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class AcademicCourse
    {
        public int Id { get; set; }
        public string? CourseTittle1 { get; set; }
        public string? CourseTittle2 { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseBanner { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
