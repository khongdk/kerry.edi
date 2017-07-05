using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using Kerry.K35Syn.Service.Constants;

namespace Kerry.K35Syn.Service.Utility
{
    public class SynJobStationRel
    {
        public SynJobStationRel()
        {

        }

        public List<TB_JOB_STATION_REL> JobStationRelMapping(List<JOB> inputList)
        {
            var output = new List<TB_JOB_STATION_REL>();
            try
            {

           
            using (K35Entities DB_K35 = new K35Entities())
            {
                foreach(JOB j in inputList)
                {
                    var _jStdRel = new TB_JOB_STATION_REL{
                        STATION_CODE=j.OWNERID,
                        STATION_ROLE = j.BIZTYPE.Equals("AE")?"ORIGIN":j.BIZTYPE.Equals("AI")?"GATEWAY":null,
                        BIZTYPE=j.BIZTYPE,
                        CREATE_BY = ComConstants.DEFAULT_CREATE_BY,
                        CREATE_TIMESTAMP=DateTime.Now,
                        UPDATE_BY=ComConstants.DEFAULT_UPDATE_BY,
                        UPDATE_TIMESTAMP=DateTime.Now,
                        SNO=1
                    };

                    _jStdRel.JOB_ID = DB_K35.TB_JOB.Where(k => k.JOB_NO.Equals(j.JOBNO) && k.CREATE_BY.Equals(ComConstants.DEFAULT_CREATE_BY) && k.SHIPMENT_TYPE.Equals(j.SHPTYPE)).Select(k => k.ID).FirstOrDefault();
                    _jStdRel.STATION_ID = DB_K35.TB_STATION.Where(c => c.STATION_CODE.Equals(j.OWNERID)).Select(c=>c.ID).FirstOrDefault();
                    output.Add(_jStdRel);
                }
                return output;
            }
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
    }
}