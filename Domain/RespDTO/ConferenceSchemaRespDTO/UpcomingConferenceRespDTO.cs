using Domain.DBModels;
using Domain.DTO.ConferenceSchemaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.ConferenceSchemaRespDTO
{
    public class UpcomingConferenceRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public List<ConferenceDetailsDTO>? _lstConferenceDetailsDTO { get; set; }
    }
}
