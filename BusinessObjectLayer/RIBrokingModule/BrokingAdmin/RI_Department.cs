using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class RI_Department
    {
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptNameCh { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        
    }
}
