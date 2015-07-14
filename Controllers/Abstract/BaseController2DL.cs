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
    public abstract class BaseController2DL<T, S, dlT, dlS, dlT2, dlS2> : BaseController1DL<T, S,dlT, dlS>
        where T : class,IBase, new()
        where S : class,IBaseService<T>
        where dlT : class,IBase, new()
        where dlS : class,IBaseService<dlT>
        where dlT2 : class,IBase, new()
        where dlS2 : class,IBaseService<dlT2>
    {
        protected S Serv2dl;
        protected dlS dl1Serv2dl;
        protected dlS2 dl2Serv2dl;
        // private int itemsPerPage = 3;
        VMMenu<VMMenuItem> vmmenu = new VMMenu<VMMenuItem>();

        //public BaseController2DL(S Service, dlS ServiceDL)
        //    : base(Service, ServiceDL)
        //{
        //    Serv2dl = Service;
        //    dl1Serv2dl = ServiceDL;
        //}

        public BaseController2DL(S Service, dlS ServiceDL, dlS2 ServiceDL2)
            : base(Service, ServiceDL)
        {
            Serv2dl = Service;
            dl1Serv2dl = ServiceDL;
            dl2Serv2dl = ServiceDL2;
        }

        #region Actions


        public override ActionResult Create()
        {
            DropDownList1();
            DropDownList2();
            return View("pvCreate");
        }

        public override ActionResult Edit(int id,int pageNum)
        {
            T obj = Serv.Get(id);
            ViewBag.pageNum = pageNum;
            DropDownList1();
            DropDownList2();
            if (Request.IsAjaxRequest())
            {
                return View("pvEdit", obj);
            }
            return View("pvEdit", obj);
        }


        #endregion
        private void DropDownList1 (object selected1 = null)
        {
            var sel1 = dl1Serv2dl.Get();
            ViewData["List1"] = new SelectList(sel1, dl1Serv2dl.IdField, dl1Serv2dl.NameField, selected1);
        }
        private void DropDownList2(object selected2 = null)
        {
            var sel2 = dl2Serv2dl.Get();
            ViewData["List2"] = new SelectList(sel2, dl2Serv2dl.IdField, dl2Serv2dl.NameField, selected2);
        }
    }
}