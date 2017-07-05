using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using Kerry.K35Syn.Service.Constants;
using Kerry.K35Syn.Service.Model;

namespace Kerry.K35Syn.Service.Utility
{
    public class SynRevenue
    {
        public SynRevenue()
        {

        }

        public List<TB_REVENUE> RevenueMapping(List<RevenueModel> inputList)
        {
            var revenueList =new List<TB_REVENUE>();
            using (K35Entities DB_K35 = new K35Entities())
            {
                foreach (RevenueModel r in inputList)
                {
                    var _revenue = new TB_REVENUE
                    {
                        STATION_CODE=r.StationCode,
                        LOCAL_AMOUNT =(decimal)r.LocalAMT,
                        FOREIGN_AMOUNT = (decimal)r.ForeignAMT,
                        CURRENCY=r.Currency,
                        EXCHANGE_RATE = (decimal)r.EXRATE,
                        JOB_ID= r.JobID,
                        UNIT_RATE = (decimal)r.UnitRate,
                        UNIT=r.Unit,
                        QUANTITY = r.Quantity,
                        CHARGE_CODE_ID=r.ChargeCodeID,
                        STATUS="CON",
                        IS_AUTO_ALLOCATION="N",
                        IS_ALL_IN="N",
                        CREATE_BY=ComConstants.DEFAULT_CREATE_BY,
                        CREATE_TIMESTAMP=DateTime.Now,
                        UPDATE_BY=ComConstants.DEFAULT_UPDATE_BY,
                        UPDATE_TIMESTAMP=DateTime.Now,
                        IS_ALLOCATE_TO_ORIGIN="N",
                        BILL_NO = r.BillNO,
                        VAT_AMOUNT = r.BillAMT
                    };
                    _revenue.COMPANY_NAME = DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(r.CompanyCode)).Select(c=>c.COMPANY_NAME_ENG).FirstOrDefault()??"";
                    _revenue.COMPANY_ID = DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(r.CompanyCode)).Select(c => c.ID).FirstOrDefault();
                    _revenue.STATION_ID = DB_K35.TB_STATION.Where(c => c.STATION_CODE.Equals(_revenue.STATION_CODE)).Select(c => c.ID).FirstOrDefault();
                    _revenue.JOB_ID = DB_K35.TB_JOB.Where(c=>c.JOB_NO.Equals(r.JobNo)&&c.BIZTYPE.Equals(r.BizType)).Select(j=>j.ID).FirstOrDefault();
                    _revenue.CHARGE_CODE_ID = DB_K35.TB_CHARGE_CODE.Where(c=>c.CHARGE_CODE.Equals(r.ChargeCode)).Select(c=>c.ID).FirstOrDefault();
                    revenueList.Add(_revenue);
                }
                return revenueList;

                
            }

        }
    }
}