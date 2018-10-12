using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsBranchList
    {
        public int GrpCompBranchId { get; set; }
        public string GrpAccessCd { get; set; }
        public int CompanyId { get; set; }
        public int BranchID { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public int isSelected { get; set; }
        public string Pagemode { get; set; }
    }
}
