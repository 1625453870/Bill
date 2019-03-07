using Bill.BLL;
using Bill.Common;
using Bill.Model.Entity;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace Bill.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AddDefaultData();
        }

        private void AddDefaultData()
        {
            var commbll = new CommonBLL();

            var sysusersList = FilesHelper.ReadFiles(HttpContext.Current.Server.MapPath(@"/DataXmlJson/user.json")).JsonToT<List<Users>>();
            var sqlusersList = commbll.FindList<Users>(p => p.IsSystem == true).ToList(); ;
            if (sqlusersList.Count() != sysusersList.Count)
            {
                var addList = new List<Users>();
                sysusersList.ForEach(p =>
                {
                    if (sqlusersList.Where(q => q.Name == p.Name).ToList().Count == 0)
                        addList.Add(p);
                });
                new UsersBLL().Insert(addList);
            }

            var adminId = commbll.FindEntity<Users>(p => p.IsSystem == true).Id;
            var sysbillsTypeList = FilesHelper.ReadFiles(HttpContext.Current.Server.MapPath(@"/DataXmlJson/billsType.json")).JsonToT<List<BillsType>>();
            var sqlbillsTypeList = commbll.FindList<BillsType>(p => p.IsSystem == true).ToList(); ;
            if (sqlbillsTypeList.Count() != sysbillsTypeList.Count)
            {
                var addList = new List<BillsType>();
                sysbillsTypeList.ForEach(p =>
                {
                    if (sqlbillsTypeList.Where(q => q.Name == p.Name).ToList().Count == 0)
                        addList.Add(p);
                });
                addList.ForEach(p => {
                    p.UserId = adminId;
                });
                commbll.Insert<BillsType>(addList);
            }

        }


    }
}
