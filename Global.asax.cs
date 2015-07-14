using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SLTest.Service;
using SLTest.Service.Ninject;

namespace SLTest
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              "", // Route name
                //"Home/Administration/spr{modName}/{metName}/Page{pageNum}/{id}", // URL with parameters
              "administration", // URL with parameters
              new { controller = "Home", action = "Administration", modName = "Home", metName = "AdministrationStart", pageNum = 1 } // Parameter defaults
          );
            routes.MapRoute(
              "", // Route name
              "administration/spr{modName}/{metName}/Page{pageNum}/{id}", // URL with parameters
              new { controller = "Home", action = "Administration", modName = UrlParameter.Optional,metName=UrlParameter.Optional, pageNum = UrlParameter.Optional, id = UrlParameter.Optional } // Parameter defaults
          );
            routes.MapRoute(
              "", // Route name
              "Monitoring/{m}", // URL with parameters
              new { controller = "OrderDashBoard", action = "DachBoardView",m=UrlParameter.Optional } // Parameter defaults
          );
            routes.MapRoute(
              "", // Route name
              "Order", // URL with parameters
              new { controller = "Order", action = "Index" } // Parameter defaults
          );
            routes.MapRoute(
              "", // Route name
              "Menu/Page{pageNum}", // URL with parameters
              new { controller = "Home", action = "Index", pageNum = 1, id = UrlParameter.Optional } // Parameter defaults
          );
            routes.MapRoute(
              "", // Route name
              "{controller}/{action}/Page{pageNum}", // URL with parameters
              new { controller = "Home", action = "Index", pageNum = UrlParameter.Optional, id = UrlParameter.Optional } // Parameter defaults
          );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
	    
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}