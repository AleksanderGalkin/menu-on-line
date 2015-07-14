using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using SLTest.Service.Factory;
using SLTest.Service.Interface;
using SLTest.Controllers.Abstract;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class OptionsController : BaseController1DL<Options, IBaseService<Options>, Recipe, IBaseService<Recipe>>
    {
        public OptionsController(IBaseService<Options> _service, IBaseService<Recipe> _serviceDL) : base(_service, _serviceDL) { }
      //  public OptionsController() : this(OptionsServiceFactory.Create(), RecipeServiceFactory.Create()) { }

        
    }
}
