using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTest.Models
{
    public class menuStage
    {
        public struct acceptedItems {
            string itemText;
            string controller ;
            string method;
        } 
        public string curStyle {get;set;}
        public List<acceptedItems> itemText { get; set; }
        
        
    }
}