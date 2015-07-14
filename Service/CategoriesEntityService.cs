using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class CategoriesEntityService : IBaseService<Categories>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Categories> Get()
        {
            IEnumerable<Categories> obj = from a in db.Categories
                                          orderby a.Arrange ascending
                                          select a;
            return obj;
        }
        public Categories Get(int id)
        {
            Categories obj = (from a in db.Categories where a.ID == id select a).SingleOrDefault();
            return obj;
        }
        public Categories Get(string id)
        { return null; }
        public IEnumerable<Categories> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Categories> obj = (from a in db.Categories orderby a.Arrange select a).Skip((page - 1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Categories obj)
        {
            db.AddToCategories(obj);
            db.SaveChanges();
        }
        public void Edit(Categories obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Categories obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Categories select a).Count();
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
                return "Category";
            }
        }
    }
}