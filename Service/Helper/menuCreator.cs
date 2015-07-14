using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using System.Web.Mvc;
using System.Text;
using SLTest.Models;

namespace SLTest.Service.Helper
{
    public static class menuCreator
    {
        

        public static MvcHtmlString menuCreate(this System.Web.Mvc.HtmlHelper HH, string obj) 
        {
            coffeeEntities db = new coffeeEntities();
            string result = obj+".";
            var set = from i in db.itCart select i;
            String start = ".append('<li><a href=\"#\">";
            String end =    "</a></li>')";
             result=start+"item"+end;
            return MvcHtmlString.Create(result.ToString());
            
        }
    }
}