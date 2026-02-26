using Domain.DTO.JournalSchemaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.JournalSchemaRespDTO
{
    public class JournalDetailsRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public JournalDTO? JournalDTO { get; set; }
    }
}
