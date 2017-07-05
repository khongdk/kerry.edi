using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Service.Model
{
    public class CostModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string PayeePartyID { get; set; }
        public string JobNO { get; set; }
        public string BizType { get; set; }
        public string ChargeCode { get; set; }
        public int CompanyID { get; set; }
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public Nullable<int> VatTypeID { get; set; }
        public Nullable<decimal> VatPercentage { get; set; }
        public Nullable<decimal> VatAMT { get; set; }
        public string PayReqNO { get; set; }
        public string IncomingBillNO { get; set; }
        public Nullable<int> IncomingBillID { get; set; }
        public decimal LocalAMT { get; set; }
        public decimal ForeignAMT { get; set; }
        public string Currency { get; set; }
        public decimal EXRATE { get; set; }
        public int JobID { get; set; }
        public Nullable<int> SubHouseID { get; set; }
        public decimal UnitRate { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<System.Guid> ClientGuid { get; set; }
        public int ChargeCodeID { get; set; }
        public string Status { get; set; }
        public string IsAutoAllocation { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateTimestamp { get; set; }
        public string UPDATE_BY { get; set; }
        public System.DateTime UpdateTimestamp { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Remark { get; set; }
        public string LaneNO { get; set; }
        public string AllocationJob { get; set; }

    }
}