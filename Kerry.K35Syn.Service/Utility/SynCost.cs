using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.Service.Model;
using Kerry.K35Syn.Service.Constants;

using Kerry.K35Syn.DB;

namespace Kerry.K35Syn.Service.Utility
{
    public class SynCost
    {
        public SynCost()
        {

        }


        public List<TB_COST> CostMapping(List<CostModel> inputList)
        {
            var costList =new List<TB_COST>();

            using (var DB_K35 = new K35Entities())
            {

                foreach (CostModel c in inputList)
                {
                    var _cost = new TB_COST
                    {
                       
                       STATION_ID= c.StationID,
                       STATION_CODE = c.StationCode,
                       INCOMING_BILL_ID = c.IncomingBillID,
                       INCOMING_BILL_NO=c.IncomingBillNO,
                       LOCAL_AMOUNT=c.LocalAMT,
                       FOREIGN_AMOUNT=c.ForeignAMT,
                       CURRENCY=c.Currency,
                       EXCHANGE_RATE=c.EXRATE,
                       JOB_ID=c.JobID,
                       UNIT_RATE=c.UnitRate,
                       UNIT=c.Unit,
                       QUANTITY=c.Quantity,
                       CHARGE_CODE_ID=c.ChargeCodeID,
                       STATUS="CON",
                       IS_AUTO_ALLOCATION="N",
                       CREATE_BY=ComConstants.DEFAULT_CREATE_BY,
                       CREATE_TIMESTAMP=DateTime.Now,
                       UPDATE_BY=ComConstants.DEFAULT_UPDATE_BY,
                       UPDATE_TIMESTAMP=DateTime.Now
                    };

                    _cost.COMPANY_NAME = DB_K35.TB_COMPANY.Where(p => p.COMPANY_CODE.Equals(c.CompanyCode)).Select(p => p.COMPANY_NAME_ENG).FirstOrDefault() ?? "";
                    _cost.COMPANY_ID = DB_K35.TB_COMPANY.Where(p => p.COMPANY_CODE.Equals(c.CompanyCode)).Select(p => p.ID).FirstOrDefault();
                    _cost.STATION_ID = DB_K35.TB_STATION.Where(p => p.STATION_CODE.Equals(_cost.STATION_CODE)).Select(p => p.ID).FirstOrDefault();
                    _cost.JOB_ID = DB_K35.TB_JOB.Where(p => p.JOB_NO.Equals(c.JobNO) && p.BIZTYPE.Equals(c.BizType)).Select(j => j.ID).FirstOrDefault();
                    _cost.CHARGE_CODE_ID = DB_K35.TB_CHARGE_CODE.Where(p => p.CHARGE_CODE.Equals(c.ChargeCode)).Select(p => p.ID).FirstOrDefault();

                    costList.Add(_cost);
                }


            }
            return costList;

        }

    }




}