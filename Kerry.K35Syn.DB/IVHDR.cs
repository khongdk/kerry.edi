//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kerry.K35Syn.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class IVHDR
    {
        public IVHDR()
        {
            this.IVJOB = new HashSet<IVJOB>();
        }
    
        public long UNID { get; set; }
        public string DOCNO { get; set; }
        public System.DateTime DOCDATE { get; set; }
        public string DOCTYPE { get; set; }
        public string DOCGROUP { get; set; }
        public string PARTYID_CUST { get; set; }
        public string CUSTNAME { get; set; }
        public string CUSTADDR1 { get; set; }
        public string CUSTADDR2 { get; set; }
        public string CUSTADDR3 { get; set; }
        public string CUSTADDR4 { get; set; }
        public string CUST_PIC { get; set; }
        public string CUST_TEL { get; set; }
        public string CUST_FAX { get; set; }
        public string CURRCODE { get; set; }
        public Nullable<decimal> EXRATE { get; set; }
        public string PPCC { get; set; }
        public string ACNO { get; set; }
        public string CRTERM { get; set; }
        public Nullable<short> CRDAYS { get; set; }
        public Nullable<System.DateTime> DUEDATE { get; set; }
        public Nullable<decimal> DOCAMTFC { get; set; }
        public Nullable<decimal> DOCAMTLC { get; set; }
        public string VAT { get; set; }
        public Nullable<decimal> VATAMT { get; set; }
        public Nullable<decimal> VATAMTLC { get; set; }
        public string REMARK { get; set; }
        public string TRAILERRMK { get; set; }
        public string REFNO { get; set; }
        public Nullable<System.DateTime> POSTDATE { get; set; }
        public Nullable<short> FINYEAR { get; set; }
        public Nullable<short> FINPERIOD { get; set; }
        public short MULTIJOB { get; set; }
        public string PRINTBY { get; set; }
        public Nullable<System.DateTime> PRINTDATE { get; set; }
        public string POSTBY { get; set; }
        public Nullable<System.DateTime> POSTDONE { get; set; }
        public string VOIDBY { get; set; }
        public Nullable<System.DateTime> VOIDDATE { get; set; }
        public string ORGID { get; set; }
        public string BIZTYPE { get; set; }
        public string CREATEBY { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public string UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
        public string PERPOSTMON { get; set; }
        public string PERPOSTBAT { get; set; }
        public string PERPOSTYEAR { get; set; }
        public string CO_PARTYID { get; set; }
        public string OWNERID { get; set; }
        public string SUMMARYDOCNO { get; set; }
        public string INVCATEGORY { get; set; }
        public string DEPTCODE { get; set; }
        public Nullable<System.DateTime> ARRECVDATE { get; set; }
        public string ARPAID { get; set; }
        public Nullable<short> ISSUMMARYINV { get; set; }
        public Nullable<decimal> CHQAMTLC { get; set; }
        public Nullable<decimal> CHQAMTFC { get; set; }
        public Nullable<decimal> CSHAMTLC { get; set; }
        public Nullable<decimal> CSHAMTFC { get; set; }
        public string CHQNO { get; set; }
        public Nullable<System.DateTime> CHQDATE { get; set; }
        public string BANKACCOUNT { get; set; }
        public string CSHACCOUNT { get; set; }
        public string CSHBANKCODE { get; set; }
        public string CSHREFNO { get; set; }
        public string TIMEZONE { get; set; }
        public string PSNO { get; set; }
        public string EXPORTTO { get; set; }
        public string USERHLEVEL { get; set; }
        public string SALESDEPT { get; set; }
        public string APPROVEBY1 { get; set; }
        public Nullable<System.DateTime> APPROVEDATE1 { get; set; }
        public string APPROVEBY2 { get; set; }
        public Nullable<System.DateTime> APPROVEDATE2 { get; set; }
        public Nullable<decimal> DOCAMTFC2LC { get; set; }
        public string OFFSCURR { get; set; }
        public Nullable<decimal> OFFSEXRATE { get; set; }
        public Nullable<decimal> OFFSAMTFC { get; set; }
        public Nullable<decimal> OFFSAMTLC { get; set; }
        public string SALES { get; set; }
        public string RCPMODE { get; set; }
        public string RCPBANK { get; set; }
        public string RCPACCOUNT { get; set; }
        public string POSTREFNO { get; set; }
        public string PRINTREMARK1 { get; set; }
        public string PRINTREMARK2 { get; set; }
        public string PRINTSNO { get; set; }
        public string BATCHPOSTNO { get; set; }
        public string CONAME { get; set; }
        public Nullable<int> PRINTLOGSNO { get; set; }
        public Nullable<System.DateTime> OFFSETDATE { get; set; }
        public string VOIDPOSTBY { get; set; }
        public Nullable<System.DateTime> VOIDPOSTDATE { get; set; }
        public string OFFSETPOSTBY { get; set; }
        public Nullable<System.DateTime> OFFSETPOSTDATE { get; set; }
        public Nullable<System.DateTime> FINPOSTDATE { get; set; }
        public string FINPOSTBY { get; set; }
        public string CHQISSUEBANK { get; set; }
        public string CRDTYPE { get; set; }
        public string CUSTECVATNO { get; set; }
        public string CNNO { get; set; }
        public string ORGDOCNO { get; set; }
        public string APPLYTODOCNO { get; set; }
        public Nullable<decimal> TTLWHTAXAMT { get; set; }
        public string POSTBY2 { get; set; }
        public Nullable<System.DateTime> POSTDONE2 { get; set; }
        public string VOIDREASON { get; set; }
        public Nullable<decimal> TAX1AMT { get; set; }
        public Nullable<decimal> TAX2AMT { get; set; }
        public string INTFSTATUS { get; set; }
        public string STATUS { get; set; }
        public string CRTERMCODE { get; set; }
        public string CUSTCATE { get; set; }
        public string PRINTTITLE { get; set; }
        public Nullable<short> ISFULLCN { get; set; }
        public string INVOICETYPE { get; set; }
        public string REFBATCHNO { get; set; }
        public string PRINTPOSTBY { get; set; }
        public Nullable<System.DateTime> PRINTPOSTDATE { get; set; }
        public string DEBITREFNO { get; set; }
        public Nullable<System.DateTime> CONFIRMDATE { get; set; }
        public string CONFIRMBY { get; set; }
        public Nullable<decimal> TAXINVTOTAMTLC { get; set; }
        public Nullable<decimal> RECEIPTTOTAMTLC { get; set; }
        public string RECEIPTNO { get; set; }
        public Nullable<decimal> TAXINVTOTVATAMTLC { get; set; }
        public Nullable<decimal> TAX3AMT { get; set; }
        public Nullable<decimal> TAX4AMT { get; set; }
        public string CHRGTYPE { get; set; }
        public string CUSTADDR_POSTALCODE { get; set; }
        public Nullable<long> SYDOCUNID { get; set; }
        public Nullable<decimal> TAX1AMTLC { get; set; }
        public Nullable<decimal> TAX2AMTLC { get; set; }
        public Nullable<decimal> TAX3AMTLC { get; set; }
        public Nullable<decimal> TAX4AMTLC { get; set; }
        public string HDRPROFITCENTRE { get; set; }
        public Nullable<short> ISICA { get; set; }
    
        public virtual ICollection<IVJOB> IVJOB { get; set; }
    }
}
