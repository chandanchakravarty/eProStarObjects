using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserSuspension
    {
        public int UserId { get; set; }
        public string HistFor { get; set; }
        public int UserNameId { get; set; }
        public string SuspensionFromDate { get; set; }
        public string SuspensionToDate { get; set; }
        public string SuspensionReason { get; set; }
        public int ReassignUserId { get; set; }
        public string IsActive { get; set; }
        public string LoginUserId { get; set; }
        public string SuspensionName { get; set; }
    }
    public class clsSuspensionHistory
    {
        public int UserId { get; set; }
        public int PrevUserId { get; set; }
        public string CreatedDate { get; set; }
        public string AssignedBy { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public string SuspensionReason { get; set; }
        public int ReassignUserId { get; set; }
		public int ApprovalLevelI {get; set; }
        public int ApprovalLevelII {get; set; }
	    public int ClientLevelI {get; set; }
	    public int ClientLevelII {get; set; }
        public string LastInactivedDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
