using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;
using SLTest.Models.Interface;

namespace SLTest.Models
{
    public class VMMenuItem:INavigator
    {
        public bool cb { get; set; }
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string Sort { get; set; }
        public Decimal Price { get; set; }
        public Int64 OptID { get; set; }
        public static IEnumerable<Options> spr;

        private coffeeEntities db = new coffeeEntities();

      

        public IEnumerable<Options> GetSprOpt()
        {
            Options[] empty_Opt = { new Options { OptID = 0, OptionName = "(значение отсутствует)" } };
            var sprOpt = (from s in spr
                         orderby s.OptionName
                         where s.Recipe.RecID == ID
                          select s).Union(empty_Opt);
            if (sprOpt.Count() == 0)
            {
                 sprOpt = sprOpt.Union<Options>(empty_Opt);
            }            
             return sprOpt;
        }
        //public SelectList GetSprList(IEnumerable<Options> i)
        //{
        //    var sprList=new SelectList(i, "OptID", "OptionName");
        //    return sprList;
        //}
   
    }
    public class VMMenu<K>
        where K:class,new()
    {
        public IEnumerable<K> items;

        public PagingInfo paginginfo;

         public  VMMenu()
        {
             
            paginginfo = new PagingInfo();
            
        }
       
    }
}