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
            if (query.MonthNumber > 0)
            {
                query.StartDateTime = DateTime.Now.AddMonths(0 - query.MonthNumber);
            }
            Expression<Func<Bills, bool>> expression = p => p.UpdateTime >= query.StartDateTime && p.UpdateTime <= query.EndDateTime;
            if (query.BillsTypes > 0)
            {
                expression = expression.And(p => p.BillsTypeId == query.BillsTypes);
            }
            return Json(commonbll.FindPageList<Bills>(expression, query.Page));
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
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            commonbll.Delete<Bills>(new Bills { Id = id });
        }
        
    }
}