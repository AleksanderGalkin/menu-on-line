using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class RecipeEntityService:IBaseService<Recipe>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Recipe> Get()
        {
            IEnumerable<Recipe> obj = from a in db.Recipe select a;
            return obj;
        }
        public Recipe Get(int id)
        {
            Recipe obj = (from a in db.Recipe where a.RecID == id select a).SingleOrDefault();
            return obj;
        }
        public Recipe Get(string id)
        { return null; }
        public IEnumerable<Recipe> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Recipe> obj = (from a in db.Recipe orderby a.RecName select a).Skip((page-1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Recipe obj)
        {
            db.AddToRecipe(obj);
            db.SaveChanges();
        }
        public void Edit(Recipe obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Recipe obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Recipe select a).Count();
            return cnt;
        }
        public String IdField
        {
            get
            {
                return "RecID";
            }
        }
        public String NameField
        {
            get
            {
                return "RecName";
            }
        }
    }
}