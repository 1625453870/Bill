using Bill.Common.LambdaToSQL;
using Bill.Common.Model;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Bill.Data.Dapper
{
    public class MsSqlDatabase : IDatabase
    {
        class Nested
        {
            internal static readonly string connString = ConfigurationManager.ConnectionStrings["SqlBaseDbConnectionString"].ToString();
        }

        #region 属性



        /// <summary>
        /// 获取 数据库连接串
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                var dbconnection = new SqlConnection(Nested.connString);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                return dbconnection;
            }

        }

        #endregion 属性

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
            using (var db = Connection)
            {
                return db.Query<T>(sql, para).ToList();
            }
        }

        /// <summary>
        /// 分页集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public PaginationDTO<IEnumerable<T>> FindPageList<T>(string sql, PaginationQuery pagination, object para = null)
               where T : new()
        {
            using (var db = Connection)
            {
                var orderBy = "";
                if (!string.IsNullOrEmpty(pagination.Sidx))
                {
                    if (pagination.Sord.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + pagination.Sord.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + pagination.Sord;
                    }
                    else
                    {
                        orderBy = "Order By " + pagination.Sidx + " " + pagination.Sord.ToUpper();
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                var sqls = string.Format(@"
Select * From (Select ROW_NUMBER() Over ({0})
As rowNum, * From ({1}) As T ) As N Where rowNum > {2} And rowNum <= {3}
", orderBy, sql, (pagination.Page - 1) * pagination.Rows, pagination.Page * pagination.Rows);
                string selectCountSql = "Select Count(*) From (" + sql + ") AS t";
                return new PaginationDTO<IEnumerable<T>>
                {
                    Data = db.Query<T>(sqls, para).ToList(),
                    Total = (int)db.ExecuteScalar(selectCountSql, para)
                };
            }
        }

        /// <summary>
        /// 分页查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public PaginationDTO<IEnumerable<T>> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination)
            where T : new()
        {
            var lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();
            return FindPageList<T>(sql, pagination);
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

            var lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();
            return this.FindList<T>(sql);

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
            using (var db = Connection)
            {
                return db.QueryFirst<T>(sql, para);
            }
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
            var lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();
            return FindEntity<T>(sql);
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
            using (var db = Connection)
            {
                return db.Insert(t);
            }
        }

        /// <summary>
        /// 新增sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        public void Insert(string sql, object para = null)
        {

            using (var db = Connection)
            {
                db.Execute(sql, para);
            }
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Insert<T>(IEnumerable<T> list) where T : class, new()
        {
            using (var db = Connection)
            {
                db.Insert(list);
            }
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
            using (var db = Connection)
            {
                return db.Update(t);
            }
        }

        /// <summary>
        /// 修改sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="para">参数化</param>
        public void Update(string sql, object para = null)
        {

            using (var db = Connection)
            {
                db.Execute(sql, para);
            }
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
            using (var db = Connection)
            {
                return db.Delete(t);
            }
        }

        /// <summary>
        /// sql删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        public void Delete(string sql, object para = null)
        {

            using (var db = Connection)
            {
                db.Execute(sql, para);
            }
        }
        #endregion


    }
}
