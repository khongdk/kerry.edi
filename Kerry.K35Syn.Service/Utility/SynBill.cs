using Kerry.K35Syn.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.Service;
using Kerry.K35Syn.Service.Model;
using Kerry.K35Syn.Service.Constants;

namespace Kerry.K35Syn.Service.Utility
{
    public class SynBill
    {
        public SynBill()
        {
                
        }

        public List<TB_BILLING> BillingMapping(List<BillModel> inputList)
        {
            var billList = new List<TB_BILLING>();
            using (var DB_K35 = new K35Entities())
            {
                foreach (BillModel b in inputList)
                {
                    var _billRelset = new BillRevSet();
                    var _bill = new TB_BILLING { 
                    STATION_CODE = b.OwnerID,
                    BIZTYPE=b.BizType,
                    BILL_NO= b.BillNO,
                    BILL_DATE = b.BillDate,
                    //BILL_TO_COMPANY_ID=
                    BILL_TO_NAME = b.BillToName,
                    BILL_TO_ADDRESS=b.BillToAddress,
                    //PAYMENT_TERMS = 
                    CREDIT_DAYS = b.CreditDays,
                    //CURRENCY_ID=
                    CURRENCY_CODE=b.CurrencyCode,
                    EXCHANGE_RATE = b.EXRATE,
                    BILL_AMOUNT=b.BillAmt,
                    LOCAL_AMOUNT =b.LocalAmt,
                    STATUS = "CON",
                    CREATE_BY=ComConstants.DEFAULT_CREATE_BY,
                    CREATE_TIMESTAMP=DateTime.Now,
                    UPDATE_BY=ComConstants.DEFAULT_UPDATE_BY,
                    UPDATE_TIMESTAMP=DateTime.Now
                    };
                    _bill.JOB_ID = DB_K35.TB_JOB.Where(j => j.JOB_NO.Equals(b.JobNO) && j.BIZTYPE.Equals(b.BizType)).Select(j => j.ID).FirstOrDefault();
                    _bill.STATION_ID = DB_K35.TB_STATION.Where(s => s.STATION_CODE.Equals(b.OwnerID)).Select(s => s.ID).FirstOrDefault();
                    _bill.BILL_TO_COMPANY_ID = DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(b.CustPartyID)).Select(c => c.ID).FirstOrDefault();
                    _bill.CURRENCY_ID = DB_K35.TB_CURRENCY.Where(c => c.CURRENCY_CODE.Equals(b.CurrencyCode)).Select(c => c.ID).FirstOrDefault();


                    //var _billRevRels = new List<TB_BILLING_REVENUE_REL>();
                    //foreach(BillRevenueRel r in )
                    //{
                    //    var _billRevRel = new TB_BILLING_REVENUE_REL{
                    //    //BILLING_ID = r.BillID,
                    //    //REVENUE_ID=r.RevenueID,
                    //    BILLING_AMOUNT=r.BillAMT,
                    //    CREATE_BY=ComConstants.DEFAULT_CREATE_BY,
                    //    CREATE_TIMESTAMP=DateTime.Now,
                    //    UPDATE_BY=ComConstants.DEFAULT_UPDATE_BY,
                    //    UPDATE_TIMESTAMP=DateTime.Now
                    //    };
                    //    _billRevRels.Add(_billRevRel);
                    //}

                    //_billRelset.billing=_bill;
                    //_billRelset.billRels=_billRevRels;

                    billList.Add(_bill);

                    }

                }
                return billList;
            }

    }
}