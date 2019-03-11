using Bill.Common.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Data
{
    public class DatabaseCommon
    {
        /// <summary>
        /// 拼接 查询 SQL语句，自定义条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <param name="allFieid">是否查询所有字段</param>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>(string where, bool allFieid = false) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();
            if (allFieid)
            {
                sbColumns.Append(" * ");
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    //string propertytype = prop.PropertyType.ToString();
                    sbColumns.Append("[" + prop.Name + "],");
                }
                if (sbColumns.Length > 0) sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            }

            if (string.IsNullOrWhiteSpace(where)) where = " WHERE 1 = 1";

            string strSql = "SELECT {0} FROM {1} {2}";
            strSql = string.Format(strSql, sbColumns.ToString(), table + " ", where);
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="allFieid"></param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(string where, bool allFieid = false) where T : new()
        {
            if (string.IsNullOrWhiteSpace(where)) where = " WHERE 1 = 1";
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            var sql = $"DELETE FROM {table} {where}";
            return new StringBuilder(sql);
        }
    }
}
