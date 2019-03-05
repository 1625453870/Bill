using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符空判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            return false;
        }

        /// <summary>
        /// 直接格式化字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatMe(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        /// <summary>
        /// 转化为32位int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(this string str)
        {
            return Int32.Parse(str);
        }

        /// <summary>
        /// 转换时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            return DateTime.Parse(str);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="myString">加密字符串</param>
        /// <param name="salt">随机加密码</param>
        /// <returns></returns>
        public static string GetMD5(this string str, string salt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(str + salt);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }
    }
}
