using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using SLTest.Models;
using SLTest.Service.Interface;

namespace SLTest.Service.Ninject
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory(){
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                                ? null
                                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings(){

            ninjectKernel.Bind<IBaseService<Waiters>>().To<WaitersEntityService>();
            ninjectKernel.Bind<IBaseService<UserAndRoles>>().To<UserAndRolesService>();
            ninjectKernel.Bind<IBaseService<Categories>>().To<CategoriesEntityService>();
            ninjectKernel.Bind<IBaseService<Options>>().To<OptionsEntityService>();
            ninjectKernel.Bind<IBaseService<Recipe>>().To<RecipeEntityService>();
            ninjectKernel.Bind<IBaseService<Sorts>>().To<SortsEntityService>();
            ninjectKernel.Bind<IBaseService<Tables>>().To<TablesEntityService>();
        }

    }
}