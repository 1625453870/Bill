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
    public class DefaultController : ApiController
    {
        [HttpGet]
        public void aa()
        { }

        private CommonBLL commonbll = new CommonBLL();

        /// <summary>
        /// 账单类型集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BillsType> FindList()
        {
            return commonbll.FindList<BillsType>(p => p.UserId == 1);
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

    }
}
