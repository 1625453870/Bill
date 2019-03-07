using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common
{
    public class FilesHelper
    {
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFiles(string path)
        {
            using (var sr = new StreamReader(path, System.Text.Encoding.GetEncoding("utf-8")))
            {
                return sr.ReadToEnd().ToString();
            }
        }

    }
}
