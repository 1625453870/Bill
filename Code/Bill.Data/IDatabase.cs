using Bill.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Data
{
    public interface IDatabase
    {
        /// <summary>
        /// 集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string sql, object para = null) where T : new();

        /// <summary>
        /// 集合查询—分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="pagination">分页实体</param>
        /// <param name="total">数据总条数</param>
        /// <param name="para">参数化</param>
        /// <returns></returns>
        IEnumerable<T> FindPageList<T>(string sql, PaginationQuery pagination, out int total, object para = null)
            where T : new();
      
        /// <summary>
        /// 集合查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">表达式</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition)
           where T : new();

        /// <summary>
        /// 集合查询-分页-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">表达式</param>
        /// <param name="pagination">分页实体</param>
        /// <param name="total">数据总条数</param>
        /// <returns></returns>
        IEnumerable<T> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination, out int total)
             where T : class, new();

        /// <summary>
        /// 实体查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        /// <returns></returns>
        T FindEntity<T>(string sql, object para = null)
           where T : class, new();

        /// <summary>
        /// 实体查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        T FindEntity<T>(Expression<Func<T, bool>> condition)
            where T : class, new();
    }
}
