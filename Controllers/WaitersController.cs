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
    public class WaitersController : BaseController<Waiters, IBaseService<Waiters>>
    {
       // public WaitersController(IBaseService<Waiters> _service) : base(_service) { }
       // public WaitersController() : this(WaitersServiceFactory.Create()) { }

        public WaitersController(IBaseService<Waiters> _service) : base(_service) { }
       // public WaitersController() : this() { }
    }
}
