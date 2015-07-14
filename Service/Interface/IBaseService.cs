using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Models.Interface;

namespace SLTest.Service.Interface
{
    public interface IBaseService<T> where T:IBase,new()
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Get(string id);
        IEnumerable<T> GetToPage(int page, int itemsToPage);
        void Create(T dataObject);
        void Edit(T dataObject);
        void Delete(T dataObject);
        int Count();
        string IdField{get;}
        string NameField{get;}
    }
}