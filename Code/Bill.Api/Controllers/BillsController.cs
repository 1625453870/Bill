using Bill.BLL;
using Bill.Common.Model;
using Bill.Model;
using Bill.Model.DTO;
using Bill.Model.Entity;
using Bill.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bill.Api.Controllers
{
    /// <summary>
    /// 账单
    /// </summary>
    public class BillsController : BaseApiController
    {
        private CommonBLL commonbll = new CommonBLL();
        private BillsBLL billsbll = new BillsBLL();

        /// <summary>
        /// 账单查询
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpPost]
        public PaginationDTO<IEnumerable<BillsDTO>> FindList(BillsQuery query, PaginationQuery pagination)
        {
           return billsbll.FindPageList(query, pagination);
        }


        /// <summary>
        /// 账单新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(Bills model)
        {
            return commonbll.Insert(model);
        }

        /// <summary>
        /// 账单修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(Bills model)
        {
            return commonbll.Update(model);
        }
    }
}
