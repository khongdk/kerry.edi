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
    
    public partial class TB_BILLING
    {
        public TB_BILLING()
        {
            this.TB_BILLING_REVENUE_REL = new HashSet<TB_BILLING_REVENUE_REL>();
        }
    
        public int ID { get; set; }
        public int JOB_ID { get; set; }
        public int STATION_ID { get; set; }
        public string STATION_CODE { get; set; }
        public string BIZTYPE { get; set; }
        public string BILL_NO { get; set; }
        public Nullable<System.DateTime> BILL_DATE { get; set; }
        public int BILL_TO_COMPANY_ID { get; set; }
        public string BILL_TO_NAME { get; set; }
        public string BILL_TO_ADDRESS { get; set; }
        public string OFFSET_BILL_NO { get; set; }
        public string PAYMENT_TERMS { get; set; }
        public Nullable<int> CREDIT_DAYS { get; set; }
        public Nullable<int> CURRENCY_ID { get; set; }
        public string CURRENCY_CODE { get; set; }
        public Nullable<decimal> EXCHANGE_RATE { get; set; }
        public Nullable<int> VAT_TYPE_ID { get; set; }
        public string VAT_CODE { get; set; }
        public Nullable<decimal> VAT_AMOUNT { get; set; }
        public Nullable<decimal> BILL_AMOUNT { get; set; }
        public Nullable<decimal> LOCAL_AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public string CONFIRM_BY { get; set; }
        public Nullable<System.DateTime> CONFIRM_DATE { get; set; }
        public string APPROVE_BY { get; set; }
        public Nullable<System.DateTime> APPROVE_DATE { get; set; }
        public string POST_BY { get; set; }
        public Nullable<System.DateTime> POST_DATE { get; set; }
        public Nullable<int> STATEMENT_ID { get; set; }
        public string CREATE_BY { get; set; }
        public System.DateTime CREATE_TIMESTAMP { get; set; }
        public string UPDATE_BY { get; set; }
        public System.DateTime UPDATE_TIMESTAMP { get; set; }
    
        public virtual TB_COMPANY TB_COMPANY { get; set; }
        public virtual TB_CURRENCY TB_CURRENCY { get; set; }
        public virtual TB_JOB TB_JOB { get; set; }
        public virtual ICollection<TB_BILLING_REVENUE_REL> TB_BILLING_REVENUE_REL { get; set; }
        public virtual TB_STATION TB_STATION { get; set; }
    }
}
