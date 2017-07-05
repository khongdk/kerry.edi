using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kerry.K35Syn.DB;
using System.Linq;
using Kerry.K35Syn.Service.Utility;
using System.Data;
using System.Data.Entity.Infrastructure;


namespace Kerry.K35Syn.ServiceUnit
{
     [TestClass]
    public class JobStationRelTest
    {

         [TestMethod]
         public void TestMethod1()
         {
             var jobs = GetK3JobList().ToList();
             var synJobStationRel = new SynJobStationRel();
             var input = synJobStationRel.JobStationRelMapping(jobs);
             InsertJobStationRel(input);
         }



         [TestMethod]
         public void TestMethod2()
         {
             var jobs = GetK3ImpJobList().ToList();
             var synJobStationRel = new SynJobStationRel();
             var input = synJobStationRel.JobStationRelMapping(jobs);
             InsertJobStationRel(input);
         }


         private static IEnumerable<JOB> GetK3JobList()
         {
             using (K3Entities DB_K3 = new K3Entities())
             {
                 try
                 {
                     var fltStartDate = new DateTime(2016, 01, 01);
                     var fltEndDate = new DateTime(2016, 02, 29);
                     var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                                         .Where(j => (j.OWNERID.Equals("CNECNSZVA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AE") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                     select j).ToList();
                     return inputJob;

                 }
                 catch (Exception ex)
                 {

                     throw;
                 }



             }
         }


         private static IEnumerable<JOB> GetK3ImpJobList()
         {
             using (K3Entities DB_K3 = new K3Entities())
             {
                 try
                 {
                     var fltStartDate = new DateTime(2016, 01, 01);
                     var fltEndDate = new DateTime(2016, 02, 29);
                     var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                                         .Where(j => (j.OWNERID.Equals("CNECNYZHA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AI") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                     select j).ToList();
                     return inputJob;

                 }
                 catch (Exception ex)
                 {

                     throw;
                 }



             }
         }

         private static void InsertJobStationRel(IEnumerable<TB_JOB_STATION_REL> input)
         {
             try
             {
                 using (K35Entities DB_K35 = new K35Entities())
                 {
                     foreach (TB_JOB_STATION_REL j in input)
                     {
                         DB_K35.Entry<TB_JOB_STATION_REL>(j).State = EntityState.Added;
                         DB_K35.SaveChanges();
                     }
                 }
             }
             catch (DbUpdateException ex)
             {

                 throw;
             }
         }
    }
}
