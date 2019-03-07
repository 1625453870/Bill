using Bill.Common;
using Bill.Common.Extension;
using Bill.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.BLL
{
    public class UsersBLL
    {
        private CommonBLL commbll = new CommonBLL();
        /// <summary>
        /// 用户新增
        /// </summary>
        /// <param name="user"></param>
        public void Insert(Users user)
        {
           
            commbll.Insert(SetPwd(user));
        }

        /// <summary>
        /// 用户新增
        /// </summary>
        /// <param name="user"></param>
        public void Insert(IEnumerable<Users> list)
        {
            list.ToList().ForEach(p =>
            {
                SetPwd(p);
            });
            commbll.Insert(list);
        }

        private Users SetPwd(Users user)
        {
            user.RandomCode = PublicHelper.MD5Number();
            user.Pwd = user.Pwd.GetMD5(user.RandomCode);
            return user;
        }
    }
}
