using Bill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using DapperLambda;
using Dapper;
using Bill.Common.Model;
using System.Linq.Expressions;
using DapperExtensions;

namespace Bill.Dapper
{
    public class MsSqlDatabase : Bill.Data.IDatabase
    {
        class Nested
        {
            internal static readonly string connString = ConfigurationManager.ConnectionStrings["SqlBaseDbConnectionString"].ToString();
        }

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// 获取 数据库连接串
        /// </summary>
        private IDbConnection  Connection
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


        /// <summary>
        /// 获取DapperLambda数据连接
        /// </summary>
        private DbContext Context
        {
            get
            {
                return new DbContext().ConnectionString(ConnectionString, DatabaseType.MSSQLServer);

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
        /// 分页集合查询（Lambda）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList<T>(string sql, PaginationQuery pagination, out int total, object para = null)
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
                total = (int)db.ExecuteScalar(selectCountSql, para);
                return db.Query<T>(sqls, para).ToList();
            }
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
            using (var db = Context)
            {
                return db.Select<List<T>>(condition);
            }
        }

        /// <summary>
        /// 分页集合查询（Lambda）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination, out int total)
               where T : class, new()
        {
            using (var db = Context)
            {
                return db.Select<T>(condition).QueryPage(pagination.Page, pagination.Rows, out total);
            }
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
            using (var db = Context)
            {
                return db.Select<T>(condition).QuerySingle();
            }
        }
        #endregion

        #region 新增
        public void  Insert<T>(T t) where T:class,new()
        {
            using (var db = Connection)
            {
                 db.Insert(t);
             }
        }
        #endregion



    }
}
