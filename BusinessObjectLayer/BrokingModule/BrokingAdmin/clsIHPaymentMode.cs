using System;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsIHPaymentMode
    {
        public string PaymentModeCode { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
        public int NoOfInstl { get; set; }
        public decimal InstlFee { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string PageMode { get; set; }
    }
}
