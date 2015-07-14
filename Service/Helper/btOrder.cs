using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;



namespace SLTest.Models
{



    
    public static class getOrderInfo
    {
        private static coffeeEntities db = new coffeeEntities();

        public struct btOrderStru
        {
            public int? totOrdNum;
            public int? notPaidOrdNum;
            public bool active;
            public string userName;

        }

        public static btOrderStru getOrder(this System.Web.Mvc.ViewMasterPage parPage)
        {
            string parUser = parPage.Page.User.Identity.Name;//.User.Identity.Name;
            //btOrderStru ret=new btOrderStru();
            btOrderStru ret = new btOrderStru();
            if (parUser != null && parUser.Length > 0)
            {
               
                var result = from i in db.shipTo
                             where i.userName == parUser
                             group i by i.flPaid
                             //into iGr
                             //where iGr.Key==true
                             //select iGr.Count()
                             ;
              ret.totOrdNum = (from i in db.shipTo
                             where i.userName == parUser
                             select i).Count();
                             //into iGr
                             //where iGr.Key==true
                             //select iGr.Count()
                             ;

                ret.notPaidOrdNum = (from i in db.shipTo
                         where i.userName == parUser
                                && !(from odb in db.OrderDashBoards
                                    join os in db.OrderStages
                                    on odb.stageID2 equals os.ID
                                        where odb.shipToID==i.ID 
                                        && os.Descr.Contains("Оплачено")
                                        select odb).Any()
                            select i).Count();

                       
                ret.active = true;
                ret.userName = parUser;
            }
            else
            {
                ret.totOrdNum = null;
                ret.notPaidOrdNum = null;
                ret.active = false;
                ret.userName = null;
            }

            return ret;
        }

    }


}