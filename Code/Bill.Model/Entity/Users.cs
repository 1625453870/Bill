using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Bill.Model.Entity
{
    /// <summary>
    ///用户
    /// </summary>
    public class Users
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>		
        public string Pwd { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>		
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>		
        public string Logo { get; set; }
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

