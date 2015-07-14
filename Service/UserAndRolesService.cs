using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;
using System.Web.Security;

namespace SLTest.Service
{
    public class UserAndRolesService : IBaseService<UserAndRoles>
    {
       
        public IEnumerable<UserAndRoles> Get()
        {

            var obj = from i in Roles.GetAllRoles()
                                            select new UserAndRoles { 
                                                ID=i,
                                                roleName=i,
                                                users=Roles.GetUsersInRole(i)
                                            };
            return obj;
        }
        public UserAndRoles Get(int id)
        { return null; }

        public UserAndRoles Get(string id)
        {
            UserAndRoles obj = (from i in Roles.GetAllRoles()
                                where i==id
                                select new UserAndRoles
                                {
                                    ID = i,
                                    roleName = i,
                                    users = Roles.GetUsersInRole(i)
                                }).SingleOrDefault();
            return obj;
        }
        public IEnumerable<UserAndRoles> GetToPage(int page, int itemsToPage)
        {
            var obj = (from i in Roles.GetAllRoles()
                                            select new UserAndRoles { 
                                                ID=i,
                                                roleName=i,
                                                users=Roles.GetUsersInRole(i)
                                            }).Skip((page - 1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(UserAndRoles obj)
        {
            //db.AddToSorts(obj);
            //db.SaveChanges();
        }
        public void Edit(UserAndRoles obj)
        {
            foreach(var i in obj.users)
            {
                if (!Roles.GetUsersInRole(obj.roleName).Contains(i))
                {
                    Roles.AddUserToRole(i, obj.roleName);
                }

            }

            foreach (var i in Roles.GetUsersInRole(obj.roleName))
            {
                if (!obj.users.Contains(i))
                {
                    Roles.RemoveUserFromRole(i, obj.roleName);
                }

            }

        }
        public void Delete(UserAndRoles obj)
        {
            //db.DeleteObject(obj);
            //db.SaveChanges();
        }
        public int Count()
        {
            int cnt = ( from i in Roles.GetAllRoles()
                                            select i).Count();
            return cnt;
        }
        public String IdField
        {
            get
            {
                return "ID";
            }
        }
        public String NameField
        {
            get
            {
                return "roleName";
            }
        }
    }
}