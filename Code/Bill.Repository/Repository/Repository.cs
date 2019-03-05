using Bill.Common.Model;
using Bill.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bill.Repository.Repository
{
    /// <summary>
    /// 定义仓储模型中的数据标准操作
    /// </summary>
    public class Repository : Bill.Repository.IRepository.IRepository
    {
        private readonly IDatabase db;

        public Repository(IDatabase iDatabase)
        {
            this.db = iDatabase;
        }

        #region 查询
        /// <summary>
        /// 集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string sql, object para = null)
            where T : new()
        {
            return db.FindList<T>(sql, para);
        }

        /// <summary>
        /// 集合查询—分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="pagination">分页实体</param>
        /// <param name="total">数据总条数</param>
        /// <param name="para">参数化</param>
        /// <returns></returns>
       public PaginationDTO<IEnumerable<T>> FindPageList<T>(string sql, PaginationQuery pagination, object para = null)
            where T : new()
        {
            return db.FindPageList<T>(sql, pagination, para);
        }

        /// <summary>
        /// 分页查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="pagination">分页实体</param>
        /// <returns></returns>
        public PaginationDTO<IEnumerable<T>> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination)
             where T : new()
        {
            return db.FindPageList<T>(condition, pagination);
        }

        /// <summary>
        /// 集合查询（Lambda）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition)
               where T : new()
        {
            return db.FindList<T>(condition);
        }

      

        /// <summary>
        /// 查询实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public T FindEntity<T>(string sql, object para = null)
             where T : class, new()
        {
            return db.FindEntity<T>(sql, para);
        }

        /// <summary>
        /// 集合查询（Lambda）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition)
            where T : class, new()
        {
            return db.FindEntity<T>(condition);
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public dynamic Insert<T>(T t) where T : class, new()
        {
            return db.Insert(t);
        }

        /// <summary>
        /// 新增sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        public void Insert(string sql, object para = null)
        {
            db.Insert(sql, para);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Insert<T>(IEnumerable<T> list) where T : class, new()
        {
            db.Insert(list);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update<T>(T t) where T : class, new()
        {
            return db.Update(t);
        }

        /// <summary>
        /// 修改sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        public void Update(string sql, object para = null)
        {
            db.Update(sql, para);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete<T>(T t) where T : class, new()
        {
            return db.Delete(t);
        }

        /// <summary>
        /// sql删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        public void Delete(string sql, object para = null)
        {
            db.Delete(sql, para);
        }
        #endregion
    }
}
