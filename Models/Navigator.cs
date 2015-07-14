using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SLTest.Models.Interface;

namespace SLTest.Models
{




    public class SearchTerm //Критерии фильтрации для одной категории
        
        
    {
        public class stItemStru { public bool cbItem; public string nmItem; }// структура с критерием 
        public List<stItemStru> stList;// список критериев для данной модели
        public IEnumerable<INavigator> model; //модель из которой формируется stItemStru
    
        public string stDescr;
        public string stField;
        public int stArrange;
        

        public SearchTerm(IEnumerable<INavigator> m, string f, string d,int a)
        {

            model = m;
            stField = f;
            stDescr = d;
            stArrange=a;
            stList = new List<stItemStru>();
            var stL = from l in model
                      group l by (l.GetType().GetProperty(stField).GetValue(l, null) ?? "Пусто").ToString();
            foreach (var i in stL)
                stList.Add(new stItemStru { cbItem = false,
                                            nmItem = i.Key.ToString() });
                
            
        }
        public List<stItemStru> GetContent()  //полностью список критериев по модели
        {
            var r = (from a in stList
                    select a).ToList();
            return r;
        }


        public IEnumerable<INavigator> GetFiltered() // модель отфильтрованная по всем критериям
        {
            var cntSel = (from it in stList
                          where it.cbItem
                          select it).Count();

            if (cntSel > 0)
            {
                var r = from a in model
                        join it in stList
                        on (a.GetType().GetProperty(stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                        where it.cbItem
                        select a;
                return r;
            }
            else
            {
                var r = from a in model
                        join it in stList
                        on (a.GetType().GetProperty(stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                        select a;
                return r;
            }
            
        }

    }
    public class Navigator//<T>
    //where T :  INavigator, new()
    {
       // public string test{get;set;}
        //public List<string> tl;
        public List<SearchTerm> list;
        public string schStr;

        public Navigator()
        {
            list = new List<SearchTerm>();
            //tl = new List<string>();
            //tl.Add("раз");
            //tl.Add("два");
            //tl.Add("три");
        }

        public void Add(SearchTerm st)
        {
            list.Add(st);
            
        }
        public void Add(IEnumerable<INavigator> m, string f, string d,int a)
        {
            list.Add(new SearchTerm(m, f, d,a));

        }

        public IEnumerable<INavigator> GetFiltered() // модель отфильтрованная по всем критериям
        {


            
            var cntSel = (from i in list
                          select i.stList.Count(p=>p.cbItem==true)
                          ).Sum();

            if (cntSel > 0)
            {

                var r = from a in list.FirstOrDefault().model
                        join it in list.FirstOrDefault().stList
                        on (a.GetType().GetProperty(list.FirstOrDefault().stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                        where it.cbItem
                        select a;

                foreach (var i in list)
                {
                     r = r.Union(from a in i.model
                            join it in i.stList
                            on (a.GetType().GetProperty(i.stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                            where it.cbItem 
                            select a);
                }
 
                if(schStr.Trim().Length>0)
                    r=r.Where(m=>m.Name.Contains(schStr));
                return r;
            }
            else
            {
                var r = from a in list.FirstOrDefault().model
                        join it in list.FirstOrDefault().stList
                        on (a.GetType().GetProperty(list.FirstOrDefault().stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                        where it.cbItem
                        select a;

                foreach (var i in list)
                {
                    r = r.Union(from a in i.model
                                join it in i.stList
                                on (a.GetType().GetProperty(i.stField).GetValue(a, null) ?? "Пусто").ToString() equals it.nmItem.ToString()
                                select a);
                }
                if (schStr.Trim().Length > 0)
                    r = r.Where(m => m.Name.Contains(schStr));
                return r;

            }

        }

        public List<SearchTerm> GetSortedList() // модель отфильтрованная по всем критериям
        {
            var ret = (from i in list
                       orderby i.stArrange ascending
                      select i).ToList();
            return ret;
        }
    }
}