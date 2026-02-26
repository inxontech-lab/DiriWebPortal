using Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.AboutUsPageRespDTO
{
    public class ManagingTrusteeArticlesRespDTO
    {
        public string RESPONSE_CODE { get; set; }
        public string RESPONSE_DESCRPTION { get; set; }
        public List<ManagingTrusteeArticle>? managingTrusteeArticle { get; set; }
    }
}
