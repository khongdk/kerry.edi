using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using System.Linq;
using Kerry.K35Syn.Service.Model;
using System.Data;
using System.Data.Entity.Infrastructure;
using Kerry.K35Syn.Service.Utility;

namespace Kerry.K35Syn.ServiceUnit
{
    /// <summary>
    /// Summary description for CostTest
    /// </summary>
    [TestClass]
    public class CostTest
    {
        public CostTest()
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

            var costList = GetK3CostList().ToList();
            var synCost = new SynCost();
            var inputList = synCost.CostMapping(costList);
            InsertCost(inputList);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //
            // TODO: Add test logic here
            //

            var costList = GetK3ImpCostList().ToList();
            var synCost = new SynCost();
            var inputList = synCost.CostMapping(costList);
            InsertCost(inputList);
        }


        private static IEnumerable<CostModel> GetK3CostList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);
                    var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                                        .Where(j => (j.OWNERID.Equals("CNECNSZVA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AE") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    join c in DB_K3.COST on j.UNID equals c.JOB_UNID
                                    select new CostModel
                                    {
                                        CompanyCode = c.PAYEE_PARTYID,
                                        StationCode = j.OWNERID,
                                        ForeignAMT = (decimal)c.AMTFC,
                                        LocalAMT = (decimal)c.AMTLC,
                                        Currency = c.CURRCODE,
                                        EXRATE = (decimal)c.EXRATE,
                                        UnitRate = (decimal)c.RATE,
                                        Unit = c.QUANTITYUNIT,
                                        Quantity = (decimal)c.QUANTITY,
                                        BizType = j.BIZTYPE,
                                        JobNO = j.JOBNO,
                                    }).ToList();
                    return inputJob;

                }
                catch (Exception)
                {

                    throw;
                }



            }
        }



        private static IEnumerable<CostModel> GetK3ImpCostList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);
                    var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                                        .Where(j => (j.OWNERID.Equals("CNECNYZHA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AI") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    join c in DB_K3.COST on j.UNID equals c.JOB_UNID
                                    select new CostModel
                                    {
                                        CompanyCode = c.PAYEE_PARTYID,
                                        StationCode = j.OWNERID,
                                        ForeignAMT = (decimal)c.AMTFC,
                                        LocalAMT = (decimal)c.AMTLC,
                                        Currency = c.CURRCODE,
                                        EXRATE = (decimal)c.EXRATE,
                                        UnitRate = (decimal)c.RATE,
                                        Unit = c.QUANTITYUNIT,
                                        Quantity = (decimal)c.QUANTITY,
                                        JobNO = j.JOBNO,
                                        BizType = j.BIZTYPE,
                                        ChargeCode = c.CHRGCODE
                                    }).ToList();
                    return inputJob;

                }
                catch (Exception)
                {

                    throw;
                }



            }
        }


        private static void InsertCost(IEnumerable<TB_COST> input)
        {
            try
            {
                using (K35Entities DB_K35 = new K35Entities())
                {
                    //Temporary disable Foreign Key Constraint
                    DB_K35.Database.ExecuteSqlCommand("SET foreign_key_checks = 0;");
                    foreach (TB_COST j in input)
                    {
                        DB_K35.Entry<TB_COST>(j).State = EntityState.Added;
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
