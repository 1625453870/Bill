using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Repository.IRepository
{
    /// <summary>
    /// 定义仓储模型中的数据标准操作接口
    /// </summary>
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
