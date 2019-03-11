using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common
{
    public static class PublicHelper
    {
        public static string MD5Number()
        {
            var number = new Random().Next(100000, 999999).ToString();
            return number;
        }
    }
}
