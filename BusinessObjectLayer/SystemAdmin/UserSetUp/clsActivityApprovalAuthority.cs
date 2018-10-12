using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsActivityApprovalAuthority
    {
        public int ActivityAccessId { get; set; }
        public string ActivityID { get; set; }
        public string AuthorityLevelI { get; set; }
        public string AuthorityLevelII { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int ActivityRefID { get; set; }
        public int UserID { get; set; }
    }

    public class ActivityApprovalAuthorityList
    {
        public List<clsActivityApprovalAuthority> ApprovalAuthorityList { get; set; }
    }
}
