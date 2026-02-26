using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class VideoPresenterCategoryMaster
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public int? Active { get; set; }
    }
}
