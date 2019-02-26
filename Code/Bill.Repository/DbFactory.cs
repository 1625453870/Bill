using Bill.Common;
using Bill.Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Repository
{
    /// <summary>
    /// 数据库建立工厂
    /// </summary>
    public class DbFactory
    {
        public static IDatabase Base()
        {
            return UnityIocHelper.DbInstance.GetService<IDatabase>(ConfigurationManager.AppSettings["DataBase"]);

        }
    }
}
