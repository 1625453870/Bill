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
        private UsersBLL userbll = new UsersBLL();
        // GET: Login
        public ActionResult Login()
        {
            return PartialView();
        }

        public ActionResult Register()
        {
            return PartialView();
        }

        public ActionResult LoginUser(Users user)
        {
            var model = commonbll.FindEntity<Users>(p => p.Name == user.Name);

            if (model.Pwd == user.Pwd.GetMD5(model.RandomCode))
            {
                return Json(model);
            }
            return Json("账户密码错误！");
        }

        public ActionResult RegisterUser(Users user)
        {
            userbll.Insert(user);
            return Json(user);
        }
    }
}