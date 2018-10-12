using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaimFollowUp
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string FollowUpCode { get; set; }
        public string FollowUpReason { get; set; }
        public string FollowUpAlert { get; set; }
        public string DiaryDescription { get; set; }
        public string FollowUpDate { get; set; }
        public string UserID { get; set; }
        public string TypeName { get; set; }// Added By Kumar Rituraj
    }
}
