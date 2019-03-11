using Bill.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Bill.Web.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult FilesUpload(int type)
        {
            var filesPath = "";
            if (Request.Files.Count > 0)
            {
                var files = Request.Files;
                if (files.Count > 0)
                {
                    string varName = System.IO.Path.GetFileName(files[0].FileName);
                    //统一路径  文件夹
                    filesPath = Server.MapPath("/Files" + "/" + (type == 1 ? "BillsType" : "Head"));
                    if (!Directory.Exists(filesPath))
                    {
                        Directory.CreateDirectory(filesPath);
                    }
                    string[] suffix = varName.Split('.');
                    filesPath += "\\" + DateTime.Now.ToTimeStamp() + "." + suffix[suffix.Length - 1];
                    FileInfo file = new FileInfo(filesPath);
                    if (!file.Exists)
                    {
                        files[0].SaveAs(filesPath);
                    }
                }
            }
            return Json(new
            {
                code = 0,
                msg = "",
                data = new
                {
                    src = Regex.Split(filesPath, "Bill.Web", RegexOptions.IgnoreCase)[1]
                }
            });
        }
    }
}