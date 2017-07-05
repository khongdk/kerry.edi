using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Service.Model
{
    public class BillModel
    {
        public BillModel()
        {
            //this.BillRevRel = new List<BillRevenueRel>();
        }

        public int ID { get; set; }
        public int JobID { get; set; }
        public string    JobNO { get; set; }
        public string OwnerID { get; set; }
        public string CustPartyID { get; set; }
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public string BizType { get; set; }
        public string BillNO { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public int BillToCompanyID { get; set; }
        public string BillToName { get; set; }
        public string BillToAddress { get; set; }
        public string OffsetBillNO { get; set; }
        public string PaymentTerms { get; set; }
        public Nullable<int> CreditDays { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> EXRATE { get; set; }
        public Nullable<int> VatTypeID { get; set; }
        public string VatCode { get; set; }
        public Nullable<decimal> VatAmt { get; set; }
        public Nullable<decimal> BillAmt { get; set; }
        public Nullable<decimal> LocalAmt { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string ConfirmBy { get; set; }
        public Nullable<System.DateTime> ConfirmDate { get; set; }
        public string ApproveBy { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public string PostBy { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<int> StatementID { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateTimestamp { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateTimestamp { get; set; }


        //public List<BillRevenueRel> BillRevRel { get; set; }
    }
}