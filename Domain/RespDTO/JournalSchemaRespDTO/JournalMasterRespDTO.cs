using Domain.DBModels;
using Domain.DTO.JournalSchemaDTO;
using Domain.RespDTO.PublicationsRespDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.JournalSchemaRespDTO
{
    public class JournalMasterRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public List<JournalVolumeDTO>? lstData { get; set; }
    }
}
