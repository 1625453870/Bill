using Bill.BLL;
using Bill.Common.Extension;
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
    /// 用户
    /// </summary>
    public class LoginController : BaseApiController
    {
        private CommonBLL commonbll = new CommonBLL();
        private UsersBLL userbll = new UsersBLL();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        public Users Login(string name, string pwd)
        {
            var model = commonbll.FindEntity<Users>(p => p.Name == name);

            if (model.Pwd == pwd.GetMD5(model.RandomCode))
            {
                return model;
            }
            return new Users();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Users RegisterUser(Users user)
        {

            userbll.Insert(user);
            return commonbll.FindEntity<Users>(p => p.Name == user.Name);

        }
    }
}
