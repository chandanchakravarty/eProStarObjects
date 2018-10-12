using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class ExcessDeductible
    {
        public int ExcessDeductibleId { get; set; }
        public string ExcessDeductibleDiscription { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate1 { get; set; }
        public string LoginUserId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        public string CreatedTime { get; set; }
        public string Result { get; set; } 
        public int ReturnCode { get; set; }

    }
}
