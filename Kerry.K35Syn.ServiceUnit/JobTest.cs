using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using System.Linq;
using System.Data;
using Kerry.K35Syn.Service.Utility;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;


namespace Kerry.K35Syn.ServiceUnit
{
    /// <summary>
    /// Summary description for JobTest
    /// </summary>
    [TestClass]
    public class JobTest
    {


        public JobTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void TestJobSync()
        {
            try
            {
                var jobs = GetK3JobList().ToList();
                //SelectJob();

                SynJob synjob = new SynJob();

                var input = synjob.JobMapping(jobs);

                InsertJob(input);
            }
            catch (ObjectDisposedException ex) 
            {
                
                throw ex;
            }
          
 
        }


        [TestMethod]
        public void TestJobIMPSync()
        {
            try
            {
                var jobs = GetK3IMPJobList().ToList();
                //SelectJob();

                SynJob synjob = new SynJob();

                var input = synjob.JobMapping(jobs);

                InsertJob(input);
            }
            catch (ObjectDisposedException ex)
            {

                throw ex;
            }


        }


        private static void InsertJob(IEnumerable<TB_JOB> input)
        {
            try
            {
                using (K35Entities DB_K35 = new K35Entities())
                {
                    foreach (TB_JOB j in input)
                    {
                        DB_K35.Entry<TB_JOB>(j).State = EntityState.Added;
                        DB_K35.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                
                throw;
            }
        }

        private static IEnumerable<JOB> GetK3JobList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                //var input = from j in DB_K3.JOB.Include()
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);
                    var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER")
                                        .Where(j => (j.OWNERID.Equals("CNECNSZVA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AE") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    select j).ToList();
                    return inputJob;

                }
                catch (Exception)
                {
                    throw;
                }
               


            }
        }

        private static IEnumerable<JOB> GetK3IMPJobList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                //var input = from j in DB_K3.JOB.Include()
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);
                    var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER")
                                        .Where(j => (j.OWNERID.Equals("'CNECNYZHA'") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AI") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    select j).ToList();
                    return inputJob;

                }
                catch (Exception)
                {
                    throw;
                }



            }
        }
        

    }
}
