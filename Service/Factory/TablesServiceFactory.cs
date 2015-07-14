using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service.Factory
{
    public static class TablesServiceFactory
    {
        public static IBaseService<Tables> Create()
        {
            return new TablesEntityService();
        }
    }
}