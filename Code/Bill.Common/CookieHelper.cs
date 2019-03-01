using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bill.Common
{
    public class CookieHelper
    {
        private static string GetCookie(string name) {
            var Cookie = HttpContext.Current.Request.Cookies[name];
            if (Cookie != null)
            {
                return Cookie.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public static string UserId {
            get {
                return GetCookie("Id");
            }
        }
        public static string UserName
        {
            get
            {
                return GetCookie("Name");
            }
        }

    }
}
