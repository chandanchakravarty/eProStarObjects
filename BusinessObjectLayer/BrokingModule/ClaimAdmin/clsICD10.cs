using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public  class clsICD10
    {

        public int ICD_ID { get; set; }
        public string ICD_Code { get; set; }
        public string ICD_Description { get;set ; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate1 { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsActive { get; set; }
    }
}
