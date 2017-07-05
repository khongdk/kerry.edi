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
    
    public partial class TB_COST
    {
        public TB_COST()
        {
            this.TB_COST1 = new HashSet<TB_COST>();
        }
    
        public int ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public int COMPANY_ID { get; set; }
        public int STATION_ID { get; set; }
        public string STATION_CODE { get; set; }
        public Nullable<int> VAT_TYPE_ID { get; set; }
        public Nullable<decimal> VAT_PERCENTAGE { get; set; }
        public Nullable<decimal> VAT_AMOUNT { get; set; }
        public string PAY_REQ_NO { get; set; }
        public string INCOMING_BILL_NO { get; set; }
        public Nullable<int> INCOMING_BILL_ID { get; set; }
        public decimal LOCAL_AMOUNT { get; set; }
        public decimal FOREIGN_AMOUNT { get; set; }
        public string CURRENCY { get; set; }
        public decimal EXCHANGE_RATE { get; set; }
        public int JOB_ID { get; set; }
        public Nullable<int> SUB_HOUSE_ID { get; set; }
        public decimal UNIT_RATE { get; set; }
        public string UNIT { get; set; }
        public decimal QUANTITY { get; set; }
        public Nullable<System.Guid> CLIENT_GUID { get; set; }
        public int CHARGE_CODE_ID { get; set; }
        public string STATUS { get; set; }
        public string IS_AUTO_ALLOCATION { get; set; }
        public string CREATE_BY { get; set; }
        public System.DateTime CREATE_TIMESTAMP { get; set; }
        public string UPDATE_BY { get; set; }
        public System.DateTime UPDATE_TIMESTAMP { get; set; }
        public Nullable<int> PARENT_ID { get; set; }
        public string REMARK { get; set; }
        public string LANE_NO { get; set; }
        public string ALLOCATE_JOB { get; set; }
    
        public virtual TB_CHARGE_CODE TB_CHARGE_CODE { get; set; }
        public virtual TB_COMPANY TB_COMPANY { get; set; }
        public virtual TB_JOB TB_JOB { get; set; }
        public virtual ICollection<TB_COST> TB_COST1 { get; set; }
        public virtual TB_COST TB_COST2 { get; set; }
        public virtual TB_STATION TB_STATION { get; set; }
        public virtual TB_JOB TB_JOB1 { get; set; }
    }
}
