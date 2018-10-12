using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsDivisionalGropuing
    {
        public string BillingFrom { get; set; }
        public string BillingTo { get; set; }
        public string POIFrom { get; set; }
        public string POITo { get; set; }
        public string ClosingSlipNo { get; set; }
        public string InsuredName { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string IntroducerCode { get; set; }
        public string IntroducerName { get; set; }
        public string AccountServicer { get; set; }
        public string DivisionalGrouping { get; set; }
        public string Insurer { get; set; }
        public string PolicySource { get; set; }
        public string ClientSource { get; set; }
        public string DebitNaoteNo { get; set; }
        public string BillingDate { get; set; }
        public decimal GrossPremium { get; set; }
        public decimal GrossBrokerage { get; set; }
        public decimal OwnBrokerage { get; set; }
        public string AccountingMonthFrom { get; set; }
        public string AccountingMonthTo { get; set; }
        public string ReportBy { get; set; }
        public int UserId { get; set; }
    }
}
