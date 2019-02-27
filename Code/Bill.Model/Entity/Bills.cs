﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Bill.Model.Entity
{
    /// <summary>
    ///账单
    /// </summary>
    public class Bills
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 账单类型编码
        /// </summary>		
        public int Name { get; set; }
        /// <summary>
        /// 金额
        /// </summary>		
        public decimal Logo { get; set; }
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

