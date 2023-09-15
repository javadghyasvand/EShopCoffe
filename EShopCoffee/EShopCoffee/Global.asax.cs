using GSD.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EShopCoffee.Models.DataLayer;

namespace EShopCoffee
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Application["Online"] = 0;
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var persianCulture = new PersianCulture();
            Thread.CurrentThread.CurrentCulture = persianCulture;
            Thread.CurrentThread.CurrentUICulture = persianCulture;
        }

        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                System.Web.SessionState.SessionStateBehavior.Required);
        }

        protected void Session_Start()
        {
            int online = int.Parse(HttpContext.Current.Application["Online"].ToString());
            online += 1;
            HttpContext.Current.Application["Online"] = online;
            string ip = Request.UserHostAddress;
            //using (EShopCoffe_DBEntities _dbEntities = new EShopCoffe_DBEntities())
            //{
            //    DateTime dt = DateTime.Now.Date;
            //    if (!_dbEntities.SiteVisit.Any(v => v.IP == ip & v.DateTime == dt))
            //    {
            //        _dbEntities.SiteVisit.Add(new SiteVisit()
            //        {
            //            DateTime = DateTime.Now,
            //            IP = ip
            //        });
            //    }

            //    _dbEntities.SaveChanges();
            //}
        }

        protected void Session_End()
        {
            int online = int.Parse(HttpContext.Current.Application["Online"].ToString());
            online -= 1;
            HttpContext.Current.Application["Online"] = online;
        }
    }
}
