using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class SA_Grade
    {
        public Int32 GradeId { get; set; }
        public string GradeName { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PageMethod { get; set; }
    }
}
