using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsSubBenefitLineMaster
   {
        public int BenefitDetailLineID { get; set; }
        public int BenefitLineID { get; set; }
        public int SubBenefitLineID { get; set; }
        public string SubBenefitLineName { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsSelected { get; set; }
        public int OrderNo { get; set; }
        public string DeptType { get; set; }

    }
}
