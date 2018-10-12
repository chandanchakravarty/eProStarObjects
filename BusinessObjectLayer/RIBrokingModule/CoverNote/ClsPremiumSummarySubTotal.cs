using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsPremiumSummarySubTotal
    {
        public string TranRefNo { get; set; }
        public int SubClassCode { get; set; }
        public string Code { get; set; }
        public int TotalDays { get; set; }
        public int ProrataDays { get; set; }
        public string ID { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Rate { get; set; }
        public decimal CalcPremium { get; set; }
        public decimal Share { get; set; }
        public decimal SharePremium { get; set; }
        public decimal RIRate { get; set; }
        public decimal RIPremium { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
    }
}
