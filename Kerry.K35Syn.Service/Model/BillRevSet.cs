using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.DB;

namespace Kerry.K35Syn.Service.Model
{
    public class BillRevSet
    {
        public BillRevSet()
        {

            this.billRels = new List<TB_BILLING_REVENUE_REL>();
        }

        public TB_BILLING billing { get; set; }
        //public TB_REVENUE {get ; set;}
        public TB_REVENUE Revenue { get; set; }
        public List<TB_BILLING_REVENUE_REL> billRels { get; set; }
    }
}