using Bill.Common;
using Bill.Common.Extension;
using Bill.Common.Model;
using Bill.Model.DTO;
using Bill.Model.Entity;
using Bill.Model.Query;
using Bill.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bill.DAL
{
    public class BillsDAL : RepositoryFactory
    {
        public PaginationDTO<IEnumerable<BillsDTO>> FindPageList(BillsQuery query, PaginationQuery pagination)
        {
            var where = string.Empty;
            if (query.StartDateTime.HasValue)
                where += "AND (a.UpdateTime BETWEEN @StartDateTime AND @EndDateTime)";
            if (query.BillsTypeId.HasValue)
                where += " AND a.BillsTypeId =@BillsTypeId";
            var sql = @"
SELECT a.*,a.UpdateTime AS DateTime,b.Name AS BillsTypeName FROM Bills a
JOIN BillsType b ON a.BillsTypeId =b.Id
WHERE 1=1 {0}

".FormatMe(where);
            return db.FindPageList<BillsDTO>(sql, pagination, new { StartDateTime = query.StartDateTime, EndDateTime = query.EndDateTime, BillsTypeId = query.BillsTypeId });
        }

        /// <summary>
        /// 当月数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BillsDTO> FindMonth(BillsQuery query)
        {
            var where = string.Empty;
            if (query.StartDateTime.HasValue)
                where += "AND (a.UpdateTime BETWEEN @StartDateTime AND @EndDateTime)";
            var sql = @"
SELECT a.* , b.Name AS BillsTypeName
FROM Bills a
JOIN BillsType b ON a.BillsTypeId =b.Id
WHERE a.UserId =@UserId {0}
".FormatMe(where);
            return db.FindList<BillsDTO>(sql, new
            {
                StartDateTime =query.StartDateTime,
                EndDateTime = query.EndDateTime,
                UserId = CookieHelper.UserId.ToString()
            });
        }
    }
}
