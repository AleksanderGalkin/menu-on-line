using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class SortsEntityService:IBaseService<Sorts>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Sorts> Get()
        {
            IEnumerable<Sorts> obj = from a in db.Sorts select a;
            return obj;
        }
        public Sorts Get(int id)
        {
            Sorts obj = (from a in db.Sorts where a.ID == id select a).SingleOrDefault();
            return obj;
        }
        public Sorts Get(string id)
        { return null; }
        public IEnumerable<Sorts> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Sorts> obj = (from a in db.Sorts orderby a.Sort select a).Skip((page - 1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Sorts obj)
        {
            db.AddToSorts(obj);
            db.SaveChanges();
        }
        public void Edit(Sorts obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Sorts obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Sorts select a).Count();
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
                return "Sort";
            }
        }
    }
}