 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using System.Reflection;

namespace SLTest.Controllers
{
    

    [HandleError]
    public class HomeController : Controller
    {

        private coffeeEntities db = new coffeeEntities();
        private int itemsPerPage = 10;
        VMMenu<VMMenuItem> vmmenu=new VMMenu<VMMenuItem>();
       
        public ActionResult Index(int pageNum=1)
        {

            vmmenu.paginginfo.CurrentPage = pageNum;
            vmmenu.paginginfo.ItemsPerPage = itemsPerPage;
            vmmenu.paginginfo.ItemsToView = 4;
            
            ViewData["Message"] = "Добро пожаловать в нашу кофейню";
            
            OptionsDropDownList();
            Navigator nav;
            nav = Session["SFModel"] as Navigator;
            if (nav == null)
            {
                vmmenu.paginginfo.TotalItems = db.Recipe.Count();
                vmmenu.items = (from recipe in db.Recipe
                                orderby recipe.RecName
                                select new VMMenuItem
                                {
                                    cb = false,
                                    ID = recipe.RecID,
                                    Name = recipe.RecName,
                                    Price = recipe.Price,
                                    OptID = 0
                                }).
                    Skip(itemsPerPage * (pageNum - 1)).Take(itemsPerPage);

            }
            else
            {

                var t = nav.GetFiltered();

                vmmenu.paginginfo.TotalItems = nav.GetFiltered().Count();
                vmmenu.items = (from r in nav.GetFiltered()
                                orderby (r.GetType().GetProperty(nav.list.ElementAt(0).stField).GetValue(r, null) ?? "Пусто").ToString()
                                 select new VMMenuItem
                                 {
                                     cb = false,
                                     ID = (long)r.GetType().GetProperty("ID").GetValue(r,null),
                                     Name = (string)r.GetType().GetProperty("Name").GetValue(r, null),
                                     Price =    (decimal)r.GetType().GetProperty("Price").GetValue(r, null),
                                     OptID = 0
                                 }).
                                    Skip(itemsPerPage * (pageNum - 1)).Take(itemsPerPage);

            }

            VMMenuItem.spr = from sprOpt in db.Options
                              select sprOpt;
            

            
            
            return View(vmmenu);

          
        }




        [HttpPost]
        public ActionResult Index(FormCollection menu)
        {
            
                try
                {
                    if (ModelState.IsValid)
                    {
                        Dictionary<itCart, int> sKorzina = Session["sKorzina"] as Dictionary<itCart, int>;
                        if (sKorzina == null) sKorzina = new Dictionary<itCart, int>(new itCart.itCartComparer());
                        Session["sKorzina"] = sKorzina;
                        menu.Remove("empty");
                        int cntFC = menu.Count;
                        string[] arOptID=new string[cntFC-1];
                        for (int i = 0; i < cntFC - 1; i++)
                            arOptID[i] = menu["item.OptID"].Split(new char[] { ',' })[i];
                        menu.Remove("item.OptID");

                        for (int i = 0; i < menu.Count; i++)
                        {   
                            var v = menu[i].Split(new char[] { ',' })[0];
                           
                            if (v == "true")
                            {
                                itCart s=new itCart();
                                var o = Convert.ToInt32(arOptID[i]);
                                var d = Convert.ToInt32(menu.AllKeys[i]);
                                s.drink=d;
                                if (o==0)
                                    s.opt=null;
                                else
                                    s.opt=o;
	
                                if (sKorzina.ContainsKey(s))  sKorzina[s] = sKorzina[s] + 1;
                                    else sKorzina[s] = 1;
                            }

                        }
                        Session["sKorzina"] = sKorzina;
                        return RedirectToAction("Index");
                    }



                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex);
                }

            OptionsDropDownList();
            return View(menu);
        }


        //public ActionResult PVIndex(int pageNum = 1)
        //{

        //    vmmenu.paginginfo.CurrentPage = pageNum;
        //    vmmenu.paginginfo.ItemsPerPage = itemsPerPage;
        //    vmmenu.paginginfo.ItemsToView = 4;
        //    vmmenu.paginginfo.TotalItems = db.Recipe.Count();
        //    ViewData["Message"] = "Добро пожаловать в нашу кофейню";

        //    OptionsDropDownList();

        //    if (TempData["FModel"] == null)
        //    {
        //        vmmenu.paginginfo.TotalItems = db.Recipe.Count();
        //        vmmenu.items = (from recipe in db.Recipe
        //                        orderby recipe.RecName
        //                        select new VMMenuItem
        //                        {
        //                            cb = false,
        //                            RecID = recipe.RecID,
        //                            RecName = recipe.RecName,
        //                            Price = recipe.Price,
        //                            OptID = 0
        //                        }).
        //            Skip(itemsPerPage * (pageNum - 1)).Take(itemsPerPage);

        //    }
        //    else
        //    {
        //        vmmenu.items = TempData["FModel"] as IEnumerable<VMMenuItem>;
        //        vmmenu.paginginfo.TotalItems = vmmenu.items.Count();
        //    }


        //    VMMenuItem.spr = from sprOpt in db.Options
        //                     select sprOpt;




        //    return View("PVIndex",vmmenu);


        //}




        [Authorize(Roles = "Administrators,Waiters")]
        public ActionResult Administration(string modName = "Home", string metName = "AdministrationStart", int pageNum = 1, int id = 0)
        {
            ViewBag.mn = modName;
            ViewBag.mtn = metName;
            ViewBag.pn = pageNum;
            ViewBag.id = id;

            return View();
        }
        public ActionResult AdministrationStart(int pageNum = 1)
        {
            return View();
        }
        [Authorize]
        public ActionResult Korzina()
        {
            List<KeyValuePair<SLTest.Models.itCart, int>> a;
            if ((Session["sKorzina"] as Dictionary<itCart, int>) == null)
                return View();
            else
            {
                a = (Session["sKorzina"] as Dictionary<itCart, int>).ToList();
                return View(a);
            }

        }
    

        public ActionResult About()
        {
            return View();
        }



        private void OptionsDropDownList(object selectedoptions = null)
        {
            var recipeQuery = from d in db.Options
                              orderby d.OptionName
                              select d;
            ViewData["RecList"] = new SelectList(recipeQuery, "OptID", "OptionName", selectedoptions);
        }


    }

  
}
