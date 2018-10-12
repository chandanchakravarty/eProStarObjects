using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsFollowUpReasonMaster
    {
        public int FollowUpReasonId { get; set; }
        public string FollowUpReasonDesc { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
