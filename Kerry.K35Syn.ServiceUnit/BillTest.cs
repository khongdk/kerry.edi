using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using Kerry.K35Syn.Service.Model;
using Kerry.K35Syn.Service.Utility;
using System.Data;

namespace Kerry.K35Syn.ServiceUnit
{
    /// <summary>
    /// Summary description for BillTest
    /// </summary>
    [TestClass]
    public class BillTest
    {
        public BillTest()
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
            var bills = GetK3BillList().ToList();
            var synBill = new SynBill();
            var input = synBill.BillingMapping(bills);
            InsertBill(input);
        }


        [TestMethod]
        public void TestMethod2()
        {
            //
            // TODO: Add test logic here
            //

            var bills = GetK3ImpBillList().ToList();
            var synBill = new SynBill();

            var input = synBill.BillingMapping(bills);

            InsertBill(input);

        }
        private static IEnumerable<BillModel> GetK3BillList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                //var input = from j in DB_K3.JOB.Include()
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);

                    var inputJob = (from j in DB_K3.JOB
                                        .Where(j => (j.OWNERID.Equals("CNECNSZVA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AE") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    join v in DB_K3.IVJOB on j.UNID equals v.JOB_UNID into m
                                    from n in m.DefaultIfEmpty()
                                    join h in DB_K3.IVHDR on n.IVHDR_UNID equals h.UNID into z
                                    from x in z.DefaultIfEmpty()
                                    where x.UNID != null
                                    select new BillModel
                                    {
                                        StationCode = j.OWNERID,
                                        OwnerID = j.OWNERID,
                                        JobNO = j.JOBNO,
                                        CustPartyID = x.PARTYID_CUST,
                                        BizType = j.BIZTYPE,
                                        BillNO = x.DOCNO,
                                        BillDate = x.DOCDATE,
                                        //BillToCompanyID=i.
                                        BillToName = x.CUSTNAME,
                                        BillToAddress = string.Concat(x.CUSTADDR1, x.CUSTADDR2, x.CUSTADDR3, x.CUSTADDR4),
                                        CreditDays = x.CRDAYS,
                                        CurrencyCode = x.CURRCODE,
                                        EXRATE = x.EXRATE,
                                        BillAmt = x.DOCAMTFC,
                                        LocalAmt = x.DOCAMTLC,
                                        //BillRevRel  = x.  
                                        //BillRevRel = (from i in DB_K3.IVDTL
                                        //              join s in DB_K3.REVENUE on "IVUNID" + i.IVHDR_UNID + "SNO" + i.SOURCESNO equals "IVUNID" + s.IVHDRUNID + "SNO" + s.SNO into g
                                        //              where i.IVHDR_UNID.Equals(x.UNID) && i.REVCOST.Equals("revenue")
                                        //              from t in g.DefaultIfEmpty()
                                        //              select new BillRevenueRel { 
                                        //                    BillAMT = i.AMTBC
                                        //              }
                                        //                  ).ToList()
                                    }).ToList();
                    return inputJob;

                }
                catch (Exception)
                {
                    throw;
                }



            }
        }


        private static IEnumerable<BillModel> GetK3ImpBillList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {
                //var input = from j in DB_K3.JOB.Include()
                try
                {
                    var fltStartDate = new DateTime(2016, 01, 01);
                    var fltEndDate = new DateTime(2016, 02, 29);






                    var inputJob = (from j in DB_K3.JOB
                                        .Where(j => (j.OWNERID.Equals("CNECNYZHA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AI") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))
                                    join v in DB_K3.IVJOB on j.UNID equals v.JOB_UNID into m
                                    from n in m.DefaultIfEmpty()
                                    join h in DB_K3.IVHDR on n.IVHDR_UNID equals h.UNID into z
                                    from x in z.DefaultIfEmpty()
                                    where x.UNID != null
                                    select new BillModel
                                    {
                                        StationCode = j.OWNERID,
                                        OwnerID = j.OWNERID,
                                        JobNO = j.JOBNO,
                                        CustPartyID = x.PARTYID_CUST,
                                        BizType = j.BIZTYPE,
                                        BillNO = x.DOCNO,
                                        BillDate = x.DOCDATE,
                                        //BillToCompanyID=i.
                                        BillToName = x.CUSTNAME,
                                        BillToAddress = string.Concat(x.CUSTADDR1, x.CUSTADDR2, x.CUSTADDR3, x.CUSTADDR4),
                                        CreditDays = x.CRDAYS,
                                        CurrencyCode = x.CURRCODE,
                                        EXRATE = x.EXRATE,
                                        BillAmt = x.DOCAMTFC,
                                        LocalAmt = x.DOCAMTLC,
                                    }).ToList();
                    return inputJob;

                }
                catch (Exception)
                {
                    throw;
                }



            }
        }


        private static void InsertBill(IEnumerable<TB_BILLING> input)
        {
            try
            {
                using (K35Entities DB_K35 = new K35Entities())
                {
                    foreach (TB_BILLING j in input)
                    {
                        DB_K35.Database.ExecuteSqlCommand("SET foreign_key_checks =0");
                        //DB_K35.Database.ExecuteSqlCommand("set names gbk");
                        DB_K35.Entry<TB_BILLING>(j).State = EntityState.Added;
                        DB_K35.SaveChanges();
                        //foreach (TB_BILLING_REVENUE_REL r in j.billRels)
                        //{
                        //    DB_K35.Database.ExecuteSqlCommand("SET foreign_key_checks =0");
                        //    //DB_K35.Database.ExecuteSqlCommand("set names gbk");
                        //    DB_K35.Entry<TB_BILLING_REVENUE_REL>(r).State = EntityState.Added;
                        //    DB_K35.SaveChanges();
                        //}

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
