using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using System.Reflection;
using System.Data.Objects.DataClasses;
using System.Web.UI;
using SLTest.Service;

namespace SLTest.Controllers
{
    
    public class ShippingController : Controller
    {
        //
        // GET: /Shipping/
        coffeeEntities db = new coffeeEntities();
        private OrderDashBoardsStagesEntityService ordDbServ = new OrderDashBoardsStagesEntityService();
        public ActionResult pvIndex()
        {
            
            
            shipTo st = new shipTo();
            var t=(from i in db.formOfP select i).ToList() ;
            var tables = (from i in db.Tables select i).ToList();
            ViewBag.stList = t;
            ViewBag.Tables = tables;

            return View(st);
        }

        public ActionResult pvCashOrCart(int ShipToID)
        {
            var res = (from i in db.shipTo
                       where i.ID == ShipToID
                       select i).FirstOrDefault();

            return View(res);
        }


        public ActionResult pvKorzina()
        {
            List<KeyValuePair<SLTest.Models.itCart, int>> a;
            a = (Session["sKorzina"] as Dictionary<itCart, int>).ToList();
            return View(a);
        }
        [HttpPost]
        [MultiButton(MatchFormKey = "sendCart", MatchFormValue = "Пересчитать")]
        public ActionResult CartSubmit(int? a)
        {
            Dictionary<itCart, int> par = new Dictionary<itCart, int>();
            TryUpdateModel(par);
            if (ModelState.IsValid)
            {
                Session["sKorzina"] = par;
                if (Request.IsAjaxRequest())
                {

                    return RedirectToAction("pvKorzina");
                }
                else
                    return RedirectToAction("Korzina", "Home");
            }
            else
            {
                return View("pvKorzina",par);
            }
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "sendCart", MatchFormValue = "Оформить заказ")]
        public ActionResult CartSubmit(int? a, int? b)
        {
            Dictionary<itCart, int> par = new Dictionary<itCart, int>();
            TryUpdateModel(par);
            if (ModelState.IsValid)
            {
                Session["sKorzina"] = par;
                return RedirectToAction("pvIndex", "Shipping");
            }
            else
            {
                return View("pvKorzina", par);
            }
        }

        [HttpPost]
        [Authorize]
        [MultiButton(MatchFormKey = "sendCart", MatchFormValue = "Оправить")]


        public ActionResult CartSubmit([Bind(Exclude = "flPaid,dtPaid,WaiterID")]int? a, int? b, int? с, FormCollection fc)
        {
            //shipTo par = new shipTo(Session["sKorzina"] as Dictionary<itCart, int>);
            shipTo par = new shipTo();
            TryUpdateModel(par);
            
            if (ModelState.IsValid)
            {
                
                db.AddToshipTo(par);
                

                Dictionary<itCart, int> itCarts = Session["sKorzina"] as Dictionary<itCart, int>;
                if (itCarts != null)
                {
                    foreach (var i in itCarts)
                    {
                        if (i.Value > 0)
                        {
                            i.Key.num = (short)i.Value;
                            i.Key.shipToID = par.ID;
                            db.AddToitCart(i.Key);

                        }

                    }
                    db.SaveChanges();
                    ordDbServ.SetOrderState((int)par.ID, "Создан заказ", User.Identity.Name);
                    if (par.flImmediateBill)
                        ordDbServ.SetPayState((int)par.ID, "Счёт запрошен", User.Identity.Name);
                    else
                        ordDbServ.SetPayState((int)par.ID, "Счёт не запрошен", User.Identity.Name);
                    Session.Abandon();
                    return RedirectToAction("pvCashOrCart", "Shipping", new { ShipToID = par.ID });
                }
                else
                    return RedirectToAction("pvCashOrCart", "Shipping", new { ShipToID = par.ID });
            }
            else
            {
                var t = (from i in db.formOfP select i).ToList();
                ViewBag.stList = t;
                return View("pvIndex",par);
            }
        }



    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultiButtonAttribute : ActionNameSelectorAttribute
    {
        public string MatchFormKey { get; set; }
        public string MatchFormValue { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            bool x = controllerContext.HttpContext.Request[MatchFormKey] != null &&
                controllerContext.HttpContext.Request[MatchFormKey] == MatchFormValue;

            return x;
        }
    }
}
