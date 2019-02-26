using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Repository.Repository
{
    /// <summary>
    /// 定义仓储模型工厂
    /// </summary>
    public class RepositoryFactory
    {
        protected Bill.Repository.IRepository.IRepository BaseRepository(DatabaseLinksEnum link = DatabaseLinksEnum.SqlService)
         {

            switch (link)
            {
                case DatabaseLinksEnum.SqlService:
                    return Nested.sqlRepository;
                default:
                    return Nested.sqlRepository;

            }
        }

        class Nested
        {
            internal static readonly Repository sqlRepository = new Repository(DbFactory.Base());
        }
    }
}
