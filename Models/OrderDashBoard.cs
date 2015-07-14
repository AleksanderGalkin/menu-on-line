using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Models.Interface;

namespace SLTest.Models
{
    
    public partial class OrderDashBoards
    {
        
        //public int shipToID { get; set; }
        //public int stageID1 { get; set; }
        //public int stageID2 { get; set; }
        //public DateTime stageDT { get; set; }
        //public string username { get; set; }
 

    }
    public partial class OrderStages:IBase
    {
        //public int ID { get; set; }
        //public string Descr { get; set; }
        //public string style { get; set; }
       public bool CanBeDeleted() { return true; }

    }

}