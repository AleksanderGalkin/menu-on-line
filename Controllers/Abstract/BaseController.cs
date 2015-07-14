using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models.Interface;
using SLTest.Service.Interface;
using SLTest.Models;
using System.Web.Security;

namespace SLTest.Controllers.Abstract
{
    public abstract class BaseController<T,S>:Controller
        where T:class,IBase,new()
        where S:class,IBaseService<T>

    {
        protected S Service;
        private int itemsPerPage = 10;
        VMMenu<T> vmmenu = new VMMenu<T>();

        public BaseController(S _Service)
        {
            Service = _Service;
        }

        #region Actions

        public virtual ActionResult Index(int pageNum = 1)
        {
            vmmenu.paginginfo.CurrentPage = pageNum;
            vmmenu.paginginfo.ItemsPerPage = itemsPerPage;
            vmmenu.paginginfo.ItemsToView = 3;
            vmmenu.paginginfo.TotalItems = Service.Count();
            vmmenu.items = Service.GetToPage(pageNum, itemsPerPage);
            return View(vmmenu);
        }
        public virtual ActionResult PVIndex(int pageNum = 1)
        {
            if (Request.IsAjaxRequest())
            {
                vmmenu.paginginfo.ItemsToView = 2;
            }

            vmmenu.paginginfo.CurrentPage = pageNum;
            vmmenu.paginginfo.ItemsPerPage = itemsPerPage;
            vmmenu.paginginfo.ItemsToView = 3;
            vmmenu.paginginfo.TotalItems = Service.Count();

            vmmenu.items = Service.GetToPage(pageNum, itemsPerPage);
            return View(vmmenu);
        }
        public virtual ActionResult Create()
        {
          return View("pvCreate");

        }
        [HttpPost]
        public virtual ActionResult Create(FormCollection FC)
        {
            if (ModelState.IsValid)
            {
                T obj = new T();
                UpdateModel(obj, FC);
                Service.Create(obj);
                if (Request.IsAjaxRequest())
                    return RedirectToAction("PVIndex");
                else
                    return RedirectToAction("Administration", "Home", new { metName = "PVIndex", modName = obj.GetType().Name });
            }
            else
                 if (Request.IsAjaxRequest())
                    return View("pvCreate", FC);
                 else
                    return View(FC);
      
        }
        public virtual ActionResult Edit(int id, int pageNum)
        {
            T obj = Service.Get(id);
            ViewBag.pageNum = pageNum;
            if (Request.IsAjaxRequest())
            {
                return View("pvEdit",obj);
            }
            return View("pvEdit",obj);
        }
      
        [HttpPost]
        public virtual ActionResult Edit(int id,int pageNum,FormCollection FC)
        {
            T obj = Service.Get(id);
            UpdateModel(obj, FC);
            Service.Edit(obj);
            if (Request.IsAjaxRequest())
                return RedirectToAction("PVIndex", new { pageNum = pageNum});
            else
                return RedirectToAction("Administration", "Home", new { metName = "PVIndex", modName = obj.GetType().Name, pageNum = pageNum });

            
        }

        public virtual ActionResult Delete(int id)
        {
            var obj = Service.Get(id);
            
            
                return View("pvDelete",obj);
            
        }
         [HttpPost]
        public virtual ActionResult Delete(int id,FormCollection FC)
        {
            var obj = Service.Get(id);
            Service.Delete(obj);
            if (Request.IsAjaxRequest())
                return RedirectToAction("PVIndex");
            else
                return RedirectToAction("Administration", "Home", new { metName = "PVIndex", modName = obj.GetType().Name });
      
        }


        #endregion
       
    }
}