using Bill.BLL;
using Bill.Common;
using Bill.Common.Extension;
using Bill.Common.Model;
using Bill.Model.Entity;
using Bill.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Bill.Web.Controllers
{
    public class BillsController : Controller
    {
        private CommonBLL commonbll = new CommonBLL();
        private BillsBLL billsbll = new BillsBLL();
        // GET: Bills
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                return PartialView(commonbll.FindEntity<Bills>(p => p.Id == id));
            }
            return PartialView(new Bills());
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ActionResult FindList(BillsQuery query)
        {
            query.Pagination.Page += 1;
            var data = billsbll.FindPageList(query, query.Pagination);
            var result = new
            {
                code = 0,
                msg = "",
                count = data.Total,
                data = data.Data
            };
            return Json(result);
        }

        public ActionResult GetNowMonth()
        {
            return Json(billsbll.FindMonth());
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public void EditData(Bills model)
        {
            if (model.Id > 0)
            {
                commonbll.Update<Bills>(model);
            }
            else
                commonbll.Insert<Bills>(model);
        }

        /// <summary>
        /// 得到数据总数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ActionResult Count(BillsQuery query)
        {
            Expression<Func<Bills, bool>> expression = p => p.UpdateTime >= query.StartDateTime && p.UpdateTime <= query.EndDateTime;
            if (query.BillsTypeId > 0)
            {
                expression = expression.And(p => p.BillsTypeId == query.BillsTypeId);
            }
            return Content(commonbll.Count<Bills>(expression).ToString());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            commonbll.Delete<Bills>(new Bills { Id = id });
        }

    }
}