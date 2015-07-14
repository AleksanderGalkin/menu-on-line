using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class OptionsEntityService:IBaseService<Options>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<Options> Get()
        {
            IEnumerable<Options> obj = from a in db.Options select a;
            return obj;
        }
        public Options Get(int id)
        {
            Options obj = (from a in db.Options where a.OptID == id select a).SingleOrDefault();
            return obj;
        }
        public Options Get(string id)
        { return null; }
        public IEnumerable<Options> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<Options> obj = (from a in db.Options orderby a.OptionName select a).Skip((page-1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(Options obj)
        {
            db.AddToOptions(obj);
            db.SaveChanges();
        }
        public void Edit(Options obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(Options obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.Options select a).Count();
            return cnt;
        }

        public   String IdField {
            get
            {
                return "OptID";
            }
        }
        public  String NameField
        {
            get
            {
                return "OptionName";
            }
        }
    }
}