using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsBenefitLineMaster
    {
        public int BenefitGroupLineID { get; set; }
        public int BenefitLineID { get; set; }
        public string BenefitLineName { get; set; }
        public int BenefitScheduleID { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsSelected { get; set; }
        public string DeptType { get; set; }
        public string SubBenefitLineID { get; set; }
        public string SubBenefitOrderID { get; set; }
        public int OrderNo { get; set; }
    }
}
