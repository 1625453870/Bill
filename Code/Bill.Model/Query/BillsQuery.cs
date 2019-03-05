using Bill.Common.Extension;
using Bill.Common.Model;
using System;

namespace Bill.Model.Query
{
    public class BillsQuery 
    {
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                _startDateTime = value.ToString("yyyy-MM-dd").ToDateTime();
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set
            {
                _endDateTime = value.ToString("yyyy-MM-dd").ToDateTime();
            }
        }

        /// <summary>
        /// 账单类型
        /// </summary>
        public int BillsTypes { get; set; }

        /// <summary>
        /// 月份数目
        /// </summary>
        public int MonthNumber { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PaginationQuery Page { get; set; }
    }
}
