using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsGradeLimit
    {
        public int GradeLimitId { get; set; }
        public int GradeId { get; set; }
        public int ClassId { get; set; }
        public string Type { get; set; }
        public int PremiumCurrency { get; set; }
        public decimal PremiumAmt { get; set; }
        public int SumInsuredCurrency { get; set; }
        public decimal SumInsuredAmt { get; set; }
        public string PageMethod { get; set; }
    }
}
