using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using SLTest.Service.Interface;
using SLTest.Controllers.Abstract;
using SLTest.Service.Factory;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class CategoriesController : BaseController<Categories,IBaseService<Categories>>
    {
        public CategoriesController(IBaseService<Categories> service) : base(service) { }
       // public CategoriesController() : this(CategoriesServiceFactory.Create()) { }
    }
}
