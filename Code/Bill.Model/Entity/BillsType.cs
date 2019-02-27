using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Bill.Model.Entity
{
    /// <summary>
    ///账单类型
    /// </summary>
    public class BillsType
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 账单名称
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 账单logo
        /// </summary>		
        public string Logo { get; set; }
        /// <summary>
        /// 创建人编码
        /// </summary>		
        public int NickName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Describe { get; set; }

    }
}

