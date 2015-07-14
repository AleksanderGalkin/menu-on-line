using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SLTest.Models;
using SLTest.Controllers.Abstract;
using SLTest.Service.Interface;
using SLTest.Service.Factory;

namespace SLTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : BaseController<UserAndRoles, IBaseService<UserAndRoles>>
    {
        
        public UsersController(IBaseService<UserAndRoles> service) : base(service) { }
       // public UsersController() : this(UserAndRolesServiceFactory.Create()) { }

        public virtual ActionResult EditUsers(string id)
        {
            UserAndRoles obj = Service.Get(id);
            MembershipUserCollection allUsers=Membership.GetAllUsers();
            
            List<string> restUsers=new List<string>();
            foreach (MembershipUser i in allUsers)
            {
                if (!obj.users.Contains(i.UserName))
                {
                    restUsers.Add(i.ToString());
                }
            }
            ViewBag.Users = restUsers;
            if (Request.IsAjaxRequest())
            {
                return View("pvEdit", obj);
            }
            return View("pvEdit", obj);
        }

        [HttpPost]
        public virtual ActionResult EditUsers(string id, FormCollection FC)
        {
            UserAndRoles obj = Service.Get(id);
            UpdateModel(obj, FC);
            Service.Edit(obj);

            if (Request.IsAjaxRequest())
                return RedirectToAction("PVIndex");
            else
                return RedirectToAction("Administration", "Home", new { metName = "PVIndex", modName = "Users" });


        }


    }
}
