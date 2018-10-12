using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsNewPremiumRateMaster
    {
        public Int32 NewPremRateID { get; set; }
        public string ClassName { get; set; }
        public int SubClassID { get; set; }
        public string Description { get; set; }
        public decimal PremRate { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
