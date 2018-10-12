using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsExcessMaster
    {
        public int ExcessID { get; set; }
        public int ClassID { get; set; }
        public int SubClassID { get; set; }
        public string Description { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
