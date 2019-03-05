using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Common.Model
{
    public class PaginationQuery
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        public string Sidx { get; set; }

        /// <summary>
        /// 排序类型，DESC或者ASC，默认DESC
        /// </summary>
        public string Sord { get; set; } = "DESC";
    }

    public class PaginationDTO<T>
    {

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 数据条数
        /// </summary>
        public int Total { get; set; }
    }
}
