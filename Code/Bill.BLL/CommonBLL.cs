using Bill.Common.Model;
using Bill.DAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bill.BLL
{
    public class CommonBLL
    {
        #region 属性
        private CommonDAL dal
        {
            get
            {
                return Nested.dal;
            }
        }
        class Nested
        {

            internal static readonly CommonDAL dal = new CommonDAL();
        }

        #endregion

        #region 查询
        /// <summary>
        /// 实体查询-lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition)
            where T : class, new()
        {
            return dal.FindEntity(condition);
        }

        /// <summary>
        /// 集合查询-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">表达式</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition)
           where T : new()
        {
            return dal.FindList(condition);
        }

        /// <summary>
        /// 集合查询-分页-Lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">表达式</param>
        /// <param name="pagination">分页实体</param>
        /// <param name="total">数据总条数</param>
        /// <returns></returns>
        public PaginationDTO<IEnumerable<T>> FindPageList<T>(Expression<Func<T, bool>> condition, PaginationQuery pagination)
             where T : class, new()
        {
            return dal.FindPageList(condition, pagination);
        }

        /// <summary>
        /// 查询数据条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Count<T>(Expression<Func<T, bool>> condition)
            where T : class, new()
        {
            return dal.Count<T>(condition);
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
            return dal.Insert(t);
        }



        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Insert<T>(IEnumerable<T> list) where T : class, new()
        {
            dal.Insert(list);
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
            return dal.Update(t);
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
            return dal.Delete(t);
        }
        #endregion
    }
}
