using Bill.BLL;
using Bill.Common;
using Bill.Common.Extension;
using Bill.Model.Entity;
using Bill.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bill.Web.Controllers
{
    public class BillsTypeController : Controller
    {
        private CommonBLL commonbll = new CommonBLL();
        // GET: BillsType
        public ActionResult Index()
        {
            return View(FindList());
        }

        public IEnumerable<BillsType> FindList()
        {
            var userId = CookieHelper.UserId.ToInt32();
            return commonbll.FindList<BillsType>(p => p.UserId == userId || p.IsSystem == true);
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                return PartialView(commonbll.FindEntity<BillsType>(p => p.Id == id));
            }
            return PartialView(new BillsType());
        }

        public void EditData(BillsType model)
        {
            model.UserId = CookieHelper.UserId.ToInt32();
            if (model.Id <= 0)
            {
                commonbll.Insert(model);
            }
            else
                commonbll.Update(model);
        }

        public void Delete(int id)
        {
            commonbll.Delete<BillsType>(p => p.Id == id && p.IsSystem != true);
        }
    }
}