using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bill.Api.Models
{
    public class BaseJsonResult<T>
    {
        /// <summary>
        /// 状态编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum BaseJsonResultEnum
    {
        成功 = 200,
        错误提示 = 101,
        异常 = 500
    }
}