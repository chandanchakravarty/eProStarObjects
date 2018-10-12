using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsSourceCode
    {
        public int SCId { get; set; }
        public string SCName { get; set; }
        public int SOBId { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
