using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Repository.IRepository
{
    public interface IRepository
    {
        /// <summary>
        /// 对象查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T FindEntity<T>() where T : new();

        /// <summary>
        /// 集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> FindList<T>() where T : new();


    }
}
