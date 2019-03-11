using Bill.Common;
using Bill.Data;
using Bill.Data.Dapper;
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
            var aa = typeof(MsSqlDatabase);
            var configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            var container = new UnityContainer();
            configuration.Configure(container, "DbContainer");
            return container.Resolve<IDatabase>(ConfigurationManager.AppSettings["DataBase"]);

        }
    }
}
