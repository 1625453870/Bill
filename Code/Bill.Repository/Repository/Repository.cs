using Bill.Data;
using System.Collections.Generic;

namespace Bill.Repository.Repository
{
    /// <summary>
    /// 定义仓储模型中的数据标准操作
    /// </summary>
    public class Repository: Bill.Repository.IRepository.IRepository
    {
        private readonly IDatabase _db;

        public Repository(IDatabase iDatabase)
        {
            this._db = iDatabase;
        }

        /// <summary>
        /// 对象查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FindEntity<T>() where T : new() {
            return new T();
        }

        /// <summary>
        /// 集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindList<T>() where T : new() {
            return new List<T>();
        }
    }
}
