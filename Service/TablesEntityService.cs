using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class TablesEntityService : IBaseService<Tables>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Tables> Get()
        {
            IEnumerable<Tables> obj = from a in db.Tables select a;
            return obj;
        }
        public Tables Get(int id)
        {
            Tables obj = (from a in db.Tables where a.ID == id select a).SingleOrDefault();
            return obj;
        }
        public Tables Get(string id)
        { return null; }
        public IEnumerable<Tables> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Tables> obj = (from a in db.Tables orderby a.numTable select a).Skip((page - 1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Tables obj)
        {
            db.AddToTables(obj);
            db.SaveChanges();
        }
        public void Edit(Tables obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Tables obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Tables select a).Count();
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
                return "numTable";
            }
        }
    }
}