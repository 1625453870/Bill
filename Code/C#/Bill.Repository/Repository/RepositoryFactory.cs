﻿using System;
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
        protected Bill.Repository.IRepository.IRepository db
        {
            get
            {
                return BaseRepository();
            }
        }
        private Bill.Repository.IRepository.IRepository BaseRepository(DatabaseLinksEnum link = DatabaseLinksEnum.SqlService)
        {

            switch (link)
            {
                case DatabaseLinksEnum.SqlService:
                    return new Repository(DbFactory.Base());
                default:
                    return Nested.sqlRepository;

            }
        }

        class Nested
        {
            static Nested() { }
            internal static readonly Repository sqlRepository = new Repository(DbFactory.Base());
        }
    }
}
