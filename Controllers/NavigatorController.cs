using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using SLTest.Models.Interface;

namespace SLTest.Controllers
{
    public class NavigatorController : Controller
    {
        private coffeeEntities db = new coffeeEntities();
        public Navigator nav;
        public Navigator navSes;

        public NavigatorController()
        {
            nav = new Navigator();

            nav.schStr = "";

            var t = from recipe in db.Recipe
                    join c in db.Categories
                    on recipe.Category equals c.ID
                    join s in db.Sorts
                    on recipe.Sort equals s.ID
                    select new
                    {
                        cb = false,
                        ID = recipe.RecID,
                        Name = recipe.RecName,
                        Sort = s.Sort,
                        Cat = c.Category,
                        Arrange=c.Arrange,
                        Price = recipe.Price,
                        OptID = 0
                    } into lst
                    group lst by lst.Cat
                        into g
                        select new
                       {
                           cc = g.Key,
                           ar=g.Min(p=>p.Arrange),
                           vv = g.Select(p => new VMMenuItem {
                                                      cb = false,
                                                      ID = p.ID,
                                                      Name = p.Name,
                                                      Sort = p.Sort,
                                                      Price = p.Price,
                                                      OptID = p.OptID
                                                  }
                                    )
                       };

            foreach (var i in t)
            {

                nav.Add(i.vv, "Sort", i.cc,(int)i.ar);
            }

        }

        
        public ActionResult PVIndex(int pageNum=1)
        {
            OptionsDropDownList();

            navSes = Session["SFModel"] as Navigator;
            if (navSes != null)
            nav = navSes;


                 return View(nav);
        }
        [HttpPost]
        public ActionResult PVIndexPost(FormCollection fc)
        {


            
            foreach (var i in nav.list)
            {
                foreach (var j in i.GetContent())
                {
                        if (fc[j.nmItem].ToString().Contains("true"))
                        {
                            j.cbItem = true;

                        }
                }
            }

            Session["SFModel"] = nav;

            return RedirectToAction("Index", "Home", new { pageNum=1 });
        }

        private void OptionsDropDownList(object selectedoptions = null)
        {
            var recipeQuery = from d in db.Options
                              orderby d.OptionName
                              select d;
            ViewData["RecList"] = new SelectList(recipeQuery, "OptID", "OptionName", selectedoptions);
        }

        private IEnumerable<INavigator> GetModel()
        {

            var t= from recipe in db.Recipe
                   join s in db.Sorts
                   on recipe.Sort equals s.ID
                   join c in db.Categories
                   on recipe.Sort equals c.ID
                   orderby recipe.RecName
                   group recipe by c.Category
                   into g
                   select g;

            
            return  from recipe in db.Recipe
                        join s in db.Sorts
                        on recipe.Sort equals s.ID
                      orderby recipe.RecName
                      select new VMMenuItem
                      {
                          cb = false,
                          ID = recipe.RecID,
                          Name = recipe.RecName,
                          Sort = s.Sort,
                          Price = recipe.Price,
                          OptID = 0
                      };
        }
        [HttpPost]
        public void getFilteredRecords(string schStr)
        {
            navSes = Session["SFModel"] as Navigator;
            if (navSes != null)
                nav = navSes;
            nav.schStr = schStr;
            Session["SFModel"] = nav;
           // return RedirectToAction("Index", "Home", new { pageNum = 1});
        }

    }
}
