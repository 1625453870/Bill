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
        #region 查询
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
        PaginationDTO<IEnumerable<T>> FindPageList<T>(string sql, PaginationQuery pagination, object para = null)
            where T : new();

        /// <summary>
        /// 分页查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="pagination">分页实体</param>
        /// <returns></returns>
        PaginationDTO<IEnumerable<T>> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination)
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
        #endregion

        #region 新增
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        dynamic Insert<T>(T t) where T : class, new();

        /// <summary>
        /// 新增sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        void Insert(string sql, object para = null);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        void Insert<T>(IEnumerable<T> list) where T : class, new();
        #endregion

        #region 修改
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update<T>(T t) where T : class, new();

        /// <summary>
        /// 修改sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        void Update(string sql, object para = null);
        #endregion

        #region 删除
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete<T>(T t) where T : class, new();

        /// <summary>
        /// sql删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        void Delete(string sql, object para = null);
        #endregion
    }
}
