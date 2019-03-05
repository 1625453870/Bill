using Bill.Common.Extension;
using Bill.Common.Model;
using System;
using Bill.Common.Extension;
namespace Bill.Model.Query
{
    public class BillsQuery
    {
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                if (value.HasValue)
                    _startDateTime = ((DateTime)value).ToString("yyyy-MM-dd").ToDateTime();
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTime
        {
            get { return _endDateTime; }
            set
            {
                if (value.HasValue)
                    _endDateTime = (((DateTime)value).ToString("yyyy-MM-dd")+" 23:59:59").ToDateTime();
            }
        }

        /// <summary>
        /// 账单类型
        /// </summary>
        public int? BillsTypeId { get; set; }

  
        /// <summary>
        /// 分页
        /// </summary>
        public PaginationQuery Pagination { get; set; }
    }
}
