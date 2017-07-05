using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Service.Model
{
    public class BillRevModel
    {
        public BillRevModel()
        {

        }
        public BillModel Bill { get; set; }
        
        public RevenueModel Revenue { get; set; }


        public List<BillRevenueRel> MyProperty { get; set; }

    }
}