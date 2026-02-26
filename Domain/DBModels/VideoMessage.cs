using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class VideoMessage
    {
        public int Id { get; set; }
        public int VideoPresenterCategoryId { get; set; }
        public string? VideoMessageLocation { get; set; }
        public string? PresenterName { get; set; }
        public string? PresenterDesignation { get; set; }
        public int? Active { get; set; }
    }
}
