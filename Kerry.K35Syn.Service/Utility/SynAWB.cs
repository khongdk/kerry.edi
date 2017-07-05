using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service.Constants;


namespace Kerry.K35Syn.Service.Utility
{
    public class SynAWB
    {
        public SynAWB()
        {

        }

        public List<TB_AWB> AWBMapping(List<JOB> inputList)
        {
            var awbList = new List<TB_AWB>();

            try
            {

           
            #region
            using (K35Entities DB_K35 = new K35Entities())
            {
                foreach (JOB j in inputList)
                {
                    var _awb = new TB_AWB
                    {
                        BOOKED_QTY = j.TOTPCS,
                        BOOKED_QTY_UNIT = j.TOTPCS_UT,
                        BOOKED_WEIGHT = j.TOTCWGT,
                        BOOKED_WEIGHT_UNITS = j.TOTCWGT_UT,
                        BOOKED_VOLUME = j.TOTVOL,
                        BOOKED_VOLUME_UNITS = j.TOTVOL_UT,
                        BILLING_QTY = j.TOTPCS,
                        BILLING_QTY_UNIT = j.TOTPCS_UT,
                        BILLING_WEIGHT = j.TOTGWGT,
                        BILLING_WEIGHT_UNITS = j.TOTGWGT_UT,
                        BILLING_VOLUME = j.VWGT,
                        BILLING_VOLUME_UNITS = j.VWGT_UT,
                        GROSS_WEIGHT = j.TOTGWGT,
                        CHARGEABLE_WEIGHT = j.TOTCWGT,
                        BILLING_CHARGEABLE_WEIGHT = j.TOTCWGT,
                        COMMODITY_CODE = j.JOBOTHER.COMMCODE,
                        COMMODITY_DESCRIPTION = j.JOBOTHER.COMM,
                        CREATE_BY = Constants.ComConstants.DEFAULT_CREATE_BY,
                        UPDATE_BY = Constants.ComConstants.DEFAULT_UPDATE_BY,
                        CREATE_TIMESTAMP = DateTime.Now,
                        UPDATE_TIMESTAMP = DateTime.Now
                    };

                    _awb.JOB_ID = DB_K35.TB_JOB.Where(k=>k.JOB_NO.Equals(j.JOBNO)&&k.CREATE_BY.Equals(ComConstants.DEFAULT_CREATE_BY)&&k.SHIPMENT_TYPE.Equals(j.SHPTYPE)).Select(k=>k.ID).FirstOrDefault();
                    var _airRoute = j.AIRROUTE.Where(a=>a.SNO==1&&!string.IsNullOrEmpty(a.DESTCITY)).FirstOrDefault();
                    var _airRoute2 = j.AIRROUTE.Where(a=>a.SNO==2&&!string.IsNullOrEmpty(a.DESTCITY)).FirstOrDefault();
                    var _airRoute3 = j.AIRROUTE.Where(a=>a.SNO==3&&!string.IsNullOrEmpty(a.DESTCITY)).FirstOrDefault();

                    _awb.FLIGHT1_ORIGIN_ID = DB_K35.TB_LOCATION.Where(l=>l.LOCATION_CODE.Equals(_airRoute.ORIGINCITY)&&l.COUNTRY_CODE.Equals(_airRoute.ORIGINCTRY)).Select(l=>l.ID).FirstOrDefault();
                    _awb.FLIGHT1_DESTINATION_ID = DB_K35.TB_LOCATION.Where(l=>l.LOCATION_CODE.Equals(_airRoute.DESTCITY)&&l.COUNTRY_CODE.Equals(_airRoute.DESTCTRY)).Select(l=>l.ID).FirstOrDefault();
                    _awb.FLIGHT1_CARRIER_ID = DB_K35.TB_COMPANY.Where(c=>c.COMPANY_CODE.Equals(_airRoute.CARRIERCODE)).Select(c=>c.ID).FirstOrDefault();
                    if (_airRoute2 != null) {
                        _awb.FLIGHT2_DESTINATION_ID = DB_K35.TB_LOCATION.Where(l => l.LOCATION_CODE.Equals(_airRoute2.DESTCITY) && l.COUNTRY_CODE.Equals(_airRoute2.DESTCTRY)).Select(l => l.ID).FirstOrDefault();
                        _awb.FLIGHT2_CARRIER_ID = DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(_airRoute2.CARRIERCODE)).Select(c => c.ID).FirstOrDefault();
                    }
                    if (_airRoute3 != null)
                    {
                        _awb.FLIGHT3_DESTINATION_ID = DB_K35.TB_LOCATION.Where(l => l.LOCATION_CODE.Equals(_airRoute3.DESTCITY) && l.COUNTRY_CODE.Equals(_airRoute3.DESTCTRY)).Select(l => l.ID).FirstOrDefault();
                        _awb.FLIGHT3_CARRIER_ID = DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(_airRoute3.CARRIERCODE)).Select(c => c.ID).FirstOrDefault();
                    }

                    awbList.Add(_awb);

                }

                return awbList;

            }
            #endregion
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}