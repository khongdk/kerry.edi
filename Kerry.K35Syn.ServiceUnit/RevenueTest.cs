using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kerry.K35Syn.DB;
using Kerry.K35Syn.Service;
using Kerry.K35Syn.Service.Model;
using System.Linq;
using Kerry.K35Syn.Service.Utility;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace Kerry.K35Syn.ServiceUnit
{
    /// <summary>
    /// Summary description for RevenueTest
    /// </summary>
    [TestClass]
    public class RevenueTest
    {
        public RevenueTest()
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
                var revenueList = GetK3RevenueList().ToList();
                var synRevenues = new SynRevenue();

                var input = synRevenues.RevenueMapping(revenueList);

                InsertRevenue(input);

            }
            catch (Exception ex)
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
                var revenueList = GetK3ImpRevenueList().ToList();
                var synRevenues = new SynRevenue();

                var input = synRevenues.RevenueMapping(revenueList);

                InsertRevenue(input);

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        private static IEnumerable<RevenueModel> GetK3RevenueList()
        {
            using (K3Entities DB_K3 = new K3Entities())
            {


                string sql = " SELECT j.biztype    AS BizType, " +
                            " dtl.amtbc         AS BillAMT, " +
                            " r.BILLING_PARTYID AS CompanyCode, " +
                            " j.ownerid         AS StationCode, " +
                            " NVL(r.AMTFC,0)    AS ForeignAMT, " +
                            " NVL(r.AMTLC,0)      AS LocalAMT, " +
                            " r.CURRCODE        AS Currency, " +
                            " NVL(r.EXRATE,0)   AS EXRATE, " +
                            " NVL(r.RATE,0) AS RATE, " +
                            " r.QUANTITYUNIT    AS Unit, " +
                            " NVL(r.QUANTITY ,0)AS Quantity, " +
                            " j.JobNo AS JobNo, " +
                            " r.CHRGCODE      AS ChargeCode, " +
                            " INVDOCNO          AS BillNO " +
                            " FROM revenue r " +
                            " INNER JOIN job j " +
                            " ON r.job_unid = j.unid " +
                            " LEFT JOIN ivhdr ih " +
                            " ON r.invdocno = ih.docno " +
                            " LEFT JOIN ivdtl dtl " +
                            " ON ih.unid         = dtl.ivhdr_unid " +
                            " AND r.sno          = dtl.sourcesno " +
                            " WHERE J.ownerid   IN ( 'CNECNSZVA', 'CNECNHFEA' ) " +
                            " AND J.biztype     IN ('AE') " +
                            " AND J.shptype     IN ('H','M','D') " +
                            " AND J.jobstagecode = 'S' " +
                            " AND J.fltdate BETWEEN to_date('01012016 000000','ddmmyyyy hh24:mi:ss') AND to_date('29022016 235959','ddmmyyyy hh24:mi:ss') " +
                            " AND ih.voidby   IS NULL " +
                            " AND ih.voiddate IS NULL";
                try
                {
                var inputJob = DB_K3.Database.SqlQuery<RevenueModel>(sql).ToList();


               
                //    var fltStartDate = new DateTime(2016, 01, 01);
                //    var fltEndDate = new DateTime(2016, 02, 29);
                //    var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                //                        .Where(j => (j.OWNERID.Equals("CNECNSZVA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AE") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))

                //                    join r in DB_K3.REVENUE on j.UNID equals r.JOB_UNID into z
                //                    from x in z.DefaultIfEmpty()
                //                    join d in DB_K3.IVHDR on x.INVDOCNO equals d.DOCNO into m
                //                    from n in m.DefaultIfEmpty()
                //                    join y in DB_K3.IVDTL on new { Unid = n.UNID, Sno = x.SNO } equals new { Unid = y.IVHDR_UNID, Sno = y.SOURCESNO ?? 0 } into o
                //                    //join y in DB_K3.IVDTL on new { IVHDR_UNID = n.UNID, SOURCESNO = x.SNO } equals new { y.IVHDR_UNID, y.SOURCESNO } into o
                //                    from e in o.DefaultIfEmpty()
                //                    select new RevenueModel
                //                    {
                //                        BizType = j.BIZTYPE,
                //                        BillAMT = e.AMTBC,
                //                        CompanyCode = x.BILLING_PARTYID,
                //                        StationCode = j.OWNERID,
                //                        ForeignAMT = x.AMTFC ?? 0,
                //                        LocalAMT = x.AMTLC ?? 0,
                //                        Currency = x.CURRCODE,
                //                        EXRATE = x.EXRATE ?? 0,
                //                        UnitRate = x.RATE ?? 0,
                //                        Unit = x.QUANTITYUNIT,
                //                        Quantity = x.QUANTITY ?? 0,
                //                        JobNo = j.JOBNO,
                //                        ChargeCode = x.CHRGCODE,
                //                        BillNO = x.INVDOCNO
                //                    }).Where(q => !string.IsNullOrEmpty(q.Unit)).ToList();
                    return inputJob;

                }
                catch (Exception ex)
                {

                    throw;
                }



            }
        }



        private static IEnumerable<RevenueModel> GetK3ImpRevenueList()
        {

            using (K3Entities DB_K3 = new K3Entities())
            {


                string sql = " SELECT j.biztype    AS BizType, " +
                           " dtl.amtbc         AS BillAMT, " +
                           " r.BILLING_PARTYID AS CompanyCode, " +
                           " j.ownerid         AS StationCode, " +
                           " NVL(r.AMTFC,0)    AS ForeignAMT, " +
                           " NVL(r.AMTLC,0)      AS LocalAMT, " +
                           " r.CURRCODE        AS Currency, " +
                           " NVL(r.EXRATE,0)   AS EXRATE, " +
                           " NVL(r.RATE,0) AS RATE, " +
                           " r.QUANTITYUNIT    AS Unit, " +
                           " NVL(r.QUANTITY ,0)AS Quantity, " +
                           " j.JobNo AS JobNo, " +
                           " r.CHRGCODE      AS ChargeCode, " +
                           " INVDOCNO          AS BillNO " +
                           " FROM revenue r " +
                           " INNER JOIN job j " +
                           " ON r.job_unid = j.unid " +
                           " LEFT JOIN ivhdr ih " +
                           " ON r.invdocno = ih.docno " +
                           " LEFT JOIN ivdtl dtl " +
                           " ON ih.unid         = dtl.ivhdr_unid " +
                           " AND r.sno          = dtl.sourcesno " +
                           " WHERE J.ownerid   IN ( 'CNECNYZHA', 'CNECNHFEA' ) " +
                           " AND J.biztype     IN ('AI') " +
                           " AND J.shptype     IN ('H','M','D') " +
                           " AND J.jobstagecode = 'S' " +
                           " AND J.fltdate BETWEEN to_date('01012016 000000','ddmmyyyy hh24:mi:ss') AND to_date('29022016 235959','ddmmyyyy hh24:mi:ss') " +
                           " AND ih.voidby   IS NULL " +
                           " AND ih.voiddate IS NULL";



                try
                {
                    var inputJob = DB_K3.Database.SqlQuery<RevenueModel>(sql).ToList();

                    //var fltStartDate = new DateTime(2016, 01, 01);
                    //var fltEndDate = new DateTime(2016, 02, 29);
                    //var inputJob = (from j in DB_K3.JOB.Include("JOBOTHER").Include("AIRROUTE")
                    //                    .Where(j => (j.OWNERID.Equals("CNECNYZHA") || j.OWNERID.Equals("CNECNHFEA")) && j.BIZTYPE.Equals("AI") && j.JOBSTAGECODE.Equals("S") && ((DateTime.Compare((DateTime)j.FLTDATE, fltStartDate) >= 0) && (DateTime.Compare((DateTime)j.FLTDATE, fltEndDate) <= 0)))

                    //                join r in DB_K3.REVENUE on j.UNID equals r.JOB_UNID into z
                    //                from x in z.DefaultIfEmpty()
                    //                join d in DB_K3.IVHDR on x.INVDOCNO equals d.DOCNO into m
                    //                from n in m.DefaultIfEmpty()
                    //                join y in DB_K3.IVDTL on new { Unid = n.UNID, Sno = x.SNO } equals new { Unid = y.IVHDR_UNID, Sno = y.SOURCESNO ?? 0 } into o
                    //                //join y in DB_K3.IVDTL on new { IVHDR_UNID = n.UNID, SOURCESNO = x.SNO } equals new { y.IVHDR_UNID, y.SOURCESNO } into o
                    //                from e in o.DefaultIfEmpty()
                    //                select new RevenueModel
                    //                {
                    //                    BizType = j.BIZTYPE,
                    //                    BillAMT = e.AMTBC,
                    //                    CompanyCode = x.BILLING_PARTYID,
                    //                    StationCode = j.OWNERID,
                    //                    ForeignAMT = x.AMTFC ?? 0,
                    //                    LocalAMT = x.AMTLC ?? 0,
                    //                    Currency = x.CURRCODE,
                    //                    EXRATE = x.EXRATE ?? 0,
                    //                    UnitRate = x.RATE ?? 0,
                    //                    Unit = x.QUANTITYUNIT,
                    //                    Quantity = x.QUANTITY ?? 0,
                    //                    JobNo = j.JOBNO,
                    //                    ChargeCode = x.CHRGCODE,
                    //                    BillNO = x.INVDOCNO
                    //                }).Where(q => !string.IsNullOrEmpty(q.Unit)).ToList();
                    return inputJob;

                }
                catch (Exception ex)
                {

                    throw;
                }



            }

          
        }

        private static void InsertRevenue(IEnumerable<TB_REVENUE> input)
        {
            try
            {
                using (K35Entities DB_K35 = new K35Entities())
                {
                    //Temporary disable Foreign Key Constraint
                    DB_K35.Database.ExecuteSqlCommand("SET foreign_key_checks = 0;");
                    foreach (TB_REVENUE j in input)
                    {
                        DB_K35.Entry<TB_REVENUE>(j).State = EntityState.Added;
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