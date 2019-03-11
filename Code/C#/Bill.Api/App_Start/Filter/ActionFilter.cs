using Bill.Api.Models;
using Bill.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Bill.Api.App_Start.Filter
{
    public class ActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 输入拦截器
        /// </summary>
        /// <param name="actionContext"></param>
        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    if (!actionContext.ModelState.IsValid)
        //    {
        //        if (actionContext.Request.RequestUri.ToString().IndexOf("GetEventPages") < 0 && actionContext.Request.RequestUri.ToString().IndexOf("GetEventList") < 0)
        //        {
        //            StringBuilder sb = new StringBuilder();
        //            foreach (var m in actionContext.ModelState)
        //            {
        //                string[] key = m.Key.Split(".".ToCharArray());
        //                string err = key.Length == 2 ? key[1] + "^" : "";

        //                ModelErrorCollection errors = m.Value.Errors;
        //                foreach (ModelError error in errors)
        //                {
        //                    err += error.ErrorMessage + ",";
        //                }
        //                err = err.Substring(0, err.Length - 1) + "|";
        //                sb.Append(err);
        //            }

        //            HttpResponseMessage response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
        //            response.StatusCode = actionContext.Response.StatusCode;
        //            response.Content = new StringContent(
        //                new BaseJsonResult<string>
        //                {
        //                    Status = (int)JsonObjectStatus.Fail,
        //                    Data = null,
        //                    Message = sb.ToString().Substring(0, sb.ToString().Length - 1),
        //                    BackUrl = null
        //                }.TryToJson(), Encoding.UTF8, "application/json");
        //        }
        //    }
        //    base.OnActionExecuting(actionContext);
        //}


        /// <summary>
        /// 输出拦截器
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //异常
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                actionExecutedContext.Response.Content = new StringContent(
                         new BaseJsonResult<string>
                         {
                             Code = (int)BaseJsonResultEnum.异常,
                             Data = null,
                             Message = "异常信息：" + actionExecutedContext.Exception.Message,
                         }.TryToJson(), Encoding.UTF8, "application/json");
            }
            else
            {
                if (actionExecutedContext.Response.Content == null)
                {
                    //actionExecutedContext.Response.Content = new StringContent(
                    // JsonConvert.SerializeObject(new ResultPacket()
                    // {
                    //     IsError = false,
                    //     ResponseData = null
                    // }));
                }
                else
                {
                    object result;
                    if (actionExecutedContext.Response.Content is ObjectContent)
                        result = (actionExecutedContext.Response.Content as ObjectContent).Value;
                    else
                        result = System.Text.Encoding.UTF8.GetString(actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result);

                    if (actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result.Length > 1024 * 100)
                    {
                        byte[] compressedData = Compress(System.Text.Encoding.UTF8.GetBytes(result.TryToJson()));
                        actionExecutedContext.Response.Content = new ByteArrayContent(compressedData);
                        actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
                        actionExecutedContext.Response.Content.Headers.Add("Content-encoding", "gzip");
                        actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    }
                    else
                        actionExecutedContext.Response.Content = new StringContent(new BaseJsonResult<object>
                        {
                            Code = (int)BaseJsonResultEnum.成功,
                            Data = result,
                            Message = "请求成功！",
                        }.TryToJson(), Encoding.UTF8, "application/json");
                }
            }
            base.OnActionExecuted(actionExecutedContext);
        }
        /// <summary>
		/// GZip压缩
		/// </summary>
		/// <param name="rawData"></param>
		/// <returns></returns>
		private static byte[] Compress(byte[] rawData)
        {
            var ms = new MemoryStream();
            using (var compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true))
            {
                compressedzipStream.Write(rawData, 0, rawData.Length);
            }
            return ms.ToArray();
        }
    }
}