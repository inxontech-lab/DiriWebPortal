using Dapper;
using DataAccess.Core;
using DataAccess.DbAccess;
using Domain.DBModels;
using Domain.RespDTO.PublicationsRespDTO;
using System;
using System.Net.Mail;

namespace DataAccess.Repository
{
    public class DataRepository : IDataRepository
    {
        private SqlDataAccess db = new SqlDataAccess();

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        public async Task<List<BookDetailsDTO>> GetBookDetails(int BookId)
        {
            string sql = " select "+
                            " bm.Id, bm.PublicationTypeId,bm.BookNameEng,bm.BookNameBn, bm.WritterName, bm.PublisherName,bm.FirstPublishedYear, " +
                            " bm.ThumbnailLocation,bm.ShortDescription,ba.Id as AttachmentId, ba.AttachmentLocation," +
                            " ba.AttachmentTittle, ba.AttachmentSerial" +
                            " from "+
                            " Publication.BookMaster bm "+
                            " inner join Publication.BookAttachment ba "+
                            " on bm.Id = ba.BookId "+
                            " where bm.id = '"+ BookId + "' order by ba.AttachmentSerial";
            var getdata = await db.LoadData<BookDetailsDTO, dynamic>(sql, new { }, ConfigClass.ConnectionString);
            return getdata;
        }


    }
}
