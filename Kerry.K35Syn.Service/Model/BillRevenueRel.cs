using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Service.Model
{
    public class BillRevenueRel
    {
        public int ID { get; set; }
        public int BillID { get; set; }
        public int RevenueID { get; set; }
        public Nullable<decimal> BillAMT { get; set; }
        public string CREATE_BY { get; set; }
        public System.DateTime CreateTimeStamp { get; set; }
        public string UPDATE_BY { get; set; }
        public System.DateTime UpdateTimeStamp { get; set; }
        public string Remark { get; set; }

    }
}