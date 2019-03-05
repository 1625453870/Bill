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
    public class BillsDAL: RepositoryFactory
    {
        public PaginationDTO<IEnumerable<BillsDTO>> FindPageList(BillsQuery query, PaginationQuery pagination)
        {
            var where = string.Empty;
            if (query.StartDateTime.HasValue)
                where += " a.UpdateTime BETWEEN @StartDateTime AND @EndDateTime";
            if (query.BillsTypeId.HasValue)
                where += " a,BillsTypeId =@BillsTypeId";
            var sql = @"
SELECT a.*,b.Name AS BillsTypeName FROM Bills a
JOIN BillsType b ON a.BillsTypeId =b.Id
WHERE {0}

".FormatMe(where);
            return db.FindPageList<BillsDTO>(sql, pagination, new { StartDateTime = query.StartDateTime, EndDateTime = query.EndDateTime, BillsTypeId = query.BillsTypeId });
        }
    }
}
