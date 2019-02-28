using Bill.BLL;
using Bill.Common;
using Bill.Common.Extension;
using Bill.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bill.Web.Controllers
{
    public class LoginController : Controller
    {
        private CommonBLL commonbll = new CommonBLL();
        // GET: Login
        public ActionResult Login()
        {
            return PartialView();
        }

        public ActionResult Register() {
            return PartialView();
        }

        public ActionResult LoginUser(Users user)
        {
            var model=commonbll.FindEntity<Users>(p => p.Name == user.Name);

            if (model.Pwd == user.Pwd.GetMD5(model.RandomCode))
            {
                return Json(model);
            }
            return Json("账户密码错误！");
        }

        public ActionResult RegisterUser(Users user)
        {
            user.RandomCode = PublicHelper.MD5Number();
            user.Pwd = user.Pwd.GetMD5(user.RandomCode);
           var aa= commonbll.Insert<Users>(user);
            return Json(user);
        }
    }
}