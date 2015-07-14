using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class WaitersEntityService : IBaseService<Waiters>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Waiters> Get()
        {
            IEnumerable<Waiters> obj = from a in db.Waiters select a;
            return obj;
        }
        public Waiters Get(int id)
        {
            Waiters obj = (from a in db.Waiters where a.ID == id select a).SingleOrDefault();
            return obj;
        }
        public Waiters Get(string id)
        { return null; }
        public IEnumerable<Waiters> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Waiters> obj = (from a in db.Waiters orderby a.name select a).Skip((page - 1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Waiters obj)
        {
            db.AddToWaiters(obj);
            db.SaveChanges();
        }
        public void Edit(Waiters obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Waiters obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Waiters select a).Count();
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
                return "name";
            }
        }
    }
}