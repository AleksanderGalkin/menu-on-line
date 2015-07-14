using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using SLTest.Service;
using System.Data.Common;


namespace SLTest.Controllers
{
    public class OrderController : Controller
    {
        private coffeeEntities db = new coffeeEntities();
        private OrderDashBoardsStagesEntityService ordDbServ = new OrderDashBoardsStagesEntityService();
        DbTransaction transaction;



        [Authorize]
        public ActionResult Index()
        {
            var v_order = (from i in db.shipTo
                           where i.userName == User.Identity.Name
                           orderby i.OrderDateTime descending
                           select i).ToList();
            return View(v_order);
        }
        public ActionResult Detail(int id)
        {
            var v_order = (from i in db.shipTo
                           where i.ID == id
                           select i).FirstOrDefault();
            
            return View(v_order);
        }

        public ActionResult Payment(int id)
        {
            var t = (from i in db.formOfP select i).ToList();
            ViewBag.stList = t;

            var v_order = (from i in db.shipTo
                           where i.ID == id
                           select i).FirstOrDefault();
            return View(v_order);
        }
        [HttpPost]
        public ActionResult Payment([Bind(Exclude = "tableNum")]int shipId, FormCollection fc)
        {
            shipTo2 obj = new shipTo2();
            TryUpdateModel(obj, fc);

            if (ModelState.IsValid)
            {


                var res = (from i in db.shipTo
                           where i.ID == shipId
                           select i).FirstOrDefault();
                res.formOfP = obj.formOfP;
                if (res.formOfP1.Descr.Trim() == "Банковская карта")
                {
                    //res.dtPaid = DateTime.Now;
                    res.setPState("banked", User.Identity.Name);
                    //res.flPaid = true;
                }
                TryUpdateModel(res);

                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                    if(res.formOfP1.Descr.Trim()=="Банковская карта")
                        ordDbServ.SetPayState(shipId, "Оплачено картой", User.Identity.Name);
                    else
                        ordDbServ.SetPayState(shipId, "Счёт запрошен", User.Identity.Name);

                    ViewBag.formOfP1 = res.formOfP1.Descr.Trim();
                    return View("Success");
                }
                else
                {
                    var t = (from i in db.formOfP select i).ToList();
                    ViewBag.stList = t;
                    return View(obj);
                }
                
            }
            else
            {
                var t = (from i in db.formOfP select i).ToList();
                ViewBag.stList = t;
                return View(obj);
            }

            
        }

        public ActionResult DeleteOrder(int id)
        {
            try
            {
                db.Connection.Open();
                transaction = db.Connection.BeginTransaction();
                

                var resShipTo = (from i in db.shipTo
                                 where i.ID == id
                                 select i).FirstOrDefault();
                var resItCart = from i in db.itCart
                                where i.shipToID == id
                                select i;
                var resDB = from i in db.OrderDashBoards
                            where i.shipToID == id
                            select i;
                if (resShipTo.getOState.Descr.Contains("Создан заказ"))
                {

                    if (resDB != null)
                    {
                        foreach (var i in resDB)
                        {
                            db.DeleteObject(i);
                        }
                        
                    }
                    if (resItCart != null)
                    {
                        foreach (var i in resItCart)
                        {
                            db.DeleteObject(i);
                        }
                       
                    }
                    if (resShipTo != null)
                    {
                        db.DeleteObject(resShipTo);
                        
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction("Index", new { parUser = User.Identity.Name });
        }
    }//---------public class OrderController : Controller

}
