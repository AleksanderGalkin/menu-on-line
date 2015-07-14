using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models.Interface;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Controllers.Abstract
{
    public abstract class BaseController1DL<T,S,dlT,dlS>:BaseController<T,S>
        where T:class,IBase,new()
        where S:class,IBaseService<T>
        where dlT:class,IBase,new()
        where dlS:class,IBaseService<dlT>

    {
        protected S Serv;
        protected dlS dlServ;
       // private int itemsPerPage = 3;
        VMMenu<VMMenuItem> vmmenu = new VMMenu<VMMenuItem>();

        public BaseController1DL(S Service):base(Service)
        {
            Serv = Service;
        }

        public BaseController1DL(S Service,dlS ServiceDL):base(Service)
        {
            Serv = Service;
            dlServ=ServiceDL;
           // dlFlag=true;
        }

        #region Actions

        //public override ActionResult Index(int pageNum = 1)
        //{
        //    vmmenu.paginginfo.CurrentPage = pageNum;
        //    vmmenu.paginginfo.ItemsPerPage = itemsPerPage;
        //    vmmenu.paginginfo.ItemsToView = 3;
        //    vmmenu.paginginfo.TotalItems = Serv.Count();
        //    //ViewData["PageNum"] = pageNum;
        //    //ViewData["itemsPerPage"] = itemsPerPage;
        //    //ViewData["recordCount"] = Serv.Count();
        //    vmmenu.items = Serv.GetToPage(pageNum, itemsPerPage);
        //    return View(vmmenu);
        //}
        public override ActionResult Create()
        {
            RecipeDropDownList();
            return View("pvCreate");
        }
        //[HttpPost]
        //public virtual ActionResult Create(FormCollection FC)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        T obj = new T();
        //        UpdateModel(obj, FC);
        //        Serv.Create(obj);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //        return View(FC);
        //}
        public override ActionResult Edit(int id, int pageNum)
        {
            T obj = Serv.Get(id);
            ViewBag.pageNum = pageNum;
            RecipeDropDownList();
            if (Request.IsAjaxRequest())
            {
                return View("pvEdit", obj);
            }
            return View("pvEdit",obj);
        }
        //[HttpPost]
        //public virtual ActionResult Edit(int id,FormCollection FC)
        //{
        //    T obj = Serv.Get(id);
        //    UpdateModel(obj, FC);
        //    Serv.Edit(obj);
        //    return RedirectToAction("Index");
        //}
        //public virtual ActionResult Delete(int id,FormCollection FC)
        //{
        //    var obj = Serv.Get(id);
        //    Serv.Delete(obj);
        //    return RedirectToAction("Index");
        //}


        #endregion
        private void RecipeDropDownList(object selectedRecipe = null)
        {
            //var recipeQuery = from d in db.Recipe
            //                       orderby d.RecName
            //                       select d;
            var recipeQuery = dlServ.Get();
            ViewData["RecList"] = new SelectList(recipeQuery, dlServ.IdField, dlServ.NameField, selectedRecipe);
        }
    }
}