using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Models;
using SLTest.Service.Interface;
using SLTest.Service;
using SLTest.Service.Factory;
using SLTest.Controllers.Abstract;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RecipeController : BaseController2DL<Recipe, IBaseService<Recipe>, Sorts, IBaseService<Sorts>, Categories, IBaseService<Categories>>
    {
        IBaseService<Sorts> L = SortsServiceFactory.Create();
        public RecipeController(IBaseService<Recipe> service, IBaseService<Sorts> List1, IBaseService<Categories> List2) : base(service, List1,List2) { }
      //  public RecipeController() : this(RecipeServiceFactory.Create(), SortsServiceFactory.Create(), CategoriesServiceFactory.Create()) { }
 
    }
}
