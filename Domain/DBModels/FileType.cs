using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class FileType
    {
        public int FileTypeId { get; set; }
        public string? FileTypeDesc { get; set; }
        public int Active { get; set; }
    }
}
