using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service
{
    public class OrderStagesEntityService : IBaseService<OrderStages>
    {
        coffeeEntities db = new coffeeEntities();
        public IEnumerable<OrderStages> Get()
        {
            IEnumerable<OrderStages> obj = from a in db.OrderStages select a;
            return obj;
        }
        public OrderStages Get(int id)
        {
            OrderStages obj = (from a in db.OrderStages where a.ID == id select a).SingleOrDefault();
            return obj;
        }
        public OrderStages Get(string id)
        { return null; }
        public IEnumerable<OrderStages> GetToPage(int page, int itemsToPage)
        {
            IEnumerable<OrderStages> obj = (from a in db.OrderStages orderby a.Descr select a).Skip((page-1) * itemsToPage).Take(itemsToPage);
            return obj;
        }
        public void Create(OrderStages obj)
        {
            db.AddToOrderStages(obj);
            db.SaveChanges();
        }
        public void Edit(OrderStages obj)
        {
            
            db.SaveChanges();
        }
        public void Delete(OrderStages obj)
        {
            db.DeleteObject(obj);
            db.SaveChanges();
        }
        public int Count()
        {
            int cnt = (from a in db.OrderStages select a).Count();
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
                return "Descr";
            }
        }
    }
}