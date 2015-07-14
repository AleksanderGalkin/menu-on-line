using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTest.Models
{
    public class VMOrder
    {
        public Int64 OrderID { get; set; }
        public Int64 ClientID { get; set; }
        public Int64 NumTable { get; set; }
        public DateTime OrderDataTime { get; set; }
        public string Comment { get; set; }

        public Int64 OrderRecID { get; set; }
        public Int64 RecID { get; set; }
        public string RecName { get; set; }

        public Int64 OrderOptID { get; set; }
        public Int64 OptID { get; set; }
        public string OptionName { get; set; }


    }
}