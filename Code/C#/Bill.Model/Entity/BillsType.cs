﻿using System;
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
        public int UserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreationTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 描述
        /// </summary>		
        public string Describe { get; set; }

        /// <summary>
        /// 是否是默认
        /// </summary>		
        public bool IsDefault { get; set; }
        
        /// <summary>
        /// 是否是系统自动生成
        /// </summary>
        public bool IsSystem { get; set; }



    }
}

