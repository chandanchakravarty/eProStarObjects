using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserActivityApprovalLevel
    {
        public int ActivityRefID { get; set; }
        public string ActivityID { get; set; }
        public string ApprovalLevel { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserActivityApprovalLevelList
    {
        public List<clsUserActivityApprovalLevel> ActivityApprovalLevelList { get; set; }
    }
}
