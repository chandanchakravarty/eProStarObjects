using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsExcessDeductibleSummary
    {
        public string TranRefNo { get; set; }
        public int SubClassCode { get; set; }
        public string ID { get; set; }
        public string IsChecked { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public string  Basis { get; set; }
        public string UserId { get; set; }
    }
}
