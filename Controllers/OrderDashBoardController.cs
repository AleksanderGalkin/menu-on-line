using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators,Waiters")]
    public class OrderDashBoardController : Controller
    {
        coffeeEntities db = new coffeeEntities();
        public enum mode { Active, Archive, All };
        public ActionResult DachBoardView(mode m)
        {
            ViewBag.mode = m;
            return View();
        }
        public ActionResult pvIndex(mode m )
        {
            ViewBag.mode = m;
            string pattern;
            if(User.IsInRole("Administrators"))
                 pattern="";
            else
                 pattern=User.Identity.Name;
            var obj = (from i in db.shipTo
                      orderby i.OrderDateTime descending
                      where  i.Tables.Waiters.login.Contains(pattern)
                      select i).AsEnumerable();
            if (m == mode.Active)
            {
                obj = obj.Where(o => !o.getOState.Descr.Contains("Доставлено") || !o.getPState.Descr.Contains("Оплачено"));
            }

            if (m == mode.Archive)
            {
                obj = obj.Where(o => o.getOState.Descr.Contains("Доставлено") && o.getPState.Descr.Contains("Оплачено"));
            }

            return View(obj);
        }
        public ActionResult changeStage(int? id=null,string nextStageID="",int typeOfStage=0)
        {

            var obj = (from i in db.shipTo
                      where i.ID==id
                      select i).FirstOrDefault();
            int orderStageID = (from i in db.OrderStages
                               where i.Style.Contains(nextStageID)
                               select i.ID).FirstOrDefault();
            if (typeOfStage == 1)
                obj.setOState(nextStageID, User.Identity.Name);
            if (typeOfStage == 2)
                obj.setPState(nextStageID, User.Identity.Name);
            return RedirectToAction("pvIndex");
        }

        public ActionResult Detail(int id, mode m)
        {
            ViewBag.mode = m;
            var v_order = (from i in db.shipTo
                           where i.ID == id
                           select i).FirstOrDefault();

            return View(v_order);
        }
    }
}
