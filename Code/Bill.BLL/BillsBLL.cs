using Bill.Common.Model;
using Bill.DAL;
using Bill.Model.DTO;
using Bill.Model.Entity;
using Bill.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bill.BLL
{
    public class BillsBLL
    {
        private BillsDAL dal = new BillsDAL();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public PaginationDTO<IEnumerable<BillsDTO>> FindPageList(BillsQuery query, PaginationQuery pagination)
        {
            return dal.FindPageList(query, pagination);
        }

        public IEnumerable<BillsDTO> FindMonth(BillsQuery query)
        {
            return dal.FindMonth(query);
        }
    }
}
