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
    /// <summary>
    /// Summary description for AWBTest
    /// </summary>
    [TestClass]
    public class AWBTest
    {
        public AWBTest()
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

            try
            {
                  var jobs = GetK3JobList().ToList();
                  var synAWB = new SynAWB();
                  var input = synAWB.AWBMapping(jobs);
                  InsertAWB(input);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        [TestMethod]
        public void TestMethod2()
        {
            //
            // TODO: Add test logic here
            //

            try
            {
                var jobs = GetK3ImpJobList().ToList();
                var synAWB = new SynAWB();
                var input = synAWB.AWBMapping(jobs);
                InsertAWB(input);
            }
            catch (Exception)
            {

                throw;
            }
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
                catch (Exception)
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
                catch (Exception)
                {

                    throw;
                }



            }
        }

        private static void InsertAWB(IEnumerable<TB_AWB> input)
        {
            try
            {
                using (K35Entities DB_K35 = new K35Entities())
                {
                    DB_K35.Database.ExecuteSqlCommand("SET foreign_key_checks =0");
                    foreach (TB_AWB j in input)
                    {
                        DB_K35.Entry<TB_AWB>(j).State = EntityState.Added;
                        DB_K35.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
