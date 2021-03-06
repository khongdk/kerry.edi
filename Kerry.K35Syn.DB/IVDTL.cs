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
    
    public partial class IVDTL
    {
        public long IVHDR_UNID { get; set; }
        public int IVJOB_SNO { get; set; }
        public int SNO { get; set; }
        public string CHRGCODE { get; set; }
        public string CHRGDESC { get; set; }
        public Nullable<decimal> RATE { get; set; }
        public Nullable<decimal> QUANTITY { get; set; }
        public string QUANTITYUNIT { get; set; }
        public string CURRCODE { get; set; }
        public Nullable<decimal> EXRATE { get; set; }
        public Nullable<decimal> AMTFC { get; set; }
        public Nullable<decimal> AMTLC { get; set; }
        public Nullable<decimal> AMTBC { get; set; }
        public string VAT { get; set; }
        public Nullable<decimal> VATAMT { get; set; }
        public Nullable<decimal> VATAMTLC { get; set; }
        public short ISMIN { get; set; }
        public short ISPROGRESSIVE { get; set; }
        public string REMARK { get; set; }
        public string TAXNO { get; set; }
        public string TAXGROUP { get; set; }
        public Nullable<short> SORTORDER { get; set; }
        public string LOCALDESC { get; set; }
        public Nullable<int> SOURCESNO { get; set; }
        public Nullable<decimal> QUANTITY1 { get; set; }
        public string QUANTITY1UNIT { get; set; }
        public Nullable<long> SOURCEUNID { get; set; }
        public string SOURCETYPE { get; set; }
        public string REVCOST { get; set; }
        public Nullable<System.DateTime> ARRECVDATE { get; set; }
        public string ARPAID { get; set; }
        public string OFFSCURR { get; set; }
        public Nullable<decimal> OFFSEXRATE { get; set; }
        public Nullable<decimal> OFFSAMTFC { get; set; }
        public Nullable<decimal> OFFSAMTLC { get; set; }
        public Nullable<System.DateTime> OFFSETDATE { get; set; }
        public string QUANTITYDESC { get; set; }
        public string TAXABLE { get; set; }
        public string CATEGORY { get; set; }
        public Nullable<decimal> WHTAXPERCENT { get; set; }
        public Nullable<decimal> WHTAXAMT { get; set; }
        public string CHRGREFNO { get; set; }
        public string UNIQUENO { get; set; }
        public string SOURCEUNIQUENO { get; set; }
        public Nullable<short> ISDISBURSEMENT { get; set; }
        public string PROFITCENTRE { get; set; }
        public Nullable<decimal> TAX1RATE { get; set; }
        public Nullable<decimal> TAX1AMT { get; set; }
        public Nullable<decimal> TAX2RATE { get; set; }
        public Nullable<decimal> TAX2AMT { get; set; }
        public Nullable<short> TAX1IND { get; set; }
        public string TAX1FORMULA { get; set; }
        public Nullable<short> TAX2IND { get; set; }
        public string TAX2FORMULA { get; set; }
        public string EDIREFNO { get; set; }
        public string REVSTATUS { get; set; }
        public Nullable<int> IVPRINTDESCSNO { get; set; }
        public Nullable<decimal> TAX3RATE { get; set; }
        public Nullable<decimal> TAX3AMT { get; set; }
        public Nullable<short> TAX3IND { get; set; }
        public string TAX3FORMULA { get; set; }
        public Nullable<decimal> TAX4RATE { get; set; }
        public Nullable<decimal> TAX4AMT { get; set; }
        public Nullable<short> TAX4IND { get; set; }
        public string TAX4FORMULA { get; set; }
        public string AMENDMENT { get; set; }
        public Nullable<decimal> VATINCRATE { get; set; }
        public Nullable<decimal> VATINCAMTFC { get; set; }
        public Nullable<decimal> VATINCAMTLC { get; set; }
        public Nullable<short> DECLPARTFRT { get; set; }
        public Nullable<System.DateTime> RECOGNITIONDATE { get; set; }
        public Nullable<short> RECOGNITIONYEAR { get; set; }
        public Nullable<short> RECOGNITIONPERIOD { get; set; }
        public string COSTCENTRE { get; set; }
        public Nullable<short> PRINTORDER { get; set; }
        public string GROUPCODE { get; set; }
        public string SUSADVDOCNO { get; set; }
        public string SUSADVDOCTYPE { get; set; }
        public Nullable<decimal> DTLTAX1AMTLC { get; set; }
        public Nullable<decimal> DTLTAX2AMTLC { get; set; }
        public Nullable<decimal> DTLTAX3AMTLC { get; set; }
        public Nullable<decimal> DTLTAX4AMTLC { get; set; }
    }
}
