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
    public class SortsController : BaseController<Sorts,IBaseService<Sorts>>
    {
        public SortsController(IBaseService<Sorts> _service) : base(_service) { }
      //  public SortsController() : this(SortsServiceFactory.Create()) { }
    }
}
