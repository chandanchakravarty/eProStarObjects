using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate1 { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
