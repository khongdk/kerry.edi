using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service.Constants;

namespace Kerry.K35Syn.Service.Utility
{
    public class SynJob : IDisposable
    {
        private readonly K35Entities DB_K35;

        public SynJob()
        {
            this.DB_K35 = new K35Entities();
        }

        public List<TB_JOB> JobMapping(List<JOB> inputList)
        {
            var output = new List<TB_JOB>();

            using (K3Entities DB_K3 = new K3Entities())
            {
                foreach (JOB j in inputList)
                {
                    var job = new TB_JOB
                    {
                        JOB_NO = j.JOBNO,
                        SHIPMENT_TYPE = j.SHPTYPE,
                        SEND_KLN = "N",
                        BIZTYPE = j.BIZTYPE,
                        SHIPMENT_NO = j.SHPNO,
                        GLOBAL_SHIPMENT_ID = j.GSHPID,
                        MASTER_NO = j.CONSOLNO,
                        IS_NO_AWB = "N",
                        JOB_DATE = j.JOBDATE,
                        STATION_CODE = j.OWNERID,
                        SALES_TYPE = j.JOBOTHER.RLJ,
                        COLOAD_TYPE = j.JOBOTHER.COLOAD,
                        CUSTOMER_COMPANY_ID = GetCompnyID(j.PARTYID_CUST) == 0 ? null : GetCompnyID(j.PARTYID_CUST),
                        OVERSEAS_AGENT_ID = GetCompnyID(j.OAGENT) == 0 ? null : GetCompnyID(j.OAGENT),
                        INCOTERMS = j.JOBOTHER.INCOTERM,
                        SHIPPER_COMPANY_ID = GetCompnyID(j.PARTYID_SHPR) == 0 ? null : GetCompnyID(j.PARTYID_SHPR),
                        SHIPPER_NAME = j.SHPRNAME,
                        CONSIGNEE_COMPANY_ID = GetCompnyID(j.PARTYID_CSGN) == 0 ? null : GetCompnyID(j.PARTYID_CSGN),
                        CONSIGNEE_NAME = j.SHPRNAME,
                        ORIGIN_LOCATION_ID = GetLocationID(j.POLCITY) == 0 ? null : GetLocationID(j.POLCITY),
                        ORIGIN_LOCATION_CODE = j.POLCITY,
                        ORIGIN_COUNTRY_CODE = j.POLCTRY,
                        ORIGIN_DESCRIPTION = j.POLNAME,
                        DESTINATION_LOCATION_ID = GetLocationID(j.PODCITY) == 0 ? null : GetLocationID(j.PODCITY),
                        DESTINATION_LOCATION_CODE = j.PODCITY,
                        DESTINATION_COUNTRY_CODE = j.PODCTRY,
                        DESTINATION_DESCRIPTION = j.PODNAME,
                        ETD_DATE = j.FLTDATE,
                        CREATE_BY = ComConstants.DEFAULT_CREATE_BY,
                        CREATE_TIMESTAMP=DateTime.Now,
                        UPDATE_TIMESTAMP = DateTime.Now,
                        UPDATE_BY = ComConstants.DEFAULT_UPDATE_BY,
                        IS_LOCKED="N",
                        IS_CONSOL_CLOSED="N",
                        IS_CLOSED="N",

                        IS_ACTIVE = "Y",
                        STATION_ID = GetStationID(j.OWNERID)
                    };
                    output.Add(job);

                };
           } 
            
            return output;
        }


        public int GetStationID(string code)
        {

            return DB_K35.TB_STATION.Where(s => s.STATION_CODE.Equals(code)).Select(c => c.ID).FirstOrDefault();
        }

        public int? GetCompnyID(string code)
        {
                
                return DB_K35.TB_COMPANY.Where(c => c.COMPANY_CODE.Equals(code)).Select(c => c.ID).FirstOrDefault();
        }
        public int? GetLocationID(string code)
        {
                return DB_K35.TB_LOCATION.Where(l => l.LOCATION_CODE.Equals(code)).Select(l => l.ID).FirstOrDefault();
        }

        void IDisposable.Dispose()
        {
            DB_K35.Dispose();
        }
    }
}