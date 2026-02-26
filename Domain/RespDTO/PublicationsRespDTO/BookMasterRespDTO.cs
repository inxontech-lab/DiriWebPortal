using Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.PublicationsRespDTO
{
    public class BookMasterRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public List<BookMaster> lstData { get; set; }
    }
}
