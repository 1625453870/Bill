using Bill.BLL;
using Bill.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bill.Api.Controllers
{
    /// <summary>
    /// 账单类型
    /// </summary>
    public class BillsTypeController : BaseApiController
    {
        private CommonBLL commonbll = new CommonBLL();

        /// <summary>
        /// 账单类型集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BillsType> FindList()
        {
            return commonbll.FindList<BillsType>(p => p.UserId == userId);
        }

        /// <summary>
        /// 账单类型新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(BillsType model)
        {
            return commonbll.Insert(model);
        }

        /// <summary>
        /// 账单类型修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(BillsType model)
        {
            return commonbll.Update(model);
        }
    }
}
