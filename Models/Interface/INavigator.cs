using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTest.Models.Interface
{
    public interface INavigator
    {
         string Sort { get; set; }
         string Name { get; set; }
    }
}