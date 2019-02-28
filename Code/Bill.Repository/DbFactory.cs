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
            try
            {
                UnityContainer container = new UnityContainer();
                UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
                configuration.Configure(container, "defaultContainer");
                var aa = container.Resolve<IDatabase>(ConfigurationManager.AppSettings["DataBase"]);
            }
            catch (Exception e)
            {
                var aa = 1;
            }
            return UnityIocHelper.DbInstance.GetService<IDatabase>(ConfigurationManager.AppSettings["DataBase"]);

        }
    }
}
