using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common
{
   public sealed class UnityIocHelper
    {
        private readonly IUnityContainer _container;
        /// <summary>
        /// 获取DbContainer
        /// </summary>
        private static readonly UnityIocHelper Dbinstance = new UnityIocHelper("DbContainer");

        /// <summary>
        /// 获取DbContainer对象
        /// </summary>
        public static UnityIocHelper DbInstance => Nested.instance;

        class Nested
        {
            static Nested() { }
            internal static readonly UnityIocHelper instance = Dbinstance;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="containerName"></param>
        private UnityIocHelper(string containerName)
        {
            try
            {
                _container = new UnityContainer();
                var configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
                configuration.Configure(_container, containerName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
   
        public T  GetService<T>(string name)
        {
            T res = _container.Resolve<T>(name);
            return res;
        }
    }
}
