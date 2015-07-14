using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Service.Interface;
using SLTest.Models;

namespace SLTest.Service.Factory
{
    public static class SortsServiceFactory
    {
        public static IBaseService<Sorts> Create()
        {
            return new SortsEntityService();
        }
    }
}