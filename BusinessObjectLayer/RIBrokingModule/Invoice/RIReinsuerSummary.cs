using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Invoice
{
    public class RIReinsuerSummary
    {
        public string TranRefNo { get; set; }
        public string UserId { get; set; }
        public string Remarks { get; set; }
        public string ReinsuerCode { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetPremium { get; set; }
        public int InstNo { get; set; }
        public int  ID { get; set; }
        public string RICode { get; set; }
        public string RIName { get; set; }
        public decimal RISharedPremium { get; set; }
        public decimal PremiumReserve { get; set; }
        public double  InterestRate { get; set; }
        public string  Frequency { get; set; }
        public string ReleaseDate { get; set; }
    }
}
