using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Controllers.Abstract;
using SLTest.Service.Interface;
using SLTest.Models;
using SLTest.Service.Factory;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class TablesController : BaseController1DL<Tables, IBaseService<Tables>, Waiters, IBaseService<Waiters>>
    {
        public TablesController(IBaseService<Tables> _service, IBaseService<Waiters> _serviceDL) : base(_service, _serviceDL) { }
      //  public TablesController() : this(TablesServiceFactory.Create(), WaitersServiceFactory.Create()) { }

    }
}
