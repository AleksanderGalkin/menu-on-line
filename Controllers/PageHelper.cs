using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;

namespace SLTest.Controllers
{
    public static class PageHelper
    {
        public static MvcHtmlString Pager(this HtmlHelper helper,int pageNum,int itemsPerPage,int recordCount)
        {
            StringBuilder strb = new StringBuilder();
            if (pageNum > 0)
            {
                strb.Append(helper.ActionLink("<", "Index", new { pageNum = pageNum - 1 }));
            }
            else
            {
                strb.Append(HttpUtility.HtmlEncode("<"));
            }
            int maxNumPage=(int)Math.Ceiling((double)(recordCount/itemsPerPage));
            if (pageNum < maxNumPage)
            {
                strb.Append(helper.ActionLink(">", "Index", new { pageNum = pageNum + 1 }));
            }
            else
            {
             strb.Append(HttpUtility.HtmlEncode(">"));
            }
            return MvcHtmlString.Create(strb.ToString());
        }
    }
}