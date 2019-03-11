using Bill.BLL;
using Bill.Common;
using Bill.Common.Extension;
using Bill.Common.Model;
using Bill.Model.DTO;
using Bill.Model.Entity;
using Bill.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Bill.Model;

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
            query.Pagination.Sord = "desc";
            query.Pagination.Sidx = "UpdateTime";
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

        public ActionResult GetNowMonth_Left()
        {
            var data = billsbll.FindMonth(new BillsQuery { StartDateTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd").ToDateTime(), EndDateTime = DateTime.Now });
            var dict = new Dictionary<string, decimal>();
            data.ToList().ForEach(p =>
            {
                if (dict.ContainsKey(p.BillsTypeName))
                    dict[p.BillsTypeName] = dict[p.BillsTypeName] + p.Money;
                else
                    dict[p.BillsTypeName] = p.Money;
            });
            return Json(dict);
        }

        public ActionResult GetNowMonth_Rigth()
        {
            var data = billsbll.FindMonth(new BillsQuery { StartDateTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd").ToDateTime(), EndDateTime = DateTime.Now });
            var dict = new Dictionary<string, Dictionary<string, decimal>>();
            var dictType = new Dictionary<string, decimal>();

            for (DateTime i = DateTime.Now.AddDays(1 - DateTime.Now.Day); i <= DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1); i = i.AddDays(1))
            {
                dictType = new Dictionary<string, decimal>();
                var list = data.Where(p => p.UpdateTime.ToString("yyyy-MM-dd") == i.ToString("yyyy-MM-dd")).ToList();
                if (list.Count() > 0)
                {
                    list.ForEach(p =>
                    {
                        if (dictType.ContainsKey(p.BillsTypeName))
                            dictType[p.BillsTypeName] = dictType[p.BillsTypeName] + p.Money;
                        else
                            dictType[p.BillsTypeName] = p.Money;
                    });
                    dict[i.ToString("yyyy-MM-dd")] = dictType;
                }
                else
                {
                    dict[i.ToString("yyyy-MM-dd")] = new Dictionary<string, decimal>();
                }
            }
            return Json(dict);
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