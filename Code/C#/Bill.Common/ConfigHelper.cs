using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common
{
   public static class ConfigHelper
    {
        /// <summary>
        /// 取配置文件节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T GetSection<T>(string sectionName) where T : class, new()
        {
            T res = ConfigurationManager.GetSection(sectionName) as T;
            return res;
        }
    }
}
